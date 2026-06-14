using System;
using System.Numerics;
using UnityEngine;

namespace AntoMega
{
    public class MathHelper
    {
        #region Abs
        public static UnityEngine.Vector2 Abs(in UnityEngine.Vector2 _vector2)
        {
            return new UnityEngine.Vector2(
                Mathf.Abs(_vector2.x),
                Mathf.Abs(_vector2.y)
            );
        }
        public static UnityEngine.Vector2Int Abs(in UnityEngine.Vector2Int _vector2i)
        {
            return new UnityEngine.Vector2Int(
                Mathf.Abs(_vector2i.x),
                Mathf.Abs(_vector2i.y)
            );
        }
        public static UnityEngine.Vector3 Abs(in UnityEngine.Vector3 _vector3)
        {
            return new UnityEngine.Vector3(
                Mathf.Abs(_vector3.x),
                Mathf.Abs(_vector3.y),
                Mathf.Abs(_vector3.z)
            );
        }
        public static UnityEngine.Vector3Int Abs(in UnityEngine.Vector3Int _vector3i)
        {
            return new UnityEngine.Vector3Int(
                Mathf.Abs(_vector3i.x),
                Mathf.Abs(_vector3i.y),
                Mathf.Abs(_vector3i.z)
            );
        }
        public static UnityEngine.Vector4 Abs(in UnityEngine.Vector4 _vector4)
        {
            return new UnityEngine.Vector4(
                Mathf.Abs(_vector4.x),
                Mathf.Abs(_vector4.y),
                Mathf.Abs(_vector4.z),
                Mathf.Abs(_vector4.w)
            );
        }
        public static UnityEngine.Color Abs(in UnityEngine.Color _colour)
        {
            return new UnityEngine.Color(
                Mathf.Abs(_colour.r),
                Mathf.Abs(_colour.g),
                Mathf.Abs(_colour.b),
                Mathf.Abs(_colour.a)
            );
        }
        public static UnityEngine.Quaternion Abs(in UnityEngine.Quaternion _quaternion)
        {
            return new UnityEngine.Quaternion(
                Mathf.Abs(_quaternion.x),
                Mathf.Abs(_quaternion.y),
                Mathf.Abs(_quaternion.z),
                Mathf.Abs(_quaternion.w)
            );
        }
        #endregion

        #region Clamp
        public static UnityEngine.Vector2 Clamp(in UnityEngine.Vector2 _vector2, in float _min, in float _max)
        {
            return new UnityEngine.Vector2(
                Mathf.Clamp(_vector2.x, _min, _max),
                Mathf.Clamp(_vector2.y, _min, _max)
            );
        }
        public static UnityEngine.Vector2Int Clamp(in UnityEngine.Vector2Int _vector2i, in int _min, in int _max)
        {
            return new UnityEngine.Vector2Int(
                Mathf.Clamp(_vector2i.x, _min, _max),
                Mathf.Clamp(_vector2i.y, _min, _max)
            );
        }
        public static UnityEngine.Vector3 Clamp(in UnityEngine.Vector3 _vector3, in float _min, in float _max)
        {
            return new UnityEngine.Vector3(
                Mathf.Clamp(_vector3.x, _min, _max),
                Mathf.Clamp(_vector3.y, _min, _max),
                Mathf.Clamp(_vector3.z, _min, _max)
            );
        }
        public static UnityEngine.Vector3Int Clamp(in UnityEngine.Vector3Int _vector3i, in int _min, in int _max)
        {
            return new UnityEngine.Vector3Int(
                Mathf.Clamp(_vector3i.x, _min, _max),
                Mathf.Clamp(_vector3i.y, _min, _max),
                Mathf.Clamp(_vector3i.z, _min, _max)
            );
        }
        public static UnityEngine.Vector4 Clamp(in UnityEngine.Vector4 _vector4, in float _min, in float _max)
        {
            return new UnityEngine.Vector4(
                Mathf.Clamp(_vector4.x, _min, _max),
                Mathf.Clamp(_vector4.y, _min, _max),
                Mathf.Clamp(_vector4.z, _min, _max),
                Mathf.Clamp(_vector4.w, _min, _max)
            );
        }
        public static UnityEngine.Color Clamp(in UnityEngine.Color _colour, in float _min, in float _max, in bool _clampOpacity = true)
        {
            return
                (_clampOpacity)
                ? new UnityEngine.Color(
                    Mathf.Clamp(_colour.r, _min, _max),
                    Mathf.Clamp(_colour.g, _min, _max),
                    Mathf.Clamp(_colour.b, _min, _max),
                    Mathf.Clamp(_colour.a, _min, _max)
                )
                : new UnityEngine.Color(
                    Mathf.Clamp(_colour.r, _min, _max),
                    Mathf.Clamp(_colour.g, _min, _max),
                    Mathf.Clamp(_colour.b, _min, _max),
                    _colour.a
                );
        }
        public static UnityEngine.Color32 Clamp(in UnityEngine.Color32 _colour32, in byte _min, in byte _max, in bool _clampOpacity = true)
        {
            return
                (_clampOpacity)
                ? new UnityEngine.Color32(
                    Math.Clamp(_colour32.r, _min, _max),
                    Math.Clamp(_colour32.g, _min, _max),
                    Math.Clamp(_colour32.b, _min, _max),
                    Math.Clamp(_colour32.a, _min, _max)
                )
                : new UnityEngine.Color32(
                    Math.Clamp(_colour32.r, _min, _max),
                    Math.Clamp(_colour32.g, _min, _max),
                    Math.Clamp(_colour32.b, _min, _max),
                    _colour32.a
                );
        }
        public static UnityEngine.Quaternion Clamp(in UnityEngine.Quaternion _quaternion, in float _min, in float _max)
        {
            return new UnityEngine.Quaternion(
                Mathf.Clamp(_quaternion.x, _min, _max),
                Mathf.Clamp(_quaternion.y, _min, _max),
                Mathf.Clamp(_quaternion.z, _min, _max),
                Mathf.Clamp(_quaternion.w, _min, _max)
            );
        }
        #endregion

