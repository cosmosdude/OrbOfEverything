using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrbOfEverything.Engine.Animation.Interpolation;

namespace OrbOfEverything.Engine.Animation
{
    public sealed class OOEValueAnimator : OOEAnimating
    {

        /// <summary>
        /// Frame-based animator that value directly.
        /// </summary>
        /// 
        /// <remarks>
        /// OOEValueAnimator is extended in declarative programming style.
        /// </remarks>
        ///
        public OOEValueAnimator(): base()
        {
            timePerFrame = 1 / (float)OOEEngine.Shared.FPS;

            engine = OOEEngine.Shared;
        }

        private bool _IsPaused = false;
        public override bool IsPaused { set { _IsPaused = value; } get { return _IsPaused; } }

        private OOEEngine engine = null;

        // MARK:= private properties
        private float fromValue = .0f;
        private float toValue = 1;
        private float currentTime = .0f;
        private float totalTime = 1f;

        private float timePerFrame = 0.1667f;

        public override void FixedUpdate()
        {
            if(this.State == OOEAnimationState.running)
            {
                Console.WriteLine("OOEValueAnimator.FixedUpdate is running.");
                Console.WriteLine("Animator State :" + State);
                Console.WriteLine("Is Paused : " + IsPaused);
                
                OOEInterpolation interpolation = this.interpolator;
                if (interpolation == null) interpolation = OOEInterpolation.linear;

                currentTime += timePerFrame;

                if(currentTime >= totalTime)
                {
                    currentTime = totalTime;
                }

                // Console.WriteLine("OOEValueAnimator.currentTime = " + currentTime);
                
                if (OnValueChange != null)
                {
                    float value = interpolation.InterpolatedValueOf(currentTime, totalTime, startValue: fromValue, endValue: toValue);
                    OnValueChange(value);
                }

                if(currentTime == totalTime)
                {
                    Pause();
                    
                    if (OnFinish != null) OnFinish();
                }
            }
        }

        public override void FPSChanged(OOEEngine sender)
        {
            // calculate time per frame.
            timePerFrame = 1 / (float)sender.FPS;
        }

        public override void Pause()
        {
            this.IsPaused = true;
            if (this.State == OOEAnimationState.running && this.OnPause != null)
            {
                OnPause();
            }
            this.State = OOEAnimationState.paused;
        }

        public override void Resume()
        {
            
            if (this.State == OOEAnimationState.paused && this.OnResume != null)
            {
                OnResume();
            }
            this.State = OOEAnimationState.running;
            this.IsPaused = false;
        }

        public override void Start()
        {
            Console.WriteLine("OOEValueAnimator.Start called");
            
            if (this.State == OOEAnimationState.stopped && this.OnStart != null)
            {
                OnStart();
                this.currentTime = 0;
            }
            this.State = OOEAnimationState.running;
            this.IsPaused = false;
        }

        public override void Stop()
        {
            if (State == OOEAnimationState.running && OnStop != null)
            {
                this.IsPaused = true;
                OnStop();
                this.currentTime = 0;
            }
            
            this.State = OOEAnimationState.stopped;
            
        }

        
        public OOEValueAnimator From(float value)
        {
            fromValue = value;
            return this;
        }
        public OOEValueAnimator To(float value)
        {
            toValue = value;
            return this;
        }
        public OOEValueAnimator Duration(float value)
        {
            totalTime = value;
            return this;
        }

        public OOEValueAnimator Interpolation(OOEInterpolation interpolator)
        {
            this.interpolator = interpolator;
            return this;
        }
    }
}
