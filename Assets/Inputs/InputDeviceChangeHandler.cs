using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

// add this into built-in button you can create from menu: UI/Button
public class InputDeviceChangeHandler : MonoBehaviour
{
    public GameObject m_ControlsIndicator;

    public Texture m_KeyboardTexture;
    public Texture m_GamepadTexture;

    private InputDevice m_LastDevice;

    void OnEnable()
    {
        InputSystem.onEvent += OnDeviceChange;
    }

    void OnDisable()
    {
        InputSystem.onEvent -= OnDeviceChange;
    }

    private void OnDeviceChange(InputEventPtr eventPtr, InputDevice device)
    {
        if (m_LastDevice == device) return;
        if (eventPtr.type != StateEvent.Type) return;

        bool validPress = false;
        foreach (InputControl control in eventPtr.EnumerateChangedControls(device, 0.1f))
        {
            validPress = true;
            break;
        }
        if (validPress == false) return;

        m_LastDevice = device;
        string deviceData = device.name + " : " + device.displayName;

        if (device is Gamepad)
        {
            SetTexture(m_GamepadTexture);
            Debug.Log("GAMEPAD!! "+deviceData);
        }
        else if (device is Keyboard)
        {
            SetTexture(m_KeyboardTexture);
            Debug.Log("Keyboard and Mouse!! " + deviceData);
        }
        else if (device is Mouse)
        {
            var mouse = (Mouse)device;
            if(mouse.magnitude > 0.5f)
            {
                SetTexture(m_KeyboardTexture);
                Debug.Log("Keyboard and Mouse!! " + deviceData);
            }
        }
        else
        {
            SetTexture(m_GamepadTexture);
            Debug.Log("UNKNOWN!! " + deviceData);
        }


    }

    private void SetTexture(Texture tex)
    {
        var renderer = m_ControlsIndicator.GetComponent<MeshRenderer>();
        renderer.material.mainTexture = tex;
    }
}