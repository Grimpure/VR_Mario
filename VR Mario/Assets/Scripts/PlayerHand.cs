using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerHand : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;
    //public SteamVR_Action_Boolean invTrigger;
    //public SteamVR_Action_Boolean roomCycleTrigger;

    //public InventoryMech invStore;
    //public CycleRooms cycleRooms;

    //public GameObject inventory;

    public FixedJoint joint;
    public GameObject curObject;
    public SteamVR_Input_Sources inputHand;

    public SteamVR_Behaviour_Pose controller;
    public bool isGrabbing;
    public Interactable interact;

    private void Start()
    {
        //Finds the Components needed for grabbing
        //invStore = GameObject.Find("Inventory").GetComponent<InventoryMech>();
        joint = GetComponent<FixedJoint>();
    }

    //Checks if an object can be picked up or not
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Interactable") && !isGrabbing)
        {
            curObject = col.gameObject;
            interact = col.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (!isGrabbing && col.CompareTag("Interactable"))
        {
            curObject = null;
            interact = null;
        }
    }
    
    private void Update()
    {
        //Checks if the button for grabbing is being held
        if (trigger.GetStateDown(inputHand) && !isGrabbing)
        {
            Grab();
        }
        if (trigger.GetLastStateUp(inputHand))
        {
            Drop();
        }
        /*//Opens and closes the Inventory if the button is held or released
        if(invTrigger.GetStateDown(inputHand))
        {
            InvActive();
        }
        if (invTrigger.GetStateUp(inputHand))
        {
            InvInactive();
        }
        //Cycles Through Rooms
        if (roomCycleTrigger.GetLastStateDown(inputHand))
        {
            cycleRooms.SetRoomTrue();
        }*/
    }
    //Grabs the object to be held
    public void Grab()
    {
        if (curObject != null)
        {
            isGrabbing = true;
            joint.connectedBody = curObject.GetComponent<Rigidbody>();
            if (interact.snap == true)
            {
                curObject.transform.position = this.transform.position;
            }
        }
    }
    //Drops the object
    public void Drop()
    {
        if (joint.connectedBody != null)
        {
            curObject.GetComponent<Rigidbody>().velocity = controller.GetVelocity();
            curObject.GetComponent<Rigidbody>().angularVelocity = controller.GetAngularVelocity();
            isGrabbing = false;
            joint.connectedBody = null;
        }
    }
    /*//Sets the Inventory as GameObject true or false
    public void InvActive()
    {
        inventory.SetActive(true);
    }
    public void InvInactive()
    {
        inventory.SetActive(false);
    }*/
}
