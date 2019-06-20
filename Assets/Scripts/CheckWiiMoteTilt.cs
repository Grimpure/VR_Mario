using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WiimoteApi;

public class CheckWiiMoteTilt : MonoBehaviour
{

    //private Wiimote wiimote;

    public WiimoteDemo wmd;
    public Vector3 wiiMoteRotation;
    public Slider debugSlider;

    public float steering;

    // Start is called before the first frame update
    void Start()
    {
        //wiimote = WiimoteManager.Wiimotes[0];
    }

    // Update is called once per frame
    void Update()
    {
        wiiMoteRotation = wmd.wmpOffset;
        //debugSlider.value = wmd.wmpOffset.y;

        //debugSlider.value = wmd.wmpOffset.y;
        wmd.wmpOffset.y -= 0.0022f;
        steering = wmd.wmpOffset.y / 30;
        debugSlider.value = steering;
        if (steering >= 1)
        {
            steering = 1;
        }
        if (steering <= -1)
        {
            steering = -1;
        }
    }
}
