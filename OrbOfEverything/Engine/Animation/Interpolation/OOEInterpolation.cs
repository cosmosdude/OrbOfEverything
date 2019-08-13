using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Engine.Animation.Interpolation
{
    public abstract class OOEInterpolation
    {
        /// <summary>
        /// Linear interpolator.
        /// </summary>
        public static readonly OOEInterpolation linear = new OOEInterpolationLinear();

        public static readonly OOEInterpolation easeIn = new OOEInterpolationEaseIn();

        public static readonly OOEInterpolation easeOut = new OOEInterpolationEaseOut();

        public static readonly OOEInterpolation easeInOut = new OOEInterpolationEaseInOut();

        public abstract float InterpolatedValueOf(float currentTime, float totalTime, float startValue, float endValue);
    }
}
