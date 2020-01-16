using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class fly : MonoBehaviour
{
    private Rigidbody body;
    private Vector3 currVel;
    private float turn;
    private float forward;

    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        currVel = Vector3.zero;
        if (Input.GetKey(KeyCode.Space))
        {
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                currVel += Vector3.down;
            } else
            {
                currVel += Vector3.up;
            }

        }
        turn = Input.GetAxis("Horizontal");
        forward = Input.GetAxis("Vertical");

        currVel += (transform.rotation * Quaternion.Inverse(Quaternion.identity)).eulerAngles * forward;

        body.velocity = currVel * speed;

        body.MoveRotation( body.rotation * Quaternion.AngleAxis(5 * turn, Vector3.up));

    }
}
