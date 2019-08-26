///
/// Author: Thwin Htoo Aung
/// 
/// Project: Orb of Everything
/// 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
// using System.Timers;


namespace OrbOfEverything.Engine
{

    /// <summary>
    /// Frame-based engine.
    /// 
    /// Useful for writing frame-based drawing, animation and physics.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// This class follows the singleton design pattern.
    /// You can get an instance of this by invoking `OOEEngine.Shared` static property.
    /// </remarks>
    public sealed class OOEEngine
    {
        // MARK:- Private properties

        // MARK:- Observers
        private List<OOEEngineObserving> animators = new List<OOEEngineObserving>();
        private List<OOEEngineObserving> physicsObjects = new List<OOEEngineObserving>();
        private List<OOEEngineObserving> customObservers = new List<OOEEngineObserving>();
        private List<OOEEngineObserving> graphicsObjects = new List<OOEEngineObserving>();

        private bool IsDoneRunning = true;

        public void Clear()
        {
            animators.Clear();
            physicsObjects.Clear();
            customObservers.Clear();
            graphicsObjects.Clear();
        }

        // MARK:- Timer values
        private Timer fixedTimer;
        private UInt32 fps = 45;
        public UInt32 FPS
        {
            set
            {
                if (value == this.fps) return;
                this.fps = value;
                TearDownTimer();
                StartTimerIfAnyObserver();
            }
            get
            {
                return this.fps;
            }
        }

        
        

        // MARK:- Frame values
        public UInt64 currentFrame = 0;


        
        // MARK:- Public properties
        /// <summary>
        /// Indicate whether the engine is paused.
        /// </summary>
        public bool IsPaused = false;


        // MARK:- Constructors & Singleton
        private OOEEngine() { }
        private static OOEEngine singleton = null;

        /// <summary>
        /// Shared instance of OOE Engine.
        /// </summary>
        public static OOEEngine Shared
        {
            get
            {
                if (singleton == null) singleton = new OOEEngine();
                return singleton;
            }
        }



        // MARK:- Private method signatures
        private void FixedUpdateEventFor(List<OOEEngineObserving> items)
        {
            if (IsDoneRunning == false) return;

            IsDoneRunning = false;

            var copied = new List<OOEEngineObserving>(items);
            foreach (OOEEngineObserving eachObserver in copied)
            if (eachObserver.IsPaused == false) eachObserver.FixedUpdate();

            IsDoneRunning = true;
        }
        private void FixedUpdate(Object sender, EventArgs tEventArgs)
        {
            // Console.WriteLine("OOEEngine.FixedUpdate is running.");
            
            if (IsPaused) return;
            currentFrame += 1;
            Console.WriteLine("Engine State paused?: " + IsPaused);
            
            // advance animators > physics > custom > graphics sequencially by one frame
            FixedUpdateEventFor(this.animators);
            FixedUpdateEventFor(this.physicsObjects);
            FixedUpdateEventFor(this.customObservers);
            FixedUpdateEventFor(this.graphicsObjects);
        }


        private void NotifyFPSChangeFor(List<OOEEngineObserving> items)
        {
            foreach (OOEEngineObserving eachObserver in items)
            if (eachObserver.IsPaused == false) eachObserver.FPSChanged(this);
        }

        private void NotifyFPSChange()
        {
            // advance animators > physics > custom > graphics by one frame
            NotifyFPSChangeFor(this.animators);
            NotifyFPSChangeFor(this.physicsObjects);
            NotifyFPSChangeFor(this.customObservers);
            NotifyFPSChangeFor(this.graphicsObjects);
        }
        private void SetupTimer()
        {
            if (this.fixedTimer == null)
            {
                this.fixedTimer = new Timer();
                fixedTimer.Tick += this.FixedUpdate;
                // fixedTimer.SynchronizingObject = ISynchronizationInvoke
                // fixedTimer.SynchronizingObject = SynchronizationContext.Current;
                // fixedTimer.Elapsed += this.FixedUpdate;
                fixedTimer.Interval = 1000 / ((int)this.fps);

            }
        }
        private void TearDownTimer()
        {
            if (fixedTimer != null)
            {
                this.fixedTimer.Stop();
                this.fixedTimer.Dispose();
                this.fixedTimer = null;
            }
        }
        private void StopTimerIfNoObserver()
        {
            if (this.fixedTimer == null) return;
            int totalObservers = animators.Count + physicsObjects.Count + customObservers.Count + graphicsObjects.Count;
            if (totalObservers == 0)
            {
                TearDownTimer();
            }
        }
        private void StartTimerIfAnyObserver()
        {
            if (this.fixedTimer != null && this.fixedTimer.Enabled == true) return;
            int totalObservers = animators.Count + physicsObjects.Count + customObservers.Count + graphicsObjects.Count;
            if (totalObservers != 0)
            {
                SetupTimer();
                fixedTimer.Enabled = true;
                fixedTimer.Start();
            }
        }

