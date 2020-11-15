using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkyMovement : MonoBehaviour
{
    public float flySpeed = 5f;
    public float rotateSpeed = 5f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private bool _isMovingForward;

    private float _rotation;
    private bool _isLeftSide = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetUserInput();
        //SetAnimation();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }


    private void GetUserInput()
    {
        if (Input.GetKey(KeyCode.W)) { _isMovingForward = true; }
        
        _rotation = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        if(_isMovingForward)
        {
            _rigidbody.velocity = transform.right * flySpeed * Time.fixedDeltaTime;
            _isMovingForward = false;

            //Debug.Log(Mathf.DeltaAngle(0, transform.eulerAngles.z));

            //if (Mathf.DeltaAngle(0, transform.eulerAngles.z) > 90 && !_isLeftSide)
            //{
            //    transform.eulerAngles = new Vector3(0, 180, transform.eulerAngles.z);
            //    _isLeftSide = true;

            //}

            //else
            //{
            //    transform.eulerAngles = new Vector3(0, 180, transform.eulerAngles.z);

            //}
        }
    }

    private void RotatePlayer()
    {
        transform.Rotate(new Vector3(0, 0, _rotation * rotateSpeed * Time.fixedDeltaTime));
    }
}
