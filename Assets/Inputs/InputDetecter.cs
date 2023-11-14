using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class InputDetecter : MonoBehaviour
{
    public GameObject m_ControlIndicator;
    public Texture m_KeyboardTex;
    public Texture m_GamepadTex;

    InputDevice m_LastInputDevice;

    private void OnEnable()
    {
        InputSystem.onEvent += DetectInput;
    }

    private void OnDisable()
    {
        InputSystem.onEvent -= DetectInput;
    }

    private void DetectInput(InputEventPtr eventPtr, InputDevice device)
    {
        if (m_LastInputDevice == device) return;

        if (eventPtr.type != StateEvent.Type) return;

        bool validInput = false;
        foreach (InputControl control in eventPtr.EnumerateChangedControls(device, 0.1f))
        {
            validInput = true;
            break;
        }

        if(device is Mouse)
        {
            foreach (InputControl control in eventPtr.EnumerateChangedControls(device, 0.1f))
            {
                if (control.displayName.Contains("Position") || control.displayName.Contains("Delta"))
                {
                    validInput = false;
                    break;
                }
            }
        }

        if (!validInput)
        {
            return;
        }

        string deviceData = device.name + " : " + device.displayName;

        m_LastInputDevice = device;

        //PlayerInputManager inputManager;
        //inputManager.JoinPlayer(playerIndex: 1, pairWithDevice: device);

        if (device is Gamepad)
        {
            Debug.Log("GAMEPAD: " + deviceData);
            SetIndicatorTex(m_GamepadTex);
        }
        else if (device is Keyboard )
        {
            Debug.Log("Keyboard: " + deviceData);
            SetIndicatorTex(m_KeyboardTex);
        }
        else if (device is Mouse)
        {
            Debug.Log("Mouse: " + deviceData);
        }
        else
        {
            Debug.Log("Unknown: " + deviceData);
            SetIndicatorTex(m_KeyboardTex);
        }

    }

    private void SetIndicatorTex(Texture tex)
    {
        var renderer = m_ControlIndicator.GetComponent<Renderer>();
        renderer.material.mainTexture = tex;
    }
}
