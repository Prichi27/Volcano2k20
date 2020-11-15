using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerGroundMovement : MonoBehaviour
{
    public float groundSpeed = 5f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector2 _movement;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetUserInput();
        SetAnimation();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetUserInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * groundSpeed * Time.fixedDeltaTime);
    }

    private void SetAnimation()
    {
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);
    }
}