        #region Approximately
        public static bool Approximately(in UnityEngine.Vector2 _a, in UnityEngine.Vector2 _b)
        {
            return (Mathf.Approximately(_a.x, _b.x)
                && Mathf.Approximately(_a.y, _b.y));
        }
        public static bool Approximately(in UnityEngine.Vector3 _a, in UnityEngine.Vector3 _b)
        {
            return (Mathf.Approximately(_a.x, _b.x)
                && Mathf.Approximately(_a.y, _b.y)
                && Mathf.Approximately(_a.z, _b.z));
        }
        public static bool Approximately(in UnityEngine.Vector4 _a, in UnityEngine.Vector4 _b)
        {
            return (Mathf.Approximately(_a.x, _b.x)
                && Mathf.Approximately(_a.y, _b.y)
                && Mathf.Approximately(_a.z, _b.z)
                && Mathf.Approximately(_a.w, _b.w));
        }
        public static bool Approximately(in UnityEngine.Color _a, in UnityEngine.Color _b, in bool _includeAlpha = true)
        {
            if (_includeAlpha)
            {
                return (Mathf.Approximately(_a.r, _b.r)
                    && Mathf.Approximately(_a.g, _b.g)
                    && Mathf.Approximately(_a.b, _b.b)
                    && Mathf.Approximately(_a.a, _b.a));
            }

            return (Mathf.Approximately(_a.r, _b.r)
                && Mathf.Approximately(_a.g, _b.g)
                && Mathf.Approximately(_a.b, _b.b));
        }
        public static bool Approximately(in UnityEngine.Quaternion _a, in UnityEngine.Quaternion _b)
        {
            return (Mathf.Approximately(_a.x, _b.x)
                && Mathf.Approximately(_a.y, _b.y)
                && Mathf.Approximately(_a.z, _b.z)
                && Mathf.Approximately(_a.w, _b.w));
        }
        #endregion

        #region Min
        public static T Min<T>(in T[] _values) where T : struct, IComparable<T>
        {
            if (_values == null || _values.Length == 0)
            {
                throw new ArgumentException("Array must not be null or empty.");
            }

            T min = _values[0];
            for (int i = 1; i < _values.Length; i++)
            {
                if (_values[i].CompareTo(min) < 0)
                {
                    min = _values[i];
                }
            }

            return min;
        }

        public static T MinUnrolled<T>(in T[] _values) where T : struct, IComparable<T>
        {
            if (_values == null || _values.Length == 0)
            {
                throw new ArgumentException("Array must not be null or empty.");
            }

            int length = _values.Length;
            T min = _values[0];
            int i = 1;

            for (; i < length - 3; i += 4)
            {
                if (_values[i].CompareTo(min) < 0) { min = _values[i]; }
                if (_values[i + 1].CompareTo(min) < 0) { min = _values[i + 1]; }
                if (_values[i + 2].CompareTo(min) < 0) { min = _values[i + 2]; }
                if (_values[i + 3].CompareTo(min) < 0) { min = _values[i + 3]; }
            }

            for (; i < length; i++)
            {
                if (_values[i].CompareTo(min) < 0)
                {
                    min = _values[i];
                }
            }

            return min;
        }

        public static T MinSIMD<T>(T[] _values) where T : struct, IComparable<T>
        {
            if (_values == null || _values.Length == 0)
            {
                throw new ArgumentException("Array must not be null or empty.");
            }

            if (_values.Length < 64)
            {
                return MinUnrolled(_values);
            }

            var minVector = new Vector<T>(_values[0]);
            int i = 0;
            int vectorSize = Vector<T>.Count;
            int length = _values.Length - (_values.Length % vectorSize);

            for (; i < length; i += vectorSize)
            {
                var currentVector = new Vector<T>(_values, i);
                minVector = Vector.Min(minVector, currentVector);
            }

            T min = minVector[0];
            for (int j = 1; j < vectorSize; j++)
            {
                if (minVector[j].CompareTo(min) < 0)
                {
                    min = minVector[j];
                }
            }

            for (; i < _values.Length; i++)
            {
                if (_values[i].CompareTo(min) < 0)
                {
                    min = _values[i];
                }
            }

            return min;
        }
        #endregion

