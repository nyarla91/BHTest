using UnityEngine;

namespace Source.Extentions
{
    public static class MathExtentions
    {
        public static bool InBounds(this float number, float max, float min) => (number >= min && number <= max);
        
        public static float ClampAngle(this float angle, float min, float max)
        {
            angle = Mathf.Repeat(angle, 360);
            min = Mathf.Repeat(min, 360);
            max = Mathf.Repeat(max, 360);

            if (min < max)
            {
                if (angle.InBounds(max, min))
                    return angle;

                return Mathf.DeltaAngle(angle, min) < Mathf.DeltaAngle(angle, max) ? min : max;
            }
            if (angle > min || angle < max)
                return angle;

            return Mathf.Abs(angle - min) < Mathf.Abs(angle - max) ? min : max;
        }
    }
}