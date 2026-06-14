using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public enum KeyboardActions
{
    // Debug
    DEBUG_TOGGLE_ADDED_DEBUG_ACTIONS,

    DEBUG_RELOAD_SCENE,
    
    DEBUG_BLEND_MORE,
    DEBUG_BLEND_LESS,

    DEBUG_PREVIOUS_BLEND_MODE,
    DEBUG_NEXT_BLEND_MODE,

    DEBUG_TOGGLE_SHADER,

    DEBUG_CHANGE_SHAPE,

    // Game
    MOVE_FWD,
    MOVE_BACK,
    MOVE_LEFT,
    MOVE_RIGHT,

    JUMP,

    ACTION_NB
}

public enum MouseActions
{
    ATTACK_OR_DESTROY_BLOCK,
    USE_ITEM_OR_PLACE_BLOCK,

    ACTION_NB
}

public enum GamepadActions
{
    MOVE_FWD,
    MOVE_BACK,
    MOVE_LEFT,
    MOVE_RIGHT,

    JUMP,

    ATTACK_OR_DESTROY_BLOCK,
    USE_ITEM_OR_PLACE_BLOCK,

    ACTION_NB
}

// Needs an instance in the scene to work
public class ControlsManager : MonoBehaviour
{
    private static readonly ButtonControl[] gamepadButtons = new ButtonControl[(int)(GamepadActions.ACTION_NB)];
    private static readonly KeyControl[] keyboardKeys = new KeyControl[(int)(KeyboardActions.ACTION_NB)];
    private static readonly ButtonControl[] mouseButtons = new ButtonControl[(int)(MouseActions.ACTION_NB)];

    private static Vector2 mouseDeltaThisFrame = Vector2.zero;

    public static bool KeyboardReady = false;
    public static bool MouseReady = false;
    public static bool GamepadReady = false;

    public static Keyboard CurrentKeyboard
    {
        get => Keyboard.current;
    }
    public static Mouse CurrentMouse
    {
        get => Mouse.current;
    }
    public static Gamepad CurrentGamepad
    {
        get => Gamepad.current;
    }
    public static int DeviceCount
    {
        get => InputSystem.devices.Count;
    }
    public static int GameDeviceCount
    {
        get => InputSystem.devices.Count(d => d is Keyboard || d is Mouse || d is Gamepad);
    }
    public static bool KeyboardConnected
    {
        get => (CurrentKeyboard != null);
    }
    public static bool MouseConnected
    {
        get => (CurrentMouse != null);
    }
    public static bool GamepadConnected
    {
        get => (CurrentGamepad != null);
    }
    public static bool NoDeviceConnected
    {
        get => (InputSystem.devices.Count <= 0);
    }
    public static bool NoGameDeviceConnected
    {
        get => (GameDeviceCount <= 0);
    }
    public static bool KeyboardPress
    {
        get =>
            (CurrentKeyboard != null)
                ? CurrentKeyboard.anyKey.IsPressed()
                : false;
    }
    public static bool MousePress
    {
        get =>
            (CurrentMouse != null)
                ? (CurrentMouse.allControls.Count(x => x is ButtonControl && x.IsPressed()) > 0)
                : false;
    }
    public static bool GamepadPress
    {
        get =>
            (CurrentGamepad != null)
                ? (CurrentGamepad.allControls.Count(x => x is ButtonControl && x.IsPressed()) > 0)
                : false;
    }
    public static bool GameDevicePress
    {
        get => (KeyboardPress || MousePress || GamepadPress);
    }

    public static Vector2 MouseDelta
    {
        get => mouseDeltaThisFrame;
    }
    public static float MouseXDelta
    {
        get => MouseDelta.x;
    }
    public static float MouseYDelta
    {
        get => MouseDelta.y;
    }

    [SerializeField] private bool dontDestroyOnLoad = true;

