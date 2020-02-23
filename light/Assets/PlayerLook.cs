using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 100;

    public Transform body;

    private float turn;
    private float up;

    private float forward;
    private float side;

    float x_rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        turn = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        up = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        x_rotation -= up;
        x_rotation = Mathf.Clamp(x_rotation, -90, 90);

        transform.localRotation = Quaternion.Euler(x_rotation, 0, 0);
        body.Rotate(Vector3.up * turn);


    }
}
