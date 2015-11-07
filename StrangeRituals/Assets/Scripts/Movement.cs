using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float LookAtSpeed = 1;
    public float JumpPower = 1;

    [HideInInspector]
    public bool Grounded = true;

    bool jump = false;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        //float MouseX = Input.GetAxis("Mouse X");
        float z = Input.GetAxis("Vertical");
        
        //if (Input.GetButton("LookRight"))
        //    transform.Rotate(0, LookAtSpeed, 0, Space.Self);

        //if (Input.GetButton("LookLeft"))
        //    transform.Rotate(0, -LookAtSpeed, 0, Space.Self);

        transform.Translate(x * Time.deltaTime * 10, 0, z * Time.deltaTime * 10);
        //transform.Rotate(0, MouseX, 0);

        if (Input.GetButtonDown("Jump") & !jump)
            transform.Translate(0, JumpPower, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        Grounded = true;
        jump = false;
    }
    void OnCollisionExit(Collision other)
    {
        Grounded = false;
        jump = true;
    }

}