        #region Max
        public static T Max<T>(in T[] _values) where T : struct, IComparable<T>
        {
            if (_values == null || _values.Length == 0)
            {
                throw new ArgumentException("Array must not be null or empty.");
            }

            T max = _values[0];
            for (int i = 1; i < _values.Length; i++)
            {
                if (_values[i].CompareTo(max) < 0)
                {
                    max = _values[i];
                }
            }

            return max;
        }

        public static T MaxUnrolled<T>(in T[] _values) where T : struct, IComparable<T>
        {
            if (_values == null || _values.Length == 0)
            {
                throw new ArgumentException("Array must not be null or empty.");
            }

            int length = _values.Length;
            T max = _values[0];
            int i = 1;

            for (; i < length - 3; i += 4)
            {
                if (_values[i].CompareTo(max) < 0) { max = _values[i]; }
                if (_values[i + 1].CompareTo(max) < 0) { max = _values[i + 1]; }
                if (_values[i + 2].CompareTo(max) < 0) { max = _values[i + 2]; }
                if (_values[i + 3].CompareTo(max) < 0) { max = _values[i + 3]; }
            }

            for (; i < length; i++)
            {
                if (_values[i].CompareTo(max) < 0)
                {
                    max = _values[i];
                }
            }

            return max;
        }

        public static T MaxSIMD<T>(T[] _values) where T : struct, IComparable<T>
        {
            if (_values == null || _values.Length == 0)
            {
                throw new ArgumentException("Array must not be null or empty.");
            }

            if (_values.Length < 64)
            {
                return MaxUnrolled(_values);
            }

            var maxVector = new Vector<T>(_values[0]);
            int i = 0;
            int vectorSize = Vector<T>.Count;
            int length = _values.Length - (_values.Length % vectorSize);

            for (; i < length; i += vectorSize)
            {
                var currentVector = new Vector<T>(_values, i);
                maxVector = Vector.Max(maxVector, currentVector);
            }

            T max = maxVector[0];
            for (int j = 1; j < vectorSize; j++)
            {
                if (maxVector[j].CompareTo(max) < 0)
                {
                    max = maxVector[j];
                }
            }

            for (; i < _values.Length; i++)
            {
                if (_values[i].CompareTo(max) < 0)
                {
                    max = _values[i];
                }
            }

            return max;
        }
        #endregion

