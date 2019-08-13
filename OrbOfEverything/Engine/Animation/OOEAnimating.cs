using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OrbOfEverything.Engine.Animation.Interpolation;

namespace OrbOfEverything.Engine.Animation
{
    public delegate void OOEAnimationOnValueChange(float value);

    public delegate void OOEAnimationOnStart();

    public delegate void OOEAnimationOnPause();

    public delegate void OOEAnimationOnResume();

    public delegate void OOEAnimationOnStop();

    public delegate void OOEAnimationOnFinish();

    public abstract class OOEAnimating : OOEEngineObserving
    {
        public OOEAnimating()
        {
            OOEEngine.Shared.Add(this, OOEEngineObserverType.animator);
        }
        /// <summary>
        /// Called when the animator object is started.
        /// </summary>
        public OOEAnimationOnStart OnStart { get; set; }

        /// <summary>
        /// Called when the animator object is stopped.
        /// </summary>
        public OOEAnimationOnStop OnStop { get; set; }

        /// <summary>
        /// Called when the animator object is paused.
        /// </summary>
        public OOEAnimationOnPause OnPause { get; set; }

        /// <summary>
        /// Called when the animator objecct is resumed.
        /// </summary>
        public OOEAnimationOnResume OnResume { get; set; }

        /// <summary>
        ///  Called when value is changed by animator object.
        /// </summary>
        public OOEAnimationOnValueChange OnValueChange { get; set; }

        /// <summary>
        /// Called when the animation is finished.
        /// </summary>
        public OOEAnimationOnFinish OnFinish { get; set; }

        public OOEAnimationState State = OOEAnimationState.stopped;

        public OOEInterpolation interpolator  = OOEInterpolation.linear;

        public abstract bool IsPaused { get; set; }

        public abstract void Start();
        public abstract void Stop();
        public abstract void Pause();
        public abstract void Resume();
        public abstract void FPSChanged(OOEEngine sender);
        public abstract void FixedUpdate();

        public virtual void Dispose()
        {
            OOEEngine.Shared.Remove(this, OOEEngineObserverType.animator);
        }
    }





    public enum OOEAnimationState
    {
        stopped, running, paused
    }
    
}