    // Awake is called once before all other methods, when the GameObject is created
    private void Awake()
    {
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this);
        }

        InitKeyboardActions();
        InitMouseActions();
        InitGamepadActions();
    }

    // Update is called once per frame
    private void Update()
    {
        mouseDeltaThisFrame =
            (CurrentMouse != null)
                ? CurrentMouse.delta.ReadValue()
                : Vector2.zero;

        if (!KeyboardConnected) { KeyboardReady = false; }
        if (!MouseConnected) { MouseReady = false; }
        if (!GamepadConnected) { GamepadReady = false; }

        if (KeyboardConnected && !KeyboardReady)
        {
            InitKeyboardActions();
            KeyboardReady = true;
        }

        if (MouseConnected && !MouseReady)
        {
            InitMouseActions();
            MouseReady = true;
        }

        if (GamepadConnected && !GamepadReady)
        {
            InitGamepadActions();
            GamepadReady = true;
        }
    }


    private static void InitKeyboardActions()
    {
        Keyboard keyboard = CurrentKeyboard;

        if (keyboard != null)
        {
            // Debug keys
            keyboardKeys[(int)(KeyboardActions.DEBUG_TOGGLE_ADDED_DEBUG_ACTIONS)] = keyboard.tabKey;

            keyboardKeys[(int)(KeyboardActions.DEBUG_RELOAD_SCENE)] = keyboard.rKey;

            keyboardKeys[(int)(KeyboardActions.DEBUG_BLEND_MORE)] = keyboard.upArrowKey;
            keyboardKeys[(int)(KeyboardActions.DEBUG_BLEND_LESS)] = keyboard.downArrowKey;

            keyboardKeys[(int)(KeyboardActions.DEBUG_PREVIOUS_BLEND_MODE)] = keyboard.leftArrowKey;
            keyboardKeys[(int)(KeyboardActions.DEBUG_NEXT_BLEND_MODE)] = keyboard.rightArrowKey;

            keyboardKeys[(int)(KeyboardActions.DEBUG_TOGGLE_SHADER)] = keyboard.enterKey;
            
            keyboardKeys[(int)(KeyboardActions.DEBUG_CHANGE_SHAPE)] = keyboard.leftAltKey;


            // Actual game keys
            keyboardKeys[(int)(KeyboardActions.MOVE_FWD)] = keyboard.wKey;
            keyboardKeys[(int)(KeyboardActions.MOVE_BACK)] = keyboard.sKey;
            keyboardKeys[(int)(KeyboardActions.MOVE_LEFT)] = keyboard.aKey;
            keyboardKeys[(int)(KeyboardActions.MOVE_RIGHT)] = keyboard.dKey;

            keyboardKeys[(int)(KeyboardActions.JUMP)] = keyboard.spaceKey;
        }
    }
    private static void InitMouseActions()
    {
        Mouse mouse = CurrentMouse;

        if (mouse != null)
        {
            mouseButtons[(int)(MouseActions.ATTACK_OR_DESTROY_BLOCK)] = mouse.leftButton;
            mouseButtons[(int)(MouseActions.USE_ITEM_OR_PLACE_BLOCK)] = mouse.rightButton;
        }
    }
    private static void InitGamepadActions()
    {
        Gamepad gamepad = CurrentGamepad;

        if (gamepad != null)
        {
            gamepadButtons[(int)(GamepadActions.MOVE_FWD)] = gamepad.leftStick.up;
            gamepadButtons[(int)(GamepadActions.MOVE_BACK)] = gamepad.leftStick.down;
            gamepadButtons[(int)(GamepadActions.MOVE_LEFT)] = gamepad.leftStick.left;
            gamepadButtons[(int)(GamepadActions.MOVE_RIGHT)] = gamepad.leftStick.right;

            gamepadButtons[(int)(GamepadActions.JUMP)] = gamepad.aButton;

            gamepadButtons[(int)(GamepadActions.ATTACK_OR_DESTROY_BLOCK)] = gamepad.leftTrigger;
            gamepadButtons[(int)(GamepadActions.USE_ITEM_OR_PLACE_BLOCK)] = gamepad.rightTrigger;
        }
    }


    public static bool HasPressed_Keyboard(in KeyboardActions _action, in bool _isPressConstant)
    {
        if (_action >= KeyboardActions.ACTION_NB)
        {
            return false;
        }

        if (KeyboardReady)
        {
            return
                (_isPressConstant)
                    ? keyboardKeys[(int)(_action)].IsPressed()
                    : keyboardKeys[(int)(_action)].wasPressedThisFrame;
        }

        return false;
    }
    public static bool HasPressed_Mouse(in MouseActions _action, in bool _isPressConstant)
    {
        if (_action >= MouseActions.ACTION_NB)
        {
            return false;
        }

        if (MouseReady)
        {
            return (_isPressConstant) ? mouseButtons[(int)(_action)].IsPressed() : mouseButtons[(int)(_action)].wasPressedThisFrame;
        }

        return false;
    }
    public static bool HasPressed_Gamepad(in GamepadActions _action, in bool _isPressConstant)
    {
        if (_action >= GamepadActions.ACTION_NB)
        {
            return false;
        }

        if (GamepadReady)
        {
            return (_isPressConstant) ? gamepadButtons[(int)(_action)].IsPressed() : gamepadButtons[(int)(_action)].wasPressedThisFrame;
        }

        return false;
    }

    public static bool HasReleased_Keyboard(in KeyboardActions _action)
    {
        if (_action >= KeyboardActions.ACTION_NB)
        {
            return false;
        }

        if (KeyboardReady)
        {
            return keyboardKeys[(int)(_action)].wasReleasedThisFrame;
        }

        return false;
    }
    public static bool HasReleased_Mouse(in MouseActions _action)
    {
        if (_action >= MouseActions.ACTION_NB)
        {
            return false;
        }

        if (MouseReady)
        {
            return mouseButtons[(int)(_action)].wasReleasedThisFrame;
        }

        return false;
    }
    public static bool HasReleased_Gamepad(in GamepadActions _action)
    {
        if (_action >= GamepadActions.ACTION_NB)
        {
            return false;
        }

        if (GamepadReady)
        {
            return gamepadButtons[(int)(_action)].wasReleasedThisFrame;
        }

        return false;
    }


    public static void Remap_Keyboard(in KeyboardActions _action, in KeyControl _key)
    {
        if (_action >= KeyboardActions.ACTION_NB)
        {
            Debug.LogError("<color=white>Remap_Keyboard: Invalid _action.</color>");
            return;
        }

        keyboardKeys[(int)(_action)] = _key;
    }
    public static void Remap_Mouse(in MouseActions _action, in ButtonControl _button)
    {
        if (_action >= MouseActions.ACTION_NB)
        {
            Debug.LogError("<color=white>Remap_Mouse: Invalid _action.</color>");
            return;
        }

        mouseButtons[(int)(_action)] = _button;
    }
    public static void Remap_Gamepad(in GamepadActions _action, in ButtonControl _button)
    {
        if (_action >= GamepadActions.ACTION_NB)
        {
            Debug.LogError("<color=white>Remap_Gamepad: Invalid _action.</color>");
            return;
        }

        gamepadButtons[(int)(_action)] = _button;
    }


    public static KeyControl GetKey(in KeyboardActions _action)
    {
        return keyboardKeys[(int)(_action)];
    }
    public static ButtonControl GetButton_Mouse(in MouseActions _action)
    {
        return mouseButtons[(int)(_action)];
    }
    public static ButtonControl GetButton_Gamepad(in GamepadActions _action)
    {
        return gamepadButtons[(int)(_action)];
    }


    public static void SwapKeys(in KeyboardActions _action1, in KeyboardActions _action2)
    {
        int iAction1 = (int)(_action1);
        int iAction2 = (int)(_action2);

        KeyControl action1Cpy = keyboardKeys[iAction1];
        keyboardKeys[iAction1] = keyboardKeys[iAction2];
        keyboardKeys[iAction2] = action1Cpy;
    }
    public static void SwapButtons_Mouse(in MouseActions _action1, in MouseActions _action2)
    {
        int iAction1 = (int)(_action1);
        int iAction2 = (int)(_action2);

        ButtonControl action1Cpy = mouseButtons[iAction1];
        mouseButtons[iAction1] = mouseButtons[iAction2];
        mouseButtons[iAction2] = action1Cpy;
    }
    public static void SwapButtons_Gamepad(in GamepadActions _action1, in GamepadActions _action2)
    {
        int iAction1 = (int)(_action1);
        int iAction2 = (int)(_action2);

        ButtonControl action1Cpy = gamepadButtons[iAction1];
        gamepadButtons[iAction1] = gamepadButtons[iAction2];
        gamepadButtons[iAction2] = action1Cpy;
    }
}