        #region Pow
        public static UnityEngine.Vector2 Pow(in UnityEngine.Vector2 _vector2, in float _power)
        {
            return new UnityEngine.Vector2(
                Mathf.Pow(_vector2.x, _power),
                Mathf.Pow(_vector2.y, _power)
            );
        }
        public static UnityEngine.Vector2Int Pow(in UnityEngine.Vector2Int _vector2, in float _power)
        {
            return new UnityEngine.Vector2Int(
                (int)(Mathf.Pow(_vector2.x, _power)),
                (int)(Mathf.Pow(_vector2.y, _power))
            );
        }
        public static UnityEngine.Vector3 Pow(in UnityEngine.Vector3 _vector3, in float _power)
        {
            return new UnityEngine.Vector3(
                Mathf.Pow(_vector3.x, _power),
                Mathf.Pow(_vector3.y, _power),
                Mathf.Pow(_vector3.z, _power)
            );
        }
        public static UnityEngine.Vector3Int Pow(in UnityEngine.Vector3Int _vector3, in float _power)
        {
            return new UnityEngine.Vector3Int(
                (int)(Mathf.Pow(_vector3.x, _power)),
                (int)(Mathf.Pow(_vector3.y, _power)),
                (int)(Mathf.Pow(_vector3.z, _power))
            );
        }
        public static UnityEngine.Vector4 Pow(in UnityEngine.Vector4 _vector4, in float _power)
        {
            return new UnityEngine.Vector4(
                Mathf.Pow(_vector4.x, _power),
                Mathf.Pow(_vector4.y, _power),
                Mathf.Pow(_vector4.z, _power),
                Mathf.Pow(_vector4.w, _power)
            );
        }
        public static UnityEngine.Color Pow(in UnityEngine.Color _colour, in float _power, in bool _changeGamma)
        {
            if (_changeGamma)
            {
                return new UnityEngine.Color(
                    Mathf.Pow(_colour.r, 1f / _power),
                    Mathf.Pow(_colour.g, 1f / _power),
                    Mathf.Pow(_colour.b, 1f / _power),
                    _colour.a
                );
            }

            return new UnityEngine.Color(
                Mathf.Pow(_colour.r, _power),
                Mathf.Pow(_colour.g, _power),
                Mathf.Pow(_colour.b, _power),
                Mathf.Pow(_colour.a, _power)
            );
        }
        public static UnityEngine.Color32 Pow(in Color32 _colour32, in float _power, in bool _changeGamma)
        {
            const float FACTOR = 255f;
            const int MIN = 0;
            const int MAX = 255;

            float power = (_changeGamma) ? 1f / _power : _power;

            byte r = (byte)(Mathf.Clamp(Mathf.RoundToInt(Mathf.Pow(_colour32.r / FACTOR, power) * FACTOR), MIN, MAX));
            byte g = (byte)(Mathf.Clamp(Mathf.RoundToInt(Mathf.Pow(_colour32.g / FACTOR, power) * FACTOR), MIN, MAX));
            byte b = (byte)(Mathf.Clamp(Mathf.RoundToInt(Mathf.Pow(_colour32.b / FACTOR, power) * FACTOR), MIN, MAX));
            byte a =
                (_changeGamma)
                ? _colour32.a
                : (byte)Mathf.Clamp(Mathf.RoundToInt(Mathf.Pow(_colour32.a / FACTOR, power) * FACTOR), MIN, MAX);

            return new Color32(r, g, b, a);
        }
        public static UnityEngine.Quaternion Pow(in UnityEngine.Quaternion _quaternion, in float _power)
        {
            float norm = Mathf.Sqrt(
                  _quaternion.x * _quaternion.x
                + _quaternion.y * _quaternion.y
                + _quaternion.z * _quaternion.z
                + _quaternion.w * _quaternion.w
            );

            if (norm < 1e-6f)
            {
                return UnityEngine.Quaternion.identity;
            }


            float logNorm = Mathf.Log(norm);
            float scaledLogNorm = _power * logNorm;
            float newNorm = Mathf.Exp(scaledLogNorm);


            UnityEngine.Quaternion unit = new UnityEngine.Quaternion(_quaternion.x / norm, _quaternion.y / norm, _quaternion.z / norm, _quaternion.w / norm);


            UnityEngine.Quaternion logQ = Log(unit);
            UnityEngine.Quaternion scaled = new UnityEngine.Quaternion(logQ.x * _power, logQ.y * _power, logQ.z * _power, 0f);
            UnityEngine.Quaternion result = Exp(scaled);


            return new UnityEngine.Quaternion(result.x * newNorm, result.y * newNorm, result.z * newNorm, result.w * newNorm);
        }
        public static System.Numerics.Matrix3x2 Pow(in System.Numerics.Matrix3x2 _matrix3x2, in float _power)
        {
            return new System.Numerics.Matrix3x2(
                Mathf.Pow(_matrix3x2.M11, _power), Mathf.Pow(_matrix3x2.M12, _power),
                Mathf.Pow(_matrix3x2.M21, _power), Mathf.Pow(_matrix3x2.M22, _power),
                Mathf.Pow(_matrix3x2.M31, _power), Mathf.Pow(_matrix3x2.M32, _power)
            );
        }
        public static UnityEngine.Matrix4x4 Pow(in UnityEngine.Matrix4x4 _matrix4x4, in float _power)
        {
            return new UnityEngine.Matrix4x4(
                new UnityEngine.Vector4(Mathf.Pow(_matrix4x4.m00, _power), Mathf.Pow(_matrix4x4.m01, _power), Mathf.Pow(_matrix4x4.m02, _power), Mathf.Pow(_matrix4x4.m03, _power)),
                new UnityEngine.Vector4(Mathf.Pow(_matrix4x4.m10, _power), Mathf.Pow(_matrix4x4.m11, _power), Mathf.Pow(_matrix4x4.m12, _power), Mathf.Pow(_matrix4x4.m13, _power)),
                new UnityEngine.Vector4(Mathf.Pow(_matrix4x4.m20, _power), Mathf.Pow(_matrix4x4.m21, _power), Mathf.Pow(_matrix4x4.m22, _power), Mathf.Pow(_matrix4x4.m23, _power)),
                new UnityEngine.Vector4(Mathf.Pow(_matrix4x4.m30, _power), Mathf.Pow(_matrix4x4.m31, _power), Mathf.Pow(_matrix4x4.m32, _power), Mathf.Pow(_matrix4x4.m33, _power))
            );
        }
        #endregion

        #region Log
        public static UnityEngine.Vector2 Log(in UnityEngine.Vector2 _vector2)
        {
            return new UnityEngine.Vector2(
                Mathf.Log(_vector2.x),
                Mathf.Log(_vector2.y)
            );
        }
        public static UnityEngine.Vector3 Log(in UnityEngine.Vector3 _vector3)
        {
            return new UnityEngine.Vector3(
                Mathf.Log(_vector3.x),
                Mathf.Log(_vector3.y),
                Mathf.Log(_vector3.z)
            );
        }
        public static UnityEngine.Vector4 Log(in UnityEngine.Vector4 _vector4)
        {
            return new UnityEngine.Vector4(
                Mathf.Log(_vector4.x),
                Mathf.Log(_vector4.y),
                Mathf.Log(_vector4.z),
                Mathf.Log(_vector4.w)
            );
        }
        public static UnityEngine.Color Log(in UnityEngine.Color _colour, in bool _logAlpha)
        {
            return new UnityEngine.Color(
                Mathf.Log(_colour.r),
                Mathf.Log(_colour.g),
                Mathf.Log(_colour.b),
                (_logAlpha)
                    ? Mathf.Log(_colour.a)
                    : _colour.a
            );
        }
        public static UnityEngine.Quaternion Log(UnityEngine.Quaternion _quaternion)
        {
            float acosQ = Mathf.Acos(_quaternion.w);
            float sinAcosQ = Mathf.Sin(acosQ);

            if (Mathf.Abs(sinAcosQ) < 1e-6f)
            {
                return new UnityEngine.Quaternion(0f, 0f, 0f, 0f);
            }

            float coeff = acosQ / sinAcosQ;

            return new UnityEngine.Quaternion(_quaternion.x * coeff, _quaternion.y * coeff, _quaternion.z * coeff, 0f);
        }
        #endregion

