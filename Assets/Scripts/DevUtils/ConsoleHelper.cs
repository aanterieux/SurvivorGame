using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TextColour
{
    NONE,
    AQUA,
    BLACK,
    BLUE,
    BROWN,
    CYAN,
    DARKBLUE,
    FUCHSIA,
    GREEN,
    GREY,
    LIGHTBLUE,
    LIME,
    MAGENTA,
    MAROON,
    NAVY,
    OLIVE,
    ORANGE,
    PURPLE,
    RED,
    SILVER,
    TEAL,
    WHITE,
    YELLOW,

    COLOUR_NB
}

public enum TextEffect
{
    NONE,
    BOLD,
    ITALIC,
    UNDERLINED,
    STRIKETHROUGH,
    SIZE,
    ALL,

    EFFECT_NB
}

public class ConsoleHelper
{
    #region Constants
    #region private
    private const int MINIMUM_TEXT_SIZE = 1;
    private const int MAXIMUM_TEXT_SIZE = 100;
    #endregion

    #region public
    public const int UNITY_TEXT_SIZE = 12;
    #endregion
    #endregion

    #region Members
    private static string[] effectTags = new string[] {
        "b", "i", "u", "s", "size"
    };
    #endregion

    #region Methods
    #region Print in colour
    #region Log
    /// <summary>
    /// UnityEngine.Debug.Log _message in _colour
    /// </summary>
    /// <param name="_colour">The colour you want _message to be</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <returns></returns>
    public static void LogColour(in TextColour _colour, in object _message)
    {
        if (_colour == TextColour.NONE)
        {
            Debug.Log(_message);
            return;
        }

        Mathf.Clamp((int)(_colour), 0, (int)(TextColour.COLOUR_NB));

        UnityEngine.Debug.Log("<color=" + _colour.ToString() + ">" + _message + "</color>");
    }
    /// <summary>
    /// UnityEngine.Debug.Log _message in _colour
    /// </summary>
    /// <param name="_colourHexValue">The hexadecimal value of the colour you want _message to be</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <returns></returns>
    public static void LogColour(in int _colourHexValue, in object _message)
    {
        Mathf.Clamp(_colourHexValue, 0x000000, 0xFFFFFF);

        UnityEngine.Debug.Log("<color=#" + _colourHexValue.ToString("X6") + ">" + _message + "</color>");
    }
    #endregion

    #region Warning
    /// <summary>
    /// UnityEngine.Debug.LogWarning _text in _colour
    /// </summary>
    /// <param name="_colour">The colour you want _message to be</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <returns></returns>
    public static void WarningColour(in TextColour _colour, in object _message)
    {
        if (_colour == TextColour.NONE)
        {
            Debug.LogWarning(_message);
            return;
        }

        Mathf.Clamp((int)(_colour), 0, (int)(TextColour.COLOUR_NB));

        UnityEngine.Debug.LogWarning("<color=" + _colour.ToString() + ">" + _message + "</color>");
    }
    /// <summary>
    /// UnityEngine.Debug.Log _message in _colour
    /// </summary>
    /// <param name="_colourHexValue">The hexadecimal value of the colour you want _message to be</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <returns></returns>
    public static void WarningColour(in int _colourHexValue, in object _message)
    {
        Mathf.Clamp(_colourHexValue, 0x000000, 0xFFFFFF);

        UnityEngine.Debug.LogWarning("<color=#" + _colourHexValue.ToString("X6") + ">" + _message + "</color>");
    }
    #endregion

    #region Error
    /// <summary>
    /// UnityEngine.Debug.LogError _text in _colour
    /// </summary>
    /// <param name="_colour">The colour you want _message to be</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <returns></returns>
    public static void ErrorColour(in TextColour _colour, in object _message)
    {
        if (_colour == TextColour.NONE)
        {
            Debug.LogError(_message);
            return;
        }

        Mathf.Clamp((int)(_colour), 0, (int)(TextColour.COLOUR_NB));

        UnityEngine.Debug.LogError("<color=" + _colour.ToString() + ">" + _message + "</color>");
    }
    /// <summary>
    /// UnityEngine.Debug.Log _message in _colour
    /// </summary>
    /// <param name="_colourHexValue">The hexadecimal value of the colour you want _message to be</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <returns></returns>
    public static void ErrorColour(in int _colourHexValue, in object _message)
    {
        Mathf.Clamp(_colourHexValue, 0x000000, 0xFFFFFF);

        UnityEngine.Debug.LogError("<color=#" + _colourHexValue.ToString("X6") + ">" + _message + "</color>");
    }
    #endregion
    #endregion

