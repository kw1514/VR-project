using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;

public class PlayerController : MonoBehaviour
{
    private InputDevice rightInputDevice;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            rightInputDevice = item;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rightInputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue))
        {

        }   

    }

    public void onSelect()
    {
        Debug.Log("item was selected");
    }
}