        #region Log10
        public static UnityEngine.Vector2 Log10(in UnityEngine.Vector2 _vector2)
        {
            return new UnityEngine.Vector2(
                Mathf.Log10(_vector2.x),
                Mathf.Log10(_vector2.y)
            );
        }
        public static UnityEngine.Vector3 Log10(in UnityEngine.Vector3 _vector3)
        {
            return new UnityEngine.Vector3(
                Mathf.Log10(_vector3.x),
                Mathf.Log10(_vector3.y),
                Mathf.Log10(_vector3.z)
            );
        }
        public static UnityEngine.Vector4 Log10(in UnityEngine.Vector4 _vector4)
        {
            return new UnityEngine.Vector4(
                Mathf.Log10(_vector4.x),
                Mathf.Log10(_vector4.y),
                Mathf.Log10(_vector4.z),
                Mathf.Log10(_vector4.w)
            );
        }
        public static UnityEngine.Color Log10(in UnityEngine.Color _colour, in bool _log10Alpha)
        {
            return new UnityEngine.Color(
                Mathf.Log10(_colour.r),
                Mathf.Log10(_colour.g),
                Mathf.Log10(_colour.b),
                (_log10Alpha)
                    ? Mathf.Log10(_colour.a)
                    : _colour.a
            );
        }
        public static UnityEngine.Quaternion Log10(UnityEngine.Quaternion _quaternion)
        {
            UnityEngine.Quaternion logQ = Log(_quaternion);
            float invLog10 = 1f / Mathf.Log(10f);

            return new UnityEngine.Quaternion(
                logQ.x * invLog10,
                logQ.y * invLog10,
                logQ.z * invLog10,
                logQ.w * invLog10
            );
        }
        #endregion

        #region Exp
        public static UnityEngine.Vector2 Exp(in UnityEngine.Vector2 _vector2)
        {
            return new UnityEngine.Vector2(
                Mathf.Exp(_vector2.x),
                Mathf.Exp(_vector2.y)
            );
        }
        public static UnityEngine.Vector3 Exp(in UnityEngine.Vector3 _vector3)
        {
            return new UnityEngine.Vector3(
                Mathf.Exp(_vector3.x),
                Mathf.Exp(_vector3.y),
                Mathf.Exp(_vector3.z)
            );
        }
        public static UnityEngine.Vector4 Exp(in UnityEngine.Vector4 _vector4)
        {
            return new UnityEngine.Vector4(
                Mathf.Exp(_vector4.x),
                Mathf.Exp(_vector4.y),
                Mathf.Exp(_vector4.z),
                Mathf.Exp(_vector4.w)
            );
        }
        public static UnityEngine.Color Exp(in UnityEngine.Color _colour, in bool _expAlpha)
        {
            return new UnityEngine.Color(
                Mathf.Exp(_colour.r),
                Mathf.Exp(_colour.g),
                Mathf.Exp(_colour.b),
                (_expAlpha)
                    ? Mathf.Exp(_colour.a)
                    : _colour.a
            );
        }
        public static UnityEngine.Quaternion Exp(UnityEngine.Quaternion _quaternion)
        {
            UnityEngine.Vector3 vec = new UnityEngine.Vector3(_quaternion.x, _quaternion.y, _quaternion.z);
            float theta = vec.magnitude;
            float cosTheta = Mathf.Cos(theta);
            float sinTheta = Mathf.Sin(theta);

            if (theta > 1e-6f)
            {
                UnityEngine.Vector3 axis = vec / theta;
                return new UnityEngine.Quaternion(axis.x * sinTheta, axis.y * sinTheta, axis.z * sinTheta, cosTheta);
            }

            return new UnityEngine.Quaternion(_quaternion.x, _quaternion.y, _quaternion.z, cosTheta);
        }
        #endregion

        #region Epsilon test
        public static bool EpsilonTestIn(in int _value, in int _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return (_value >= -_epsilon && _value <= _epsilon);
            }

            return (_value > -_epsilon && _value < _epsilon);
        }
        public static bool EpsilonTestOut(in int _value, in int _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return (_value <= -_epsilon || _value >= _epsilon);
            }

