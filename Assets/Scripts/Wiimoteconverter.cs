using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;
using UnityStandardAssets.Vehicles.Car;

public class Wiimoteconverter : MonoBehaviour
{
    private Wiimote wiimote;

    public FinishLine homeReset;

    public float accel = 0;
    //public float brake = 0;

    public WiimoteDemo wmd;
    public Vector3 wiiMoteRotation;

    public float steering;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!WiimoteManager.HasWiimote()) { return; }

        wiimote = WiimoteManager.Wiimotes[0];

        /*wiiMoteRotation = wmd.wmpOffset;

        wmd.wmpOffset.y -= 0.0022f;
        steering = wmd.wmpOffset.y / 30;
        if (steering >= 1)
        {
            steering = 1;
        }
        if (steering <= -1)
        {
            steering = -1;
        }*/

        if (wiimote.Button.two)
        {
            accel = 1f;
        } else { accel = 0; }

        if (wiimote.Button.one)
        {
           // brake = -1f;
            accel = -1f;
        } else if (!wiimote.Button.two) { accel = 0; }

        if(wiimote.Button.home)
        {
            homeReset.ResetIt();
        }

        if (wiimote.Button.d_down)
        {
            steering = 0.5f;
        }
        if (wiimote.Button.d_up)
        {
            steering = -0.5f;
        }
        if(wiimote.Button.d_down && wiimote.Button.d_up)
        {
            steering = 0f;
        }
        CarUserControl.instance.h = steering;
        CarUserControl.instance.v = accel;
    }
}