    #region Print with effect
    #region Log
    public static void LogEffect(in TextEffect _effect, in object _message, in uint _size = 12u)
    {
        if (_effect == TextEffect.NONE)
        {
            Debug.Log(_message);
            return;
        }

        if (_effect != TextEffect.ALL)
        {
            if (_effect != TextEffect.SIZE)
            {
                Mathf.Clamp((int)(_effect), 0, (int)(TextEffect.EFFECT_NB));
                char effectChar = _effect.ToString().ToLower()[0];

                UnityEngine.Debug.Log("<" + effectChar + ">" + _message + "</" + effectChar + ">");

                return;
            }

            LogSIZE(_size, _message);

            return;
        }

        UnityEngine.Debug.Log("<b><i><u><s><size=" + _size + ">" + _message + "</size></s></u></i></b>");
    }
    public static void LogBold(in object _message)
    {
        UnityEngine.Debug.Log("<b>" + _message + "</b>");
    }
    public static void LogItalic(in object _message)
    {
        UnityEngine.Debug.Log("<i>" + _message + "</i>");
    }
    public static void LogUnderlined(in object _message)
    {
        UnityEngine.Debug.Log("<u>" + _message + "</u>");
    }
    public static void LogStrikethrough(in object _message)
    {
        UnityEngine.Debug.Log("<s>" + _message + "</s>");
    }
    public static void LogSIZE(in uint _size, in object _message)
    {
        UnityEngine.Debug.Log("<size=" + _size + ">" + _message + "</size>");
    }
    public static void LogEffects(in object _message, in uint _size = 12u, params TextEffect[] _effects)
    {
        string[] effects = new string[(int)(TextEffect.EFFECT_NB) - 1];
        int differentEffectCount = 1;
        char effectChar = (char)(0);
        bool canSkip = false;

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i] = " ";
        }

        for (int i = 0; i < _effects.Length; i++)
        {
            if (_effects[i] == TextEffect.ALL)
            {
                canSkip = true;
                break;
            }

            if (_effects[i] != TextEffect.EFFECT_NB)
            {
                if (i == 0)
                {
                    effectChar = _effects[i].ToString().ToLower()[0];
                    effects[i] = effectChar.ToString();
                }
                else if (_effects[i] != _effects[i - 1])
                {
                    if (_effects[i] != TextEffect.SIZE)
                    {
                        effectChar = _effects[i].ToString().ToLower()[0];
                        effects[i] = effectChar.ToString();
                    }
                    else
                    {
                        effects[i] = TextEffect.SIZE.ToString().ToLower();
                    }

                    differentEffectCount++;
                }

                if (differentEffectCount == 5)
                {
                    break;
                }
            }
        }

        if (!canSkip)
        {
            List<string> effectList = new List<string>();

            for (int i = 0; i < effects.Length; i++)
            {
                if (effects[i] != " ")
                {
                    effectList.Add(effects[i]);
                }
            }

            string fxBeg = "";
            string fxEnd = "";

            for (int i = 0; i < effectList.Count; i++)
            {
                if (effectList[i] != "SIZE")
                {
                    fxBeg += "<" + effectList[i] + ">";
                }
                else
                {
                    fxBeg += "<size=" + _size + ">";
                }

                fxEnd += "</" + effectList[i] + ">";
            }

            UnityEngine.Debug.Log(fxBeg + _message + fxEnd);

            return;
        }

        UnityEngine.Debug.Log("<b><i><u><s><size=" + _size + ">" + _message + "</size></s></u></i></b>");
    }
    public static void LogEffects(in object _message, in TextEffect[] _effects, in uint _size = 12u)
    {
        bool canSkip = false;
        TextEffect curr = 0;
        string fxBeg = "";
        string fxEnd = "";

        for (int i = 0; i < _effects.Length; i++)
        {
            curr = _effects[i];
            Mathf.Clamp((int)(curr), 0, (int)(TextEffect.EFFECT_NB));


            if (curr == TextEffect.ALL)
            {
                canSkip = true;
                break;
            }

            if (curr != TextEffect.EFFECT_NB)
            {
                if (curr == TextEffect.SIZE)
                {
                    fxBeg += "<size=" + _size + ">";
                    fxEnd += "</size>";
                }
                else
                {
                    string effectCharStr = curr.ToString().ToLower()[0].ToString();

                    fxBeg += "<" + effectCharStr + ">";
                    fxEnd += "</" + effectCharStr + ">";
                }
            }
        }

        if (!canSkip)
        {
            UnityEngine.Debug.Log(fxBeg + _message + fxEnd);
            return;
        }

        UnityEngine.Debug.Log("<b><i><u><s><size=" + _size + ">" + _message + "</size></s></u></i></b>");
    }
    #endregion

    #region Warning
    public static void WarningEffect(in TextEffect _effect, in object _message, in uint _size = 12u)
    {
        if (_effect == TextEffect.NONE)
        {
            Debug.LogWarning(_message);
            return;
        }

        if (_effect != TextEffect.ALL)
        {
            if (_effect != TextEffect.SIZE)
            {
                Mathf.Clamp((int)(_effect), 0, (int)(TextEffect.EFFECT_NB));
                char effectChar = _effect.ToString().ToLower()[0];

                UnityEngine.Debug.LogWarning("<" + effectChar + ">" + _message + "</" + effectChar + ">");

                return;
            }

            WarningSIZE(_size, _message);

            return;
        }

        UnityEngine.Debug.LogWarning("<b><i><u><s><size=" + _size + ">" + _message + "</size></s></u></i></b>");
    }
    public static void WarningBold(in object _message)
    {
        UnityEngine.Debug.LogWarning("<b>" + _message + "</b>");
    }
    public static void WarningItalic(in object _message)
    {
        UnityEngine.Debug.LogWarning("<i>" + _message + "</i>");
    }
    public static void WarningUnderlined(in object _message)
    {
        UnityEngine.Debug.LogWarning("<u>" + _message + "</u>");
    }
    public static void WarningStrikethrough(in object _message)
    {
        UnityEngine.Debug.LogWarning("<s>" + _message + "</s>");
    }
    public static void WarningSIZE(in uint _size, in object _message)
    {
        UnityEngine.Debug.LogWarning("<size=" + _size + ">" + _message + "</size>");
    }
    public static void WarningEffects(in object _message, in uint _size = 12u, params TextEffect[] _effects)
    {
        string[] effects = new string[(int)(TextEffect.EFFECT_NB) - 1];
        int differentEffectCount = 1;
        char effectChar = (char)(0);
        bool canSkip = false;

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i] = " ";
        }

        for (int i = 0; i < _effects.Length; i++)
        {
            if (_effects[i] == TextEffect.ALL)
            {
                canSkip = true;
                break;
            }

            if (_effects[i] != TextEffect.EFFECT_NB)
            {
                if (i == 0)
                {
                    effectChar = _effects[i].ToString().ToLower()[0];
                    effects[i] = effectChar.ToString();
                }
                else if (_effects[i] != _effects[i - 1])
                {
                    if (_effects[i] != TextEffect.SIZE)
                    {
                        effectChar = _effects[i].ToString().ToLower()[0];
                        effects[i] = effectChar.ToString();
                    }
                    else
                    {
                        effects[i] = TextEffect.SIZE.ToString().ToLower();
                    }

                    differentEffectCount++;
                }

                if (differentEffectCount == 5)
                {
                    break;
                }
            }
        }

        if (!canSkip)
        {
            List<string> effectList = new List<string>();

            for (int i = 0; i < effects.Length; i++)
            {
                if (effects[i] != " ")
                {
                    effectList.Add(effects[i]);
                }
            }

            string fxBeg = "";
            string fxEnd = "";

            for (int i = 0; i < effectList.Count; i++)
            {
                if (effectList[i] != "SIZE")
                {
                    fxBeg += "<" + effectList[i] + ">";
                }
                else
                {
                    fxBeg += "<size=" + _size + ">";
                }

                fxEnd += "</" + effectList[i] + ">";
            }

            UnityEngine.Debug.LogWarning(fxBeg + _message + fxEnd);

            return;
        }

        UnityEngine.Debug.LogWarning("<b><i><u><s><size=" + _size + ">" + _message + "</size></s></u></i></b>");
    }
    public static void WarningEffects(in object _message, in TextEffect[] _effects, in uint _size = 12u)
    {
        bool canSkip = false;
        TextEffect curr = 0;
        string fxBeg = "";
        string fxEnd = "";

        for (int i = 0; i < _effects.Length; i++)
        {
            curr = _effects[i];
            Mathf.Clamp((int)(curr), 0, (int)(TextEffect.EFFECT_NB));

            if (curr == TextEffect.ALL)
            {
                canSkip = true;
                break;
            }

            if (curr != TextEffect.EFFECT_NB)
            {
                if (curr == TextEffect.SIZE)
                {
                    fxBeg += "<size=" + _size + ">";
                    fxEnd += "</size>";
                }
                else
                {
                    string effectCharStr = curr.ToString().ToLower()[0].ToString();

                    fxBeg += "<" + effectCharStr + ">";
                    fxEnd += "</" + effectCharStr + ">";
                }
            }
        }

        if (!canSkip)
        {
            UnityEngine.Debug.LogWarning(fxBeg + _message + fxEnd);
            return;
        }

        UnityEngine.Debug.LogWarning("<b><i><u><s><size=" + _size + ">" + _message + "</size></s></u></i></b>");
    }
    #endregion

    #region Error
    public static void ErrorEffect(in TextEffect _effect, in object _message, in uint _size = 12u)
    {
        if (_effect == TextEffect.NONE)
        {
            Debug.LogError(_message);
            return;
        }

        if (_effect != TextEffect.ALL)
        {
            if (_effect != TextEffect.SIZE)
            {
                Mathf.Clamp((int)(_effect), 0, (int)(TextEffect.EFFECT_NB));
                char effectChar = _effect.ToString().ToLower()[0];

                UnityEngine.Debug.LogError("<" + effectChar + ">" + _message + "</" + effectChar + ">");

                return;
            }

            ErrorSIZE(_size, _message);

            return;
        }

        UnityEngine.Debug.LogError("<b><i><u><s><size=" + _size + ">" + _message + "</size></s></u></i></b>");
    }
    public static void ErrorBold(in object _message)
    {
        UnityEngine.Debug.LogError("<b>" + _message + "</b>");
    }
    public static void ErrorItalic(in object _message)
    {
        UnityEngine.Debug.LogError("<i>" + _message + "</i>");
    }
    public static void ErrorUnderlined(in object _message)
    {
        UnityEngine.Debug.LogError("<u>" + _message + "</u>");
    }
    public static void ErrorStrikethrough(in object _message)
    {
        UnityEngine.Debug.LogError("<s>" + _message + "</s>");
    }
    public static void ErrorSIZE(in uint _size, in object _message)
    {
        UnityEngine.Debug.LogError("<size=" + _size + ">" + _message + "</size>");
    }
    public static void ErrorEffects(in object _message, in uint _size = 12u, params TextEffect[] _effects)
    {
        string[] effects = new string[(int)(TextEffect.EFFECT_NB) - 1];
        int differentEffectCount = 1;
        char effectChar = (char)(0);
        bool canSkip = false;

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i] = " ";
        }

        for (int i = 0; i < _effects.Length; i++)
        {
            if (_effects[i] == TextEffect.ALL)
            {
                canSkip = true;
                break;
            }

            if (_effects[i] != TextEffect.EFFECT_NB)
            {
                if (i == 0)
                {
                    effectChar = _effects[i].ToString().ToLower()[0];
                    effects[i] = effectChar.ToString();
                }
                else if (_effects[i] != _effects[i - 1])
                {
                    if (_effects[i] != TextEffect.SIZE)
                    {
                        effectChar = _effects[i].ToString().ToLower()[0];
                        effects[i] = effectChar.ToString();
                    }
                    else
                    {
                        effects[i] = TextEffect.SIZE.ToString().ToLower();
                    }

                    differentEffectCount++;
                }

                if (differentEffectCount == 5)
                {
                    break;
                }
            }
        }

        if (!canSkip)
        {
            List<string> effectList = new List<string>();

            for (int i = 0; i < effects.Length; i++)
            {
                if (effects[i] != " ")
                {
                    effectList.Add(effects[i]);
                }
            }

            string fxBeg = "";
            string fxEnd = "";

            for (int i = 0; i < effectList.Count; i++)
            {
                if (effectList[i] != "SIZE")
                {
                    fxBeg += "<" + effectList[i] + ">";
                }
                else
                {
                    fxBeg += "<size=" + _size + ">";
                }

                fxEnd += "</" + effectList[i] + ">";
            }

            UnityEngine.Debug.LogError(fxBeg + _message + fxEnd);

            return;
        }

        UnityEngine.Debug.LogError("<b><i><u><s><size=" + _size + ">" + _message + "</size></s></u></i></b>");
    }
    public static void ErrorEffects(in object _message, in TextEffect[] _effects, in uint _size = 12u)
    {
        bool canSkip = false;
        TextEffect curr = 0;
        string fxBeg = "";
        string fxEnd = "";

        for (int i = 0; i < _effects.Length; i++)
        {
            curr = _effects[i];
            Mathf.Clamp((int)(curr), 0, (int)(TextEffect.EFFECT_NB));

            if (curr == TextEffect.ALL)
            {
                canSkip = true;
                break;
            }

            if (curr != TextEffect.EFFECT_NB)
            {
                if (curr == TextEffect.SIZE)
                {
                    fxBeg += "<size=" + _size + ">";
                    fxEnd += "</size>";
                }
                else
                {
                    string effectCharStr = curr.ToString().ToLower()[0].ToString();

                    fxBeg += "<" + effectCharStr + ">";
                    fxEnd += "</" + effectCharStr + ">";
                }
            }
        }

        if (!canSkip)
        {
            UnityEngine.Debug.LogError(fxBeg + _message + fxEnd);
            return;
        }

        UnityEngine.Debug.LogError("<b><i><u><s><size=" + _size + ">" + _message + "</size></s></u></i></b>");
    }
    #endregion
    #endregion

    #region Print in colour with effect
    #region Log
    /// <summary>
    /// UnityEngine.Debug.Log _message to the console in _colour and _effect
    /// </summary>
    /// <param name="_colour">The colour you want _message to be</param>
    /// <param name="_effect">The effect you want _message to have</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <param name="_size">The size you want _message to have in the console</param>
    public static void LogColourEffect(in TextColour _colour, in TextEffect _effect, in object _message, int _size = UNITY_TEXT_SIZE)
    {
        // When the user wants to use no colour and no effect
        if (_colour == TextColour.NONE && _effect == TextEffect.NONE)
        {
            Debug.Log(_message);
            return;
        }

        Mathf.Clamp((int)(_colour), 0, (int)(TextColour.COLOUR_NB));
        Mathf.Clamp(_size, MINIMUM_TEXT_SIZE, MAXIMUM_TEXT_SIZE);

        // When the user only wants colour
        if (_effect == TextEffect.NONE)
        {
            Debug.Log("<color=" + _colour.ToString() + ">" + _message + "</color>");
            return;
        }

        string effectStr = effectTags[(int)(_effect) - 1];

        // When the user only wants effect
        if (_colour == TextColour.NONE)
        {
            Debug.Log("<" + effectStr + "><size=" + _size + ">" + _message + "</size></" + effectStr + ">");
            return;
        }

        // When the user wants ALL the effects a once
        if (string.Equals(effectStr, "ALL"))
        {
            Debug.Log("<b><i><u><s><size=" + _size + "><color=" + _colour.ToString() + ">" + _message + "</color></size></s></u></i></b>");
            return;
        }

        Mathf.Clamp((int)(_effect), 0, (int)(TextEffect.EFFECT_NB));

        // Normal case
        Debug.Log("<" + effectStr + "><size=" + _size + "><color=" + _colour.ToString() + ">" + _message + "</color></size></" + effectStr + ">");
    }
    /// <summary>
    /// UnityEngine.Debug.Log _message to the console in _colour and _effect
    /// </summary>
    /// <param name="_colour">The colour you want _message to be</param>
    /// <param name="_effects">The effects you want _message to have</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <param name="_size">The size you want _message to have in the console</param>
    public static void LogColourEffect(in TextColour _colour, in TextEffect[] _effects, in object _message, int _size = UNITY_TEXT_SIZE)
    {
        Mathf.Clamp((int)(_colour), 0, (int)(TextColour.COLOUR_NB));
        Mathf.Clamp(_size, MINIMUM_TEXT_SIZE, MAXIMUM_TEXT_SIZE);

        // When there is no effect
        if (_effects == null || _effects.Length < 1)
        {
            Debug.Log("<color=" + _colour.ToString() + ">" + _message + "</color>");
            return;
        }

        // When the user wants no effect
        if (_effects.Contains(TextEffect.NONE))
        {
            Debug.Log("<color=" + _colour.ToString() + ">" + _message + "</color>");
            return;
        }

        // Make sure all the effects are valid
        for (int i = 0; i < _effects.Length; i++)
        {
            Mathf.Clamp((int)(_effects[i]), 0, (int)(TextEffect.EFFECT_NB));
        }

        // When one of the effects is ALL
        if (_effects.Contains(TextEffect.ALL))
        {
            Mathf.Clamp(_size, MINIMUM_TEXT_SIZE, MAXIMUM_TEXT_SIZE);

            Debug.Log("<b><i><u><s><size=" + _size + "><color=" + _colour.ToString() + ">" + _message + "</color></size></s></u></i></b>");
            return;
        }

        bool canChangeSize = _effects.Contains(TextEffect.SIZE);
        string sizeOn = (canChangeSize) ? "<size=" + _size + ">" : "";
        string sizeOff = (canChangeSize) ? "</size>" : "";
        string colourOn = "";
        string colourOff = "";

        // When there is only 1 effect
        if (_effects.Length == 1)
        {
            colourOn =
                (_colour == TextColour.NONE)
                ? ""
                : "<color=" + _colour.ToString() + ">";
            colourOff =
                (string.Equals(colourOn, ""))
                ? ""
                : "</color>";

            // When the user wants to change text size
            if (canChangeSize)
            {
                Debug.Log(sizeOn + colourOn + _message + colourOff + sizeOff);
                return;
            }

            // When the user doesn't want to change text size
            Debug.Log("<" + effectTags[(int)(_effects[0]) - 1] + ">" + colourOn + _message + colourOff + "</" + effectTags[(int)(_effects[0]) - 1] + ">");
            return;
        }

        // When there are multiple effects

        List<string> effectList = new List<string>();
        effectList.Add("<" + _effects[0].ToString()[0] + ">");
        string allEffectsOn = effectList[0];
        string allEffectsOnCpy = allEffectsOn.Remove(0, 1);
        string allEffectsOff = "</" + allEffectsOnCpy;
        allEffectsOnCpy = "";
        uint differentEffectsCount = 1u;

        for (int i = 0; i < _effects.Length; i++)
        {
            if (i > 0 && _effects[i] != _effects[i - 1])
            {
                effectList.Add("<" + effectTags[i] + ">");
                allEffectsOn += effectList[i];
                allEffectsOnCpy += effectList[i].Remove(0, 1);
                allEffectsOff += "</" + allEffectsOnCpy;
                differentEffectsCount++;

                // If all effect types have been found
                // Exit the loop to avoid unnecessary computation
                if (differentEffectsCount == (int)(TextEffect.EFFECT_NB))
                {
                    break;
                }
            }
        }

        colourOn =
                (_colour == TextColour.NONE)
                ? ""
                : "<color=" + _colour.ToString() + ">";
        colourOff =
            (string.Equals(colourOn, ""))
            ? ""
            : "</color>";

        Debug.Log(allEffectsOn + sizeOn + colourOn + _message + colourOff + sizeOff + allEffectsOff);
    }
    #endregion

    #region Warning
    /// <summary>
    /// UnityEngine.Debug.LogWarning _message to the console in _colour and _effect
    /// </summary>
    /// <param name="_colour">The colour you want _message to be</param>
    /// <param name="_effect">The effect you want _message to have</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <param name="_size">The size you want _message to have in the console</param>
    public static void WarningColourEffect(in TextColour _colour, in TextEffect _effect, in object _message, int _size = UNITY_TEXT_SIZE)
    {
        // When the user wants to use no colour and no effect
        if (_colour == TextColour.NONE && _effect == TextEffect.NONE)
        {
            Debug.LogWarning(_message);
            return;
        }

        Mathf.Clamp((int)(_colour), 0, (int)(TextColour.COLOUR_NB));
        Mathf.Clamp(_size, MINIMUM_TEXT_SIZE, MAXIMUM_TEXT_SIZE);

        // When the user only wants colour
        if (_effect == TextEffect.NONE)
        {
            Debug.LogWarning("<color=" + _colour.ToString() + ">" + _message + "</color>");
            return;
        }

        string effectStr = effectTags[(int)(_effect) - 1];

        // When the user only wants effect
        if (_colour == TextColour.NONE)
        {
            Debug.LogWarning("<" + effectStr + "><size=" + _size + ">" + _message + "</size></" + effectStr + ">");
            return;
        }

        // When the user wants ALL the effects a once
        if (string.Equals(effectStr, "ALL"))
        {
            Debug.LogWarning("<b><i><u><s><size=" + _size + "><color=" + _colour.ToString() + ">" + _message + "</color></size></s></u></i></b>");
            return;
        }

        Mathf.Clamp((int)(_effect), 0, (int)(TextEffect.EFFECT_NB));

        // Normal case
        Debug.LogWarning("<" + effectStr + "><size=" + _size + "><color=" + _colour.ToString() + ">" + _message + "</color></size></" + effectStr + ">");
    }
    /// <summary>
    /// UnityEngine.Debug.LogWarning _message to the console in _colour and _effect
    /// </summary>
    /// <param name="_colour">The colour you want _message to be</param>
    /// <param name="_effects">The effects you want _message to have</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <param name="_size">The size you want _message to have in the console</param>
    public static void WarningColourEffect(in TextColour _colour, in TextEffect[] _effects, in object _message, int _size = UNITY_TEXT_SIZE)
    {
        Mathf.Clamp((int)(_colour), 0, (int)(TextColour.COLOUR_NB));
        Mathf.Clamp(_size, MINIMUM_TEXT_SIZE, MAXIMUM_TEXT_SIZE);

        // When there is no effect
        if (_effects == null || _effects.Length < 1)
        {
            Debug.LogWarning("<color=" + _colour.ToString() + ">" + _message + "</color>");
            return;
        }

        // When the user wants no effect
        if (_effects.Contains(TextEffect.NONE))
        {
            Debug.LogWarning("<color=" + _colour.ToString() + ">" + _message + "</color>");
            return;
        }

        // Make sure all the effects are valid
        for (int i = 0; i < _effects.Length; i++)
        {
            Mathf.Clamp((int)(_effects[i]), 0, (int)(TextEffect.EFFECT_NB));
        }

        // When one of the effects is ALL
        if (_effects.Contains(TextEffect.ALL))
        {
            Mathf.Clamp(_size, MINIMUM_TEXT_SIZE, MAXIMUM_TEXT_SIZE);

            Debug.LogWarning("<b><i><u><s><size=" + _size + "><color=" + _colour.ToString() + ">" + _message + "</color></size></s></u></i></b>");
            return;
        }

        bool canChangeSize = _effects.Contains(TextEffect.SIZE);
        string sizeOn = (canChangeSize) ? "<size=" + _size + ">" : "";
        string sizeOff = (canChangeSize) ? "</size>" : "";
        string colourOn = "";
        string colourOff = "";

        // When there is only 1 effect
        if (_effects.Length == 1)
        {
            colourOn =
                (_colour == TextColour.NONE)
                ? ""
                : "<color=" + _colour.ToString() + ">";
            colourOff =
                (string.Equals(colourOn, ""))
                ? ""
                : "</color>";

            // When the user wants to change text size
            if (canChangeSize)
            {
                Debug.LogWarning(sizeOn + colourOn + _message + colourOff + sizeOff);
                return;
            }

            // When the user doesn't want to change text size
            Debug.LogWarning("<" + effectTags[(int)(_effects[0]) - 1] + ">" + colourOn + _message + colourOff + "</" + effectTags[(int)(_effects[0]) - 1] + ">");
            return;
        }

        // When there are multiple effects

        List<string> effectList = new List<string>();
        effectList.Add("<" + _effects[0].ToString()[0] + ">");
        string allEffectsOn = effectList[0];
        string allEffectsOnCpy = allEffectsOn.Remove(0, 1);
        string allEffectsOff = "</" + allEffectsOnCpy;
        allEffectsOnCpy = "";
        uint differentEffectsCount = 1u;

        for (int i = 0; i < _effects.Length; i++)
        {
            if (i > 0 && _effects[i] != _effects[i - 1])
            {
                effectList.Add("<" + effectTags[i] + ">");
                allEffectsOn += effectList[i];
                allEffectsOnCpy += effectList[i].Remove(0, 1);
                allEffectsOff += "</" + allEffectsOnCpy;
                differentEffectsCount++;

                // If all effect types have been found
                // Exit the loop to avoid unnecessary computation
                if (differentEffectsCount == (int)(TextEffect.EFFECT_NB))
                {
                    break;
                }
            }
        }

        colourOn =
                (_colour == TextColour.NONE)
                ? ""
                : "<color=" + _colour.ToString() + ">";
        colourOff =
            (string.Equals(colourOn, ""))
            ? ""
            : "</color>";

        Debug.LogWarning(allEffectsOn + sizeOn + colourOn + _message + colourOff + sizeOff + allEffectsOff);
    }
    #endregion

    #region Error
    /// <summary>
    /// UnityEngine.Debug.LogError _message to the console in _colour and _effect
    /// </summary>
    /// <param name="_colour">The colour you want _message to be</param>
    /// <param name="_effect">The effect you want _message to have</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <param name="_size">The size you want _message to have in the console</param>
    public static void ErrorColourEffect(in TextColour _colour, in TextEffect _effect, in object _message, int _size = UNITY_TEXT_SIZE)
    {
        // When the user wants to use no colour and no effect
        if (_colour == TextColour.NONE && _effect == TextEffect.NONE)
        {
            Debug.LogError(_message);
            return;
        }

        Mathf.Clamp((int)(_colour), 0, (int)(TextColour.COLOUR_NB));
        Mathf.Clamp(_size, MINIMUM_TEXT_SIZE, MAXIMUM_TEXT_SIZE);

        // When the user only wants colour
        if (_effect == TextEffect.NONE)
        {
            Debug.LogError("<color=" + _colour.ToString() + ">" + _message + "</color>");
            return;
        }

        string effectStr = effectTags[(int)(_effect) - 1];

        // When the user only wants effect
        if (_colour == TextColour.NONE)
        {
            Debug.LogError("<" + effectStr + "><size=" + _size + ">" + _message + "</size></" + effectStr + ">");
            return;
        }

        // When the user wants ALL the effects a once
        if (string.Equals(effectStr, "ALL"))
        {
            Debug.LogError("<b><i><u><s><size=" + _size + "><color=" + _colour.ToString() + ">" + _message + "</color></size></s></u></i></b>");
            return;
        }

        Mathf.Clamp((int)(_effect), 0, (int)(TextEffect.EFFECT_NB));

        // Normal case
        Debug.LogError("<" + effectStr + "><size=" + _size + "><color=" + _colour.ToString() + ">" + _message + "</color></size></" + effectStr + ">");
    }
    /// <summary>
    /// UnityEngine.Debug.LogError _message to the console in _colour and _effect
    /// </summary>
    /// <param name="_colour">The colour you want _message to be</param>
    /// <param name="_effects">The effects you want _message to have</param>
    /// <param name="_message">The message you want to write to the console</param>
    /// <param name="_size">The size you want _message to have in the console</param>
    public static void ErrorColourEffect(in TextColour _colour, in TextEffect[] _effects, in object _message, int _size = UNITY_TEXT_SIZE)
    {
        Mathf.Clamp((int)(_colour), 0, (int)(TextColour.COLOUR_NB));
        Mathf.Clamp(_size, MINIMUM_TEXT_SIZE, MAXIMUM_TEXT_SIZE);

        // When there is no effect
        if (_effects == null || _effects.Length < 1)
        {
            Debug.LogError("<color=" + _colour.ToString() + ">" + _message + "</color>");
            return;
        }

        // When the user wants no effect
        if (_effects.Contains(TextEffect.NONE))
        {
            Debug.LogError("<color=" + _colour.ToString() + ">" + _message + "</color>");
            return;
        }

        // Make sure all the effects are valid
        for (int i = 0; i < _effects.Length; i++)
        {
            Mathf.Clamp((int)(_effects[i]), 0, (int)(TextEffect.EFFECT_NB));
        }

        // When one of the effects is ALL
        if (_effects.Contains(TextEffect.ALL))
        {
            Mathf.Clamp(_size, MINIMUM_TEXT_SIZE, MAXIMUM_TEXT_SIZE);

            Debug.LogError("<b><i><u><s><size=" + _size + "><color=" + _colour.ToString() + ">" + _message + "</color></size></s></u></i></b>");
            return;
        }

        bool canChangeSize = _effects.Contains(TextEffect.SIZE);
        string sizeOn = (canChangeSize) ? "<size=" + _size + ">" : "";
        string sizeOff = (canChangeSize) ? "</size>" : "";
        string colourOn = "";
        string colourOff = "";

        // When there is only 1 effect
        if (_effects.Length == 1)
        {
            colourOn =
                (_colour == TextColour.NONE)
                ? ""
                : "<color=" + _colour.ToString() + ">";
            colourOff =
                (string.Equals(colourOn, ""))
                ? ""
                : "</color>";

            // When the user wants to change text size
            if (canChangeSize)
            {
                Debug.LogError(sizeOn + colourOn + _message + colourOff + sizeOff);
                return;
            }

            // When the user doesn't want to change text size
            Debug.LogError("<" + effectTags[(int)(_effects[0]) - 1] + ">" + colourOn + _message + colourOff + "</" + effectTags[(int)(_effects[0]) - 1] + ">");
            return;
        }

        // When there are multiple effects

        List<string> effectList = new List<string>();
        effectList.Add("<" + _effects[0].ToString()[0] + ">");
        string allEffectsOn = effectList[0];
        string allEffectsOnCpy = allEffectsOn.Remove(0, 1);
        string allEffectsOff = "</" + allEffectsOnCpy;
        allEffectsOnCpy = "";
        uint differentEffectsCount = 1u;

        for (int i = 0; i < _effects.Length; i++)
        {
            if (i > 0 && _effects[i] != _effects[i - 1])
            {
                effectList.Add("<" + effectTags[i] + ">");
                allEffectsOn += effectList[i];
                allEffectsOnCpy += effectList[i].Remove(0, 1);
                allEffectsOff += "</" + allEffectsOnCpy;
                differentEffectsCount++;

                // If all effect types have been found
                // Exit the loop to avoid unnecessary computation
                if (differentEffectsCount == (int)(TextEffect.EFFECT_NB))
                {
                    break;
                }
            }
        }

        colourOn =
                (_colour == TextColour.NONE)
                ? ""
                : "<color=" + _colour.ToString() + ">";
        colourOff =
            (string.Equals(colourOn, ""))
            ? ""
            : "</color>";

        Debug.LogError(allEffectsOn + sizeOn + colourOn + _message + colourOff + sizeOff + allEffectsOff);
    }
    #endregion
    #endregion

    #region Print in colour with condition
    #region Log
    /// <summary>
    /// Writes <i>_message</i> in <i>_colour1</i> when <i>_value</i> is equal to <b>_conditionValue</b>, writes it in <i>_colour2</i> <b>otherwise</b>
    /// </summary>
    /// <param name="_message">The message you want to display in the console</param>
    /// <param name="_value">The value you want to test (true/false)</param>
    /// <param name="_conditionValue"></param>
    /// <param name="_colour1">The colour of _message when _value is true</param>
    /// <param name="_colour2">The colour of _message when _value is false</param>
    public static void LogCondition(in object _message, in object _value, in object _conditionValue, in TextColour _colour1 = TextColour.GREEN, in TextColour _colour2 = TextColour.RED)
    {
        UnityEngine.Debug.Log("<color=" + ((_value == _conditionValue) ? _colour1.ToString() : _colour2.ToString()) + ">" + _message + "</color>");
    }

    /// <summary>
    /// Override for booleans
    /// <br>Writes <i>_message</i> in <i>_colour1</i> when <i>_condition</i> is <b>true</b>, writes it in <i>_colour2</i> <b>otherwise</b></br>
    /// </summary>
    /// <param name="_message">The message you want to display in the console</param>
    /// <param name="_condition">The value you want to test (true/false)</param>
    /// <param name="_colour1">The colour of _message when _condition is true</param>
    /// <param name="_colour2">The colour of _message when _condition is false</param>
    public static void LogCondition(in object _message, in bool _condition, in TextColour _colour1 = TextColour.GREEN, in TextColour _colour2 = TextColour.RED)
    {
        UnityEngine.Debug.Log("<color=" + ((_condition) ? _colour1.ToString() : _colour2.ToString()) + ">" + _message + "</color>");
    }
    #endregion

    #region Warning
    /// <summary>
    /// Writes <i>_message</i> in <i>_colour1</i> when <i>_value</i> is equal to <b>_conditionValue</b>, writes it in <i>_colour2</i> <b>otherwise</b>
    /// </summary>
    /// <param name="_message">The message you want to display in the console</param>
    /// <param name="_value">The value you want to test (true/false)</param>
    /// <param name="_conditionValue"></param>
    /// <param name="_colour1">The colour of _message when _value is true</param>
    /// <param name="_colour2">The colour of _message when _value is false</param>
    public static void WarningCondition(in object _message, in object _value, in object _conditionValue, in TextColour _colour1 = TextColour.GREEN, in TextColour _colour2 = TextColour.RED)
    {
        UnityEngine.Debug.LogWarning("<color=" + ((_value == _conditionValue) ? _colour1.ToString() : _colour2.ToString()) + ">" + _message + "</color>");
    }

    /// <summary>
    /// Override for booleans
    /// <br>Writes <i>_message</i> in <i>_colour1</i> when <i>_condition</i> is <b>true</b>, writes it in <i>_colour2</i> <b>otherwise</b></br>
    /// </summary>
    /// <param name="_message">The message you want to display in the console</param>
    /// <param name="_condition">The value you want to test (true/false)</param>
    /// <param name="_colour1">The colour of _message when _condition is true</param>
    /// <param name="_colour2">The colour of _message when _condition is false</param>
    public static void WarningCondition(in object _message, in bool _condition, in TextColour _colour1 = TextColour.GREEN, in TextColour _colour2 = TextColour.RED)
    {
        UnityEngine.Debug.LogWarning("<color=" + ((_condition) ? _colour1.ToString() : _colour2.ToString()) + ">" + _message + "</color>");
    }
    #endregion

    #region Error
    /// <summary>
    /// Writes <i>_message</i> in <i>_colour1</i> when <i>_value</i> is equal to <b>_conditionValue</b>, writes it in <i>_colour2</i> <b>otherwise</b>
    /// </summary>
    /// <param name="_message">The message you want to display in the console</param>
    /// <param name="_value">The value you want to test (true/false)</param>
    /// <param name="_conditionValue"></param>
    /// <param name="_colour1">The colour of _message when _value is true</param>
    /// <param name="_colour2">The colour of _message when _value is false</param>
    public static void ErrorCondition(in object _message, in object _value, in object _conditionValue, in TextColour _colour1 = TextColour.GREEN, in TextColour _colour2 = TextColour.RED)
    {
        UnityEngine.Debug.LogError("<color=" + ((_value == _conditionValue) ? _colour1.ToString() : _colour2.ToString()) + ">" + _message + "</color>");
    }

    /// <summary>
    /// Override for booleans
    /// <br>Writes <i>_message</i> in <i>_colour1</i> when <i>_condition</i> is <b>true</b>, writes it in <i>_colour2</i> <b>otherwise</b></br>
    /// </summary>
    /// <param name="_message">The message you want to display in the console</param>
    /// <param name="_condition">The value you want to test (true/false)</param>
    /// <param name="_colour1">The colour of _message when _condition is true</param>
    /// <param name="_colour2">The colour of _message when _condition is false</param>
    public static void ErrorCondition(in object _message, in bool _condition, in TextColour _colour1 = TextColour.GREEN, in TextColour _colour2 = TextColour.RED)
    {
        UnityEngine.Debug.LogError("<color=" + ((_condition) ? _colour1.ToString() : _colour2.ToString()) + ">" + _message + "</color>");
    }
    #endregion
    #endregion
    #endregion
}
