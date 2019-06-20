using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    Vector3 dir;
    Vector3 velocity = Vector3.zero;
    RaycastHit hit;
    RaycastHit dir1;
    RaycastHit dir2;
    RaycastHit dist1;
    RaycastHit dist2;

    public float speed;
    public float hitAngle;
    public float rotAngle;
    public float turnDist;
    public float maxWallDist;

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
        //SetDistanceFromWall();
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
                    if(transform.rotation.y > 0)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 1, transform.rotation.z), -rotAngle * speed);
                    }
                    else
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 1, transform.rotation.z), rotAngle * speed);
                    }
                }

                else if (Direction() == "right")
                {
                    if (transform.rotation.y > 0)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 1, transform.rotation.z), -rotAngle * speed);
                    }
                    else
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 1, transform.rotation.z), rotAngle * speed);
                    }
                }
            }
        }

        hitAngle = Vector3.Angle(hit.normal, transform.forward);
    }

    private void Ride()
    {
        transform.Translate(dir * speed);
    }

    private void SetDistanceFromWall()
    {
        Physics.Raycast(transform.position, transform.forward + new Vector3(0, 0, -5f), out dist1, Mathf.Infinity);
        Physics.Raycast(transform.position, transform.forward + new Vector3(0, 0, 5f), out dist2, Mathf.Infinity);

        if (dist1.distance < maxWallDist)
        {
            transform.Translate(Vector3.left * speed);
            //Vector3.SmoothDamp(transform.position, Vector3.left, ref velocity, 1);
        }
        else if(dist2.distance < maxWallDist)
        {
            transform.Translate(Vector3.right * speed);
            //Vector3.SmoothDamp(transform.position, Vector3.right, ref velocity, 1);
        }
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
