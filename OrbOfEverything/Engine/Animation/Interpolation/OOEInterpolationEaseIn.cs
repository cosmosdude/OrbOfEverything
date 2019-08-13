using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Engine.Animation.Interpolation
{
    /// <summary>
    /// Robert Penner's Quadratic Ease In Function.
    /// </summary>
    class OOEInterpolationEaseIn : OOEInterpolation
    {
        public override float InterpolatedValueOf(float currentTime, float totalTime, float startValue, float endValue)
        {
            float c = endValue - startValue;

            return c * (currentTime /= totalTime) * currentTime + startValue;
        }
    }
}
