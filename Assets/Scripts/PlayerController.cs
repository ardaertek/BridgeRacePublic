using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] public float MovementSpeed;
    public Vector3 Pos;
    private Vector3 _dir;
    AnimatorController AnimC;
    bool isMoving;
    Ray ray;
    Vector3 Movement;
    private bool _canControl = true;
    private void Awake()
    {
        Pos = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        AnimC = GetComponent<AnimatorController>();
    }
    void Update()
    {
        //MoveWithRB
        if (_canControl)
        {
            Movement = new Vector3(_joystick.Horizontal * MovementSpeed, rb.velocity.y, _joystick.Vertical * MovementSpeed);
            rb.velocity = new Vector3(_joystick.Horizontal * MovementSpeed, rb.velocity.y, _joystick.Vertical * MovementSpeed);
            if (Movement.x != 0 || Movement.z != 0)
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
                transform.position = Pos;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            _canControl = false;
            AnimC.isRunning(true);
            transform.DOMove(other.transform.position, 3f).OnComplete(() =>
            {
                transform.rotation = new Quaternion(0, 180, 0,0);
                AnimC.isRunning(false);
                AnimC.isVictory();
            });
        }
    }
}
