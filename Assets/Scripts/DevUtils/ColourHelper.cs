using System;
using UnityEngine;

namespace Antony
{
    public class ColourHelper
    {
        // Common grayscale values of the human eyes
        public static readonly Color LumaWeights =
            new Color(
                0.299f,
                0.587f,
                0.114f
            );

        public static Color FromHex(string _hexValue)
        {
            (int r, int g, int b) = HexToRGB(_hexValue);

            return new Color(r / 255f, g / 255f, b / 255f);
        }

        public static string RGBToHex(int _r, int _g, int _b)
        {
            _r = Mathf.Clamp(_r, 0, 255);
            _g = Mathf.Clamp(_g, 0, 255);
            _b = Mathf.Clamp(_b, 0, 255);

            return $"{_r:X2}{_g:X2}{_b:X2}";
        }

        public static (int r, int g, int b) HexToRGB(string _hexValue)
        {
            if (string.IsNullOrWhiteSpace(_hexValue))
            {
                throw new ArgumentException("Hex string is null or empty");
            }

            _hexValue = _hexValue.TrimStart('#');

            if (_hexValue.Length != 6)
            {
                throw new ArgumentException("Hex string must be 6 characters long");
            }

            int r = Convert.ToInt32(_hexValue.Substring(0, 2), 16);
            int g = Convert.ToInt32(_hexValue.Substring(2, 2), 16);
            int b = Convert.ToInt32(_hexValue.Substring(4, 2), 16);

            return (r, g, b);
        }

        public static Color RandomRGB0255(int _minValue = 0, int _maxValue = 255)
        {
            _maxValue++;

            _minValue = Mathf.Clamp(_minValue, 0, 127);
            _maxValue = Mathf.Clamp(_maxValue, 128, 256);

            return new Color(
                UnityEngine.Random.Range(_minValue, _maxValue) / 255f,
                UnityEngine.Random.Range(_minValue, _maxValue) / 255f,
                UnityEngine.Random.Range(_minValue, _maxValue) / 255f
            );
        }

        public static Color RandomRGBA0255(int _minValue = 0, int _maxValue = 255)
        {
            Color randRGBA = RandomRGB0255(_minValue, _maxValue);
            int alphaMax = Mathf.Clamp(_maxValue + 1, 128, 256);
            int alphaMin = Mathf.Clamp(_minValue, 0, 127);
            
            randRGBA.a = UnityEngine.Random.Range(alphaMin, alphaMax) / 255f;
            return randRGBA;
        }

        public static Color RandomRGB(float _minValue = 0f, float _maxValue = 1f)
        {
            _minValue = Mathf.Clamp(_minValue, 0f, 0.49f);
            _maxValue = Mathf.Clamp(_maxValue, 0.5f, 1f);

            return new Color(
                UnityEngine.Random.Range(_minValue, _maxValue),
                UnityEngine.Random.Range(_minValue, _maxValue),
                UnityEngine.Random.Range(_minValue, _maxValue)
            );
        }
        public static Color RandomRGBA(float _minValue = 0f, float _maxValue = 1f)
        {
            _minValue = Mathf.Clamp(_minValue, 0f, 0.49f);
            _maxValue = Mathf.Clamp(_maxValue, 0.5f, 1f);

            Color randRGBA = RandomRGB(_minValue, _maxValue);
            randRGBA.a = UnityEngine.Random.Range(_minValue, _maxValue);

            return randRGBA;
        }

        public static Color BWGradient(int _gradientValue = -1, int _alphaValue = -1)
        {
            if (_gradientValue < 0)
            {
                float randomValue = UnityEngine.Random.Range(0, 256) / 255f;

                return new Color(
                    randomValue,
                    randomValue,
                    randomValue,
                    (_alphaValue < 0)
                        ? randomValue
                        : _alphaValue / 255f
                );
            }

            float gradValue01 = _gradientValue / 255f;

            return new Color(
                gradValue01,
                gradValue01,
                gradValue01,
                (_alphaValue < 0)
                    ? gradValue01
                    : _alphaValue / 255f
            );
        }

        public static Color Divide(Color _a, Color _b, bool _divideAlpha = false)
        {
            if (Mathf.Approximately(_b.r, 0f) ||
                Mathf.Approximately(_b.g, 0f) ||
                Mathf.Approximately(_b.b, 0f) ||
                (_divideAlpha && Mathf.Approximately(_b.a, 0f)))
            {
                Debug.LogWarning(
                    "[<color=green>ColourHelper</color>" +
                    ".<color=yellow>Divide</color>] " +
                    "<color=white>Warning: Attempting to divide by 0.</color>"
                );
                return _a;
            }

            return new Color(
                _a.r / _b.r,
                _a.g / _b.g,
                _a.b / _b.b,
                (_divideAlpha)
                    ? _a.a / _b.a
                    : _a.a
            );
        }

        public static Color Modulo(Color _a, Color _b, bool _moduloAlpha = false)
        {
            if (Mathf.Approximately(_b.r, 0f) ||
                Mathf.Approximately(_b.g, 0f) ||
                Mathf.Approximately(_b.b, 0f) ||
                (_moduloAlpha && Mathf.Approximately(_b.a, 0f)))
            {
                Debug.LogWarning(
                    "[<color=green>ColourHelper</color>" +
                    ".<color=yellow>Modulo</color>] " +
                    "<color=white>Warning: Attempting to modulo by 0.</color>"
                );
                return _a;
            }

            return new Color(
                _a.r % _b.r,
                _a.g % _b.g,
                _a.b % _b.b,
                (_moduloAlpha)
                    ? _a.a % _b.a
                    : _a.a
            );
        }

        public static Color Inverse(Color _colour, bool _inverseAlpha = false)
        {
            return new Color(
                1f - _colour.r,
                1f - _colour.g,
                1f - _colour.b,
                (_inverseAlpha)
                    ? 1f - _colour.a
                    : _colour.a
            );
        }

        public static (float r, float g, float b) GetValue01(int _r, int _g, int _b)
        {
            return (_r / 255f, _g / 255f, _b / 255f);
        }

        public static (float r, float g, float b) GetValue0255(float _r, float _g, float _b)
        {
            return (_r * 255f, _g * 255f, _b * 255f);
        }


        public static void MakeGrayscale(Color _colour)
        {
            _colour *= LumaWeights;
        }
        public static Color GetGrayScale(Color _colour)
        {
            return _colour * LumaWeights;
        }
    }
}