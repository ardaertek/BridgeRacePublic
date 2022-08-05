using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] public float MovementSpeed;
    private Vector3 _dir;
    AnimatorController AnimC;
    bool isMoving;
    Ray ray;
    Vector3 Movement;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        AnimC = GetComponent<AnimatorController>();
    }
    void Update()
    {
        //MoveWithRB
        //if(transform.position.x <= 14f || transform.position.x >= -14f)
        Movement = new Vector3(_joystick.Horizontal * MovementSpeed, rb.velocity.y, _joystick.Vertical * MovementSpeed);
        rb.velocity = new Vector3(_joystick.Horizontal * MovementSpeed, rb.velocity.y, _joystick.Vertical * MovementSpeed);
        if (Movement.x  != 0 || Movement.z != 0)
        {
            AnimC.isRunning(true);
        }
        else
        {
            AnimC.isRunning(false);
        }
        //MoveWithVectors
        ////float Ypos = transform.position.y;
        ////Xpos +=_joystick.Horizontal * MovementSpeed;
        ////Zpos += _joystick.Vertical * MovementSpeed;
        //transform.position += new Vector3(_joystick.Horizontal * MovementSpeed, Ypos , _joystick.Vertical * MovementSpeed);

        //LookWithVectors
        _dir = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        if (_dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_dir), 100);
        }
        else
        {
            _dir = transform.rotation.eulerAngles;
        }
        if (transform.position.y < -1)
        {
            transform.position = Vector3.zero;
        }
    }
}