            return (_value < -_epsilon || _value > _epsilon);
        }

        public static bool EpsilonTestIn(in float _value, in float _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return (_value >= -_epsilon && _value <= _epsilon);
            }

            return (_value > -_epsilon && _value < _epsilon);
        }
        public static bool EpsilonTestOut(in float _value, in float _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return (_value <= -_epsilon || _value >= _epsilon);
            }

            return (_value < -_epsilon || _value > _epsilon);
        }

        public static bool EpsilonTestIn(in UnityEngine.Vector2 _value, in UnityEngine.Vector2 _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x >= -_epsilon.x && _value.x <= _epsilon.x) &&
                    (_value.y >= -_epsilon.y && _value.y <= _epsilon.y);
            }

            return
                    (_value.x > -_epsilon.x && _value.x < _epsilon.x) &&
                    (_value.y > -_epsilon.y && _value.y < _epsilon.y);
        }
        public static bool EpsilonTestOut(in UnityEngine.Vector2 _value, in UnityEngine.Vector2 _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x <= -_epsilon.x && _value.x >= _epsilon.x) &&
                    (_value.y <= -_epsilon.y && _value.y >= _epsilon.y);
            }

            return
                    (_value.x < -_epsilon.x && _value.x > _epsilon.x) &&
                    (_value.y < -_epsilon.y && _value.y > _epsilon.y);
        }

        public static bool EpsilonTestIn(in UnityEngine.Vector2Int _value, in UnityEngine.Vector2Int _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x >= -_epsilon.x && _value.x <= _epsilon.x) &&
                    (_value.y >= -_epsilon.y && _value.y <= _epsilon.y);
            }

            return
                    (_value.x > -_epsilon.x && _value.x < _epsilon.x) &&
                    (_value.y > -_epsilon.y && _value.y < _epsilon.y);
        }
        public static bool EpsilonTestOut(in UnityEngine.Vector2Int _value, in UnityEngine.Vector2Int _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x <= -_epsilon.x && _value.x >= _epsilon.x) &&
                    (_value.y <= -_epsilon.y && _value.y >= _epsilon.y);
            }

            return
                    (_value.x < -_epsilon.x && _value.x > _epsilon.x) &&
                    (_value.y < -_epsilon.y && _value.y > _epsilon.y);
        }

        public static bool EpsilonTestIn(in UnityEngine.Vector3 _value, in UnityEngine.Vector3 _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x >= -_epsilon.x && _value.x <= _epsilon.x) &&
                    (_value.y >= -_epsilon.y && _value.y <= _epsilon.y) &&
                    (_value.z >= -_epsilon.z && _value.z <= _epsilon.z);
            }

            return
                    (_value.x > -_epsilon.x && _value.x < _epsilon.x) &&
                    (_value.y > -_epsilon.y && _value.y < _epsilon.y) &&
                    (_value.z > -_epsilon.z && _value.z < _epsilon.z);
        }
        public static bool EpsilonTestOut(in UnityEngine.Vector3 _value, in UnityEngine.Vector3 _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x <= -_epsilon.x && _value.x >= _epsilon.x) &&
                    (_value.y <= -_epsilon.y && _value.y >= _epsilon.y) &&
                    (_value.z <= -_epsilon.z && _value.z >= _epsilon.z);
            }

            return
                    (_value.x < -_epsilon.x && _value.x > _epsilon.x) &&
                    (_value.y < -_epsilon.y && _value.y > _epsilon.y) &&
                    (_value.z < -_epsilon.z && _value.z > _epsilon.z);
        }

        public static bool EpsilonTestIn(in UnityEngine.Vector3Int _value, in UnityEngine.Vector3Int _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x >= -_epsilon.x && _value.x <= _epsilon.x) &&
                    (_value.y >= -_epsilon.y && _value.y <= _epsilon.y) &&
                    (_value.z >= -_epsilon.z && _value.z <= _epsilon.z);
            }

            return
                    (_value.x > -_epsilon.x && _value.x < _epsilon.x) &&
                    (_value.y > -_epsilon.y && _value.y < _epsilon.y) &&
                    (_value.z > -_epsilon.z && _value.z < _epsilon.z);
        }
        public static bool EpsilonTestOut(in UnityEngine.Vector3Int _value, in UnityEngine.Vector3Int _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x <= -_epsilon.x && _value.x >= _epsilon.x) &&
                    (_value.y <= -_epsilon.y && _value.y >= _epsilon.y) &&
                    (_value.z <= -_epsilon.z && _value.z >= _epsilon.z);
            }

            return
                    (_value.x < -_epsilon.x && _value.x > _epsilon.x) &&
                    (_value.y < -_epsilon.y && _value.y > _epsilon.y) &&
                    (_value.z < -_epsilon.z && _value.z > _epsilon.z);
        }

        public static bool EpsilonTestIn(in UnityEngine.Vector4 _value, in UnityEngine.Vector4 _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x >= -_epsilon.x && _value.x <= _epsilon.x) &&
                    (_value.y >= -_epsilon.y && _value.y <= _epsilon.y) &&
                    (_value.z >= -_epsilon.z && _value.z <= _epsilon.z) &&
                    (_value.w >= -_epsilon.w && _value.w <= _epsilon.w);
            }

            return
                    (_value.x > -_epsilon.x && _value.x < _epsilon.x) &&
                    (_value.y > -_epsilon.y && _value.y < _epsilon.y) &&
                    (_value.z > -_epsilon.z && _value.z < _epsilon.z) &&
                    (_value.w > -_epsilon.w && _value.w < _epsilon.w);
        }
        public static bool EpsilonTestOut(in UnityEngine.Vector4 _value, in UnityEngine.Vector4 _epsilon, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.x <= -_epsilon.x && _value.x >= _epsilon.x) &&
                    (_value.y <= -_epsilon.y && _value.y >= _epsilon.y) &&
                    (_value.z <= -_epsilon.z && _value.z >= _epsilon.z) &&
                    (_value.w <= -_epsilon.w && _value.w >= _epsilon.w);
            }

            return
                    (_value.x < -_epsilon.x && _value.x > _epsilon.x) &&
                    (_value.y < -_epsilon.y && _value.y > _epsilon.y) &&
                    (_value.z < -_epsilon.z && _value.z > _epsilon.z) &&
                    (_value.w < -_epsilon.w && _value.w > _epsilon.w);
        }

        public static bool EpsilonTestIn(in UnityEngine.Color _value, in UnityEngine.Color _epsilon, in bool _testAlpha = true, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.r >= -_epsilon.r && _value.r <= _epsilon.r) &&
                    (_value.g >= -_epsilon.g && _value.g <= _epsilon.g) &&
                    (_value.b >= -_epsilon.b && _value.b <= _epsilon.b) &&
                    (_testAlpha)
                        ? (_value.a >= -_epsilon.a && _value.a <= _epsilon.a)
                        : true;
            }

            return
                    (_value.r > -_epsilon.r && _value.r < _epsilon.r) &&
                    (_value.g > -_epsilon.g && _value.g < _epsilon.g) &&
                    (_value.b > -_epsilon.b && _value.b < _epsilon.b) &&
                    (_testAlpha)
                        ? (_value.a > -_epsilon.a && _value.a < _epsilon.a)
                        : true;
        }
        public static bool EpsilonTestOut(in UnityEngine.Color _value, in UnityEngine.Color _epsilon, in bool _testAlpha = true, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.r <= -_epsilon.r && _value.r >= _epsilon.r) &&
                    (_value.g <= -_epsilon.g && _value.g >= _epsilon.g) &&
                    (_value.b <= -_epsilon.b && _value.b >= _epsilon.b) &&
                    (_testAlpha)
                        ? (_value.a <= -_epsilon.a && _value.a >= _epsilon.a)
                        : true;
            }

            return
                    (_value.r < -_epsilon.r && _value.r > _epsilon.r) &&
                    (_value.g < -_epsilon.g && _value.g > _epsilon.g) &&
                    (_value.b < -_epsilon.b && _value.b > _epsilon.b) &&
                    (_testAlpha)
                        ? (_value.a < -_epsilon.a && _value.a > _epsilon.a)
                        : true;
        }

        public static bool EpsilonTestIn(in UnityEngine.Color32 _value, in UnityEngine.Color32 _epsilon, in bool _testAlpha = true, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.r >= -_epsilon.r && _value.r <= _epsilon.r) &&
                    (_value.g >= -_epsilon.g && _value.g <= _epsilon.g) &&
                    (_value.b >= -_epsilon.b && _value.b <= _epsilon.b) &&
                    (_testAlpha)
                        ? (_value.a >= -_epsilon.a && _value.a <= _epsilon.a)
                        : true;
            }

            return
                    (_value.r > -_epsilon.r && _value.r < _epsilon.r) &&
                    (_value.g > -_epsilon.g && _value.g < _epsilon.g) &&
                    (_value.b > -_epsilon.b && _value.b < _epsilon.b) &&
                    (_testAlpha)
                        ? (_value.a > -_epsilon.a && _value.a < _epsilon.a)
                        : true;
        }
        public static bool EpsilonTestOut(in UnityEngine.Color32 _value, in UnityEngine.Color32 _epsilon, in bool _testAlpha = true, in bool _inclusive = true)
        {
            if (_inclusive)
            {
                return
                    (_value.r <= -_epsilon.r && _value.r >= _epsilon.r) &&
                    (_value.g <= -_epsilon.g && _value.g >= _epsilon.g) &&
                    (_value.b <= -_epsilon.b && _value.b >= _epsilon.b) &&
                    (_testAlpha)
                        ? (_value.a <= -_epsilon.a && _value.a >= _epsilon.a)
                        : true;
            }

            return
                    (_value.r < -_epsilon.r && _value.r > _epsilon.r) &&
                    (_value.g < -_epsilon.g && _value.g > _epsilon.g) &&
                    (_value.b < -_epsilon.b && _value.b > _epsilon.b) &&
                    (_testAlpha)
                        ? (_value.a < -_epsilon.a && _value.a > _epsilon.a)
                        : true;
        }
        #endregion

        #region Comparison methods
        public static bool Greater(in UnityEngine.Vector2 _a, in UnityEngine.Vector2 _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x >= _b.x
                && _a.y >= _b.y);
            }

            return
                (_a.x > _b.x
                && _a.y > _b.y);
        }
        public static bool Less(in UnityEngine.Vector2 _a, in UnityEngine.Vector2 _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x <= _b.x
                && _a.y <= _b.y);
            }

            return
                (_a.x < _b.x
                && _a.y < _b.y);
        }

        public static bool Greater(in UnityEngine.Vector2Int _a, in UnityEngine.Vector2Int _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x >= _b.x
                && _a.y >= _b.y);
            }

            return
                (_a.x > _b.x
                && _a.y > _b.y);
        }
        public static bool Less(in UnityEngine.Vector2Int _a, in UnityEngine.Vector2Int _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x <= _b.x
                && _a.y <= _b.y);
            }

            return
                (_a.x < _b.x
                && _a.y < _b.y);
        }

        public static bool Greater(in UnityEngine.Vector3 _a, in UnityEngine.Vector3 _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x >= _b.x
                && _a.y >= _b.y
                && _a.z >= _b.z);
            }

            return
                (_a.x > _b.x
                && _a.y > _b.y
                && _a.z > _b.z);
        }
        public static bool Less(in UnityEngine.Vector3 _a, in UnityEngine.Vector3 _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x <= _b.x
                && _a.y <= _b.y
                && _a.z <= _b.z);
            }

            return
                (_a.x < _b.x
                && _a.y < _b.y
                && _a.z < _b.z);
        }

        public static bool Greater(in UnityEngine.Vector3Int _a, in UnityEngine.Vector3Int _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x >= _b.x
                && _a.y >= _b.y
                && _a.z >= _b.z);
            }

            return
                (_a.x > _b.x
                && _a.y > _b.y
                && _a.z > _b.z);
        }
        public static bool Less(in UnityEngine.Vector3Int _a, in UnityEngine.Vector3Int _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x <= _b.x
                && _a.y <= _b.y
                && _a.z <= _b.z);
            }

            return
                (_a.x < _b.x
                && _a.y < _b.y
                && _a.z < _b.z);
        }

        public static bool Greater(in UnityEngine.Vector4 _a, in UnityEngine.Vector4 _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x >= _b.x
                && _a.y >= _b.y
                && _a.z >= _b.z
                && _a.w >= _b.w);
            }

            return
                (_a.x > _b.x
                && _a.y > _b.y
                && _a.z > _b.z
                && _a.w > _b.w);
        }
        public static bool Less(in UnityEngine.Vector4 _a, in UnityEngine.Vector4 _b, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                return
                (_a.x <= _b.x
                && _a.y <= _b.y
                && _a.z <= _b.z
                && _a.w <= _b.w);
            }

            return
                (_a.x < _b.x
                && _a.y < _b.y
                && _a.z < _b.z
                && _a.w < _b.w);
        }

        public static bool Greater(in UnityEngine.Color _a, in UnityEngine.Color _b, in bool _testAlpha = false, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                if (_testAlpha)
                {
                    return
                        (_a.r >= _b.r
                        && _a.g >= _b.g
                        && _a.b >= _b.b
                        && _a.a >= _b.a);
                }

                return
                    (_a.r >= _b.r
                    && _a.g >= _b.g
                    && _a.b >= _b.b);
            }

            if (_testAlpha)
            {
                return
                    (_a.r > _b.r
                    && _a.g > _b.g
                    && _a.b > _b.b
                    && _a.a > _b.a);
            }

            return
                (_a.r > _b.r
                && _a.g > _b.g
                && _a.b > _b.b);
        }
        public static bool Less(in UnityEngine.Color _a, in UnityEngine.Color _b, in bool _testAlpha = false, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                if (_testAlpha)
                {
                    return
                        (_a.r <= _b.r
                        && _a.g <= _b.g
                        && _a.b <= _b.b
                        && _a.a <= _b.a);
                }

                return
                    (_a.r <= _b.r
                    && _a.g <= _b.g
                    && _a.b <= _b.b);
            }

            if (_testAlpha)
            {
                return
                    (_a.r < _b.r
                    && _a.g < _b.g
                    && _a.b < _b.b
                    && _a.a < _b.a);
            }

            return
                (_a.r < _b.r
                && _a.g < _b.g
                && _a.b < _b.b);
        }

        public static bool Greater(in UnityEngine.Color32 _a, in UnityEngine.Color32 _b, in bool _testAlpha = false, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                if (_testAlpha)
                {
                    return
                        (_a.r >= _b.r
                        && _a.g >= _b.g
                        && _a.b >= _b.b
                        && _a.a >= _b.a);
                }

                return
                    (_a.r >= _b.r
                    && _a.g >= _b.g
                    && _a.b >= _b.b);
            }

            if (_testAlpha)
            {
                return
                    (_a.r > _b.r
                    && _a.g > _b.g
                    && _a.b > _b.b
                    && _a.a > _b.a);
            }

            return
                (_a.r > _b.r
                && _a.g > _b.g
                && _a.b > _b.b);
        }
        public static bool Less(in UnityEngine.Color32 _a, in UnityEngine.Color32 _b, in bool _testAlpha = false, in bool _testEquality = true)
        {
            if (_testEquality)
            {
                if (_testAlpha)
                {
                    return
                        (_a.r <= _b.r
                        && _a.g <= _b.g
                        && _a.b <= _b.b
                        && _a.a <= _b.a);
                }

                return
                    (_a.r <= _b.r
                    && _a.g <= _b.g
                    && _a.b <= _b.b);
            }

            if (_testAlpha)
            {
                return
                    (_a.r < _b.r
                    && _a.g < _b.g
                    && _a.b < _b.b
                    && _a.a < _b.a);
            }

            return
                (_a.r < _b.r
                && _a.g < _b.g
                && _a.b < _b.b);
        }
        #endregion
    }
}