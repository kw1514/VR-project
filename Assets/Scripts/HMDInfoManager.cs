using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDInfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         if (!XRSettings.isDeviceActive)
        {
            Debug.Log("no headset plugged");
        }
        else if (XRSettings.isDeviceActive && XRSettings.loadedDeviceName == "MockHMDDisplay")
        {
            Debug.Log("using mock HMD");
        }
        else
        {
            Debug.Log("We have a headset " + XRSettings.loadedDeviceName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
