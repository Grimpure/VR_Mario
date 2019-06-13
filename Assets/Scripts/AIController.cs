using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    Vector3 dir;
    RaycastHit hit;
    RaycastHit dir1;
    RaycastHit dir2;

    public float speed;
    public float hitAngle;
    public float rotAngle;
    public float turnDist;

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.forward;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Ride();
    }

    private void Movement()
    {

        Physics.Raycast(transform.position + new Vector3(0, 3, 0), transform.forward, out hit, Mathf.Infinity);

        if (hit.collider != null)
        {
            if (hit.distance < turnDist)
            {
                hitAngle = Vector3.Angle(hit.normal, transform.forward);
                
                if (Direction() == "left")
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y - Mathf.Cos(hitAngle), transform.rotation.z), 1);
                }

                else if (Direction() == "right")
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + Mathf.Cos(hitAngle), transform.rotation.z), 1);
                }      
            }
        }

        hitAngle = Vector3.Angle(hit.normal, transform.forward);
    }

    private void Ride()
    {
        transform.Translate(dir * speed);
    }

    public string Direction()
    {
        Physics.Raycast(transform.position, transform.forward + new Vector3(0, 0, -0.5f), out dir1, Mathf.Infinity);
        Physics.Raycast(transform.position, transform.forward + new Vector3(0, 0, 0.5f), out dir2, Mathf.Infinity);

        if(dir1.distance > dir2.distance)
        {
            return "left";
        }
        else
        {
            return "right";
        }
    }

}
