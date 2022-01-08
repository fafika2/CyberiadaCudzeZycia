using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] public float _speed = 2;
    [SerializeField] public float _RunSpeed = 4;
    private float mainSpeed = 2;
    //[SerializeField] public float _TurnSpeed = 360;
    [SerializeField] public float _SpeedRotate = 5;
    private float _inputHorizontal;
    private float _inputVertical;
    private bool ShiftCheck;
    private Vector3 _input;
    public Animator anim;

    void Start()
    {
    }


    void Update()
    {
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        _inputVertical = Input.GetAxisRaw("Vertical");
        ShiftCheck = Input.GetKey(KeyCode.LeftShift);
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    /*void Look()
    {
        if(_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _TurnSpeed * Time.deltaTime);
            
        }
    }*/


    void Move()
    {
        

        if (_inputVertical != 0)
        {
            if (ShiftCheck == true)
            {
                mainSpeed = _RunSpeed;
                anim.SetBool("Run", true);
                anim.SetInteger("_Speed", 2);
            }
            else if (ShiftCheck == false)
            {
                mainSpeed = _speed;
                anim.SetBool("Run", false);
                anim.SetInteger("_Speed", 1);
            }
            _rigidbody.MovePosition(transform.position + (transform.forward * _inputVertical) * mainSpeed * Time.deltaTime);
            anim.SetBool("Walk", true);
        }
        else if(_inputVertical == 0)
        {
            anim.SetInteger("_Speed", 0);
            anim.SetBool("Walk", false);
        }
        
       
        }

        /*void GatherInput()
        {
            _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }*/

        void Rotate()
        {
            if (_inputHorizontal != 0)
            {
                transform.Rotate(0, _SpeedRotate * _inputHorizontal, 0);
            }
        }

    }

