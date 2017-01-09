namespace UnityEngine
{
    public static class MathfExtensions
    {
        public enum OffsetAxis
        { 
            X,
            Y
        }

        /// <summary>
        /// Returns values similar to lerp, except using bezier algorithm
        /// </summary>
        /// <param name="f1">The Y position of the first node</param>
        /// <param name="f2">The Y position of the second node</param>
        /// <param name="t">Percentage of the interpolation. Values from 0 to 1</param>
        /// <param name="offset1">Position of the first helper node</param>
        /// <param name="offset2">Position of the second helper node</param>
        /// <param name="XStretch">Stretch on the x axis (x position of the second node)</param>
        /// <param name="Axis">Axis on which the helpernodes are offset</param>
        /// <returns></returns>
        public static float BezierInterpolation(float f1, float f2, float t, float offset1 = 0.5f, float offset2 = 0.5f, float XStretch = 1f, OffsetAxis Axis = OffsetAxis.Y)
        {
            t = Mathf.Clamp(t, 0f, 1f);
            Vector2 point1, point2, point3, point4;
            point1 = new Vector2(0, f1);
            if (Axis == OffsetAxis.Y)
            {
                point2 = new Vector2(f1, offset1);
                point3 = new Vector2(f2, offset2);
            }
            else
            {
                point2 = new Vector2(offset1, f1);
                point3 = new Vector2(offset2, f2);
            }
            point4 = new Vector2(XStretch, f2);
            float f;
            f = (Mathf.Pow(1 - t, 3) * point1 + 3 * Mathf.Pow(1 - t, 2) * t * point2 + 3 * (1 - t) * t * t * point3 + t * t * t * point4).y;
            return f;
        }

        /// <summary>
        /// returns bezier interpolation that slow at start and end, and fast in the middle
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float BezierPresets_BasicBezier(float f1, float f2, float t)
        {
            float offset = Mathf.Abs((f1 - f2) / 2);
            return BezierInterpolation(f1, f2, t, offset, offset, Mathf.Abs(f1 - f2), OffsetAxis.X);
        }

        /// <summary>
        /// returns half circle bezier interpolation
        /// </summary>
        /// <param name="size"></param>
        /// <param name="t"></param>
        /// <param name="XStretch"></param>
        /// <returns></returns>
        public static float BezierPresets_HalfCircle(float size, float t, float XStretch = 1f)
        {
            return BezierInterpolation(0, 0, t, size, size, XStretch);
        }

        /// <summary>
        /// returns exponential bezier interpolation
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="t"></param>
        /// <param name="XStretch"></param>
        /// <returns></returns>
        public static float BezierPresets_Exponential(float f1, float f2, float t, float XStretch = 1f)
        {
            return BezierInterpolation(f1, f2, t, f1, f1, XStretch);
        }

        /// <summary>
        /// returns inverse exponential bezier interpolation
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="t"></param>
        /// <param name="XStretch"></param>
        /// <returns></returns>
        public static float BezierPresets_Squared(float f1, float f2, float t, float XStretch = 1f)
        {
            return BezierInterpolation(f1, f2, t, f2, f2, XStretch);
        }
    }

    public static class Vector2Extension
    {
        /// <summary>
        /// Rotates the vector by an angle
        /// </summary>
        /// <param name="v">the vector</param>
        /// <param name="degrees">degrees to rotate</param>
        /// <returns>Returns rotated vector</returns>
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = v.x;
            float ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }
    }

    public static class UnityObjectExtensions
    {
        /// <summary>
        /// Calls the Object.Destroy(). Handy!
        /// </summary>
        /// <param name="obj"></param>
        public static void Destroy(this UnityEngine.Object obj)
        {
            Object.Destroy(obj);
        }
    }
}