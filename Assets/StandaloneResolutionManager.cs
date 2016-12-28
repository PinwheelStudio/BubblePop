using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandaloneResolutionManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Screen.SetResolution(437, 700, false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
