using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlyingTrigger : ItemInteract
{
    private GameObject _player;
    private GameObject _turtle;
    private GameObject _background;

    private SpriteRenderer _spriteRenderer;
    //private Sprite _defaultSprite;
    //public Sprite tortuga;

    private bool _isFlying = false;

    // Start is called before the first frame update
    void Start()
    {
        _turtle = GameObject.FindGameObjectWithTag("Turtle");
        _player = GameObject.FindGameObjectWithTag("Player");
        _background = GameObject.FindGameObjectWithTag("Background");

        _spriteRenderer = _player.GetComponent<SpriteRenderer>();
        //_defaultSprite = _spriteRenderer.sprite;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && CanFly()) Action();

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
            //_spriteRenderer.sprite = tortuga;

            _player.GetComponent<Animator>().SetBool("Fly", true);

            // Hide turtle and remove its collider
            _turtle.GetComponent<Renderer>().enabled = false;
            _turtle.GetComponent<Collider2D>().enabled = false;

            // Disable background collider when flying
            //_background.GetComponent<PolygonCollider2D>().enabled = false;
            _player.GetComponent<CapsuleCollider2D>().isTrigger = true;
        }
        else
        {
            _isFlying = false;

            _player.GetComponent<PlayerGroundMovement>().enabled = true;
            _player.GetComponent<PlayerSkyMovement>().enabled = false;

            //_spriteRenderer.sprite = _defaultSprite;

            _player.GetComponent<Animator>().SetBool("Fly", false);


            // Reset player rotation
            _player.transform.rotation = Quaternion.Euler(0, 0, 0);

            // Move and unhide turtle
            _turtle.transform.position = _player.transform.localPosition;
            _turtle.GetComponent<Renderer>().enabled = true;
            _turtle.GetComponent<Collider2D>().enabled = true;

            // Enable background collider
            //_background.GetComponent<PolygonCollider2D>().enabled = true;
            _player.GetComponent<CapsuleCollider2D>().isTrigger = false;

        }
    }

    private bool CanFly()
    {

        foreach (Item item in items)
        {
            if (!Inventory.instance.CheckItem(item))
            {
                Debug.Log("Go collect items!");
                return false;
            }

        }

        return true;
    }

    private bool CanLand()
    {


        return false;

    }
}
