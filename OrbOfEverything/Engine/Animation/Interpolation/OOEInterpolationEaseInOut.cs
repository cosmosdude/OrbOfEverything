using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Engine.Animation.Interpolation
{
    /// <summary>
    /// Robert Penner's Quadratic Ease In Ease Out Function
    /// </summary>
    class OOEInterpolationEaseInOut: OOEInterpolation
    {
        public override float InterpolatedValueOf(float currentTime, float totalTime, float startValue, float endValue)
        {
            float c = endValue - startValue;
            if ((currentTime /= totalTime/2) < 1) return ( (c / 2) *  (float)Math.Pow(currentTime, 2)) + startValue;
            return -c / 2 * ((--currentTime * (currentTime - 2)) - 1) + startValue;
        }
    }
}