        private void AddAnimator(OOEEngineObserving animator)
        {
            if (animator == null) return;
            if (animators.Contains(animator) == false) animators.Add(animator);
            
        }

        private void RemoveAnimator(OOEEngineObserving animator)
        {
            if (animator == null) return;
            animators.Remove(animator);
        }

        private void AddPhysicsObject(OOEEngineObserving physicsObject)
        {
            if (physicsObject == null) return;
            if (physicsObjects.Contains(physicsObject) == false) physicsObjects.Add(physicsObject);
        }

        private void RemovePhysicsObject(OOEEngineObserving physicsObject)
        {
            if (physicsObject == null) return;
            physicsObjects.Remove(physicsObject);
        }

        private void AddCustomObserver(OOEEngineObserving customObserver)
        {
            if (customObserver == null) return;
            if (customObservers.Contains(customObserver) == false) customObservers.Add(customObserver);
        }
        private void RemoveCustomObserver(OOEEngineObserving customObserver)
        {
            if (customObserver == null) return;
            customObservers.Remove(customObserver);
        }

        // MARK:- Public method signatures


        /// <summary>
        /// Add an fps fixed update observer.
        /// </summary>
        /// <param name="item">Observer item that want to know events of the engine</param>
        /// <param name="type">Type of the observer. Default to OOEEngineObserverType.unspecified. If unspecified, remove from custom observers.</param>
        public void Add(OOEEngineObserving item, OOEEngineObserverType type = OOEEngineObserverType.unspecified)
        {
            
            if (type == OOEEngineObserverType.animator)
            {
                this.AddAnimator(item);
            } else if (type == OOEEngineObserverType.physics)
            {
                this.AddPhysicsObject(item);
            } else if (type == OOEEngineObserverType.graphics)
            {
                this.AddGraphicsObject(item);
            } else
            {
                this.AddCustomObserver(item);
            }

            StartTimerIfAnyObserver();
        }


        /// <summary>
        /// Remove observer from the pool.
        /// </summary>
        /// <param name="item">Observer item to be removed.</param>
        /// <param name="type">Type of the observer. Default to OOEEngineObserverType.unspecified. If unspecified, remove from all pool.</param>
        public void Remove(OOEEngineObserving item, OOEEngineObserverType type = OOEEngineObserverType.unspecified)
        {
            if (type == OOEEngineObserverType.animator)
            {
                this.RemoveAnimator(item);
            }
            else if (type == OOEEngineObserverType.physics)
            {
                this.RemovePhysicsObject(item);
            }
            else if (type == OOEEngineObserverType.graphics)
            {
                this.RemoveGraphicsObject(item);
            }
            else if (type == OOEEngineObserverType.custom)
            {
                this.RemoveCustomObserver(item);
            } else
            {
                this.RemoveAnimator(item);
                this.RemovePhysicsObject(item);
                this.RemoveCustomObserver(item);
                this.RemoveGraphicsObject(item);
            }

            StopTimerIfNoObserver();
        }




        public void AddGraphicsObject(OOEEngineObserving graphicsObject)
        {
            if (graphicsObject == null) return;
            if (graphicsObjects.Contains(graphicsObject) == false) graphicsObjects.Add(graphicsObject);
        }

        public void RemoveGraphicsObject(OOEEngineObserving graphicsObject)
        {
            if (graphicsObject == null) return;
            graphicsObjects.Remove(graphicsObject);
        }

        
    }
}
