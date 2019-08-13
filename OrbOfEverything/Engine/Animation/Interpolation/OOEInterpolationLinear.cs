using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Engine.Animation.Interpolation
{
    class OOEInterpolationLinear : OOEInterpolation
    {
        public override float InterpolatedValueOf(float currentTime, float totalTime, float startValue, float endValue)
        {
            float rangeValue = endValue - startValue;
            float percent = currentTime / totalTime;
            return startValue + (rangeValue * percent);
        }
    }
}
