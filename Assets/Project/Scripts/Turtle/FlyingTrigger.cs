﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTrigger : ItemInteract
{
    private GameObject _player;
    private GameObject _turtle;

    private SpriteRenderer _spriteRenderer;
    private Sprite _defaultSprite;

    public Sprite tortuga;

    private bool _isFlying = false;

    // Start is called before the first frame update
    void Start()
    {
        _turtle = GameObject.FindGameObjectWithTag("Turtle");
        _player = GameObject.FindGameObjectWithTag("Player");

        _spriteRenderer = _player.GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) Action();

        if (playerInRange && !_isFlying && Input.GetKeyDown(KeyCode.Q)) Debug.Log("Hugssss");
        
        if (_isFlying && Input.GetKeyDown(KeyCode.Q)) Action();
    }

    internal override void Action()
    {
        bool isGrounded = _player.GetComponent<PlayerGroundMovement>().enabled;

        // If on ground, switch to flying mode
        if (isGrounded)
        {
            _isFlying = true;

            // Change active script
            _player.GetComponent<PlayerGroundMovement>().enabled = false;
            _player.GetComponent<PlayerSkyMovement>().enabled = true;

            // Change Sprite
            _spriteRenderer.sprite = tortuga;

            // Hide turtle and remove its collider
            _turtle.GetComponent<Renderer>().enabled = false;
            _turtle.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            _isFlying = false;

            _player.GetComponent<PlayerGroundMovement>().enabled = true;
            _player.GetComponent<PlayerSkyMovement>().enabled = false;

            _spriteRenderer.sprite = _defaultSprite;

            // Reset player rotation
            _player.transform.rotation = Quaternion.Euler(0, 0, 0);

            // Move and unhide turtle
            _turtle.transform.position = _player.transform.localPosition;
            _turtle.GetComponent<Renderer>().enabled = true;
            _turtle.GetComponent<Collider2D>().enabled = true;
        }
    }

}
