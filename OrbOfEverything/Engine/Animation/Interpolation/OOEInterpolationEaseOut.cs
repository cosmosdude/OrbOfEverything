using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Engine.Animation.Interpolation
{
    /// <summary>
    /// Robert Penner's Quadratic Ease Out Function.
    /// </summary>
    class OOEInterpolationEaseOut: OOEInterpolation
    {
        
        public override float InterpolatedValueOf(float currentTime, float totalTime, float startValue, float endValue)
        {
            float c = endValue - startValue;

            return -c * (currentTime /= totalTime) * (currentTime - 2) + startValue;
        }
    }
}
