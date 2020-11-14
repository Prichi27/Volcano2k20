using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private GameObject _player;
    private SpriteRenderer _spriteRenderer;
    private Sprite _defaultSprite;

    public Sprite tortuga;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMovement()
    {
        bool isGrounded = _player.GetComponent<PlayerGroundMovement>().enabled;
        
        // If on ground, switch to flying mode
        if (isGrounded)
        {
            _player.GetComponent<PlayerGroundMovement>().enabled = false;
            _player.GetComponent<PlayerSkyMovement>().enabled = true;
            
            _spriteRenderer.sprite = tortuga;
        }
        else
        {
            _player.GetComponent<PlayerGroundMovement>().enabled = true;
            _player.GetComponent<PlayerSkyMovement>().enabled = false;

            _spriteRenderer.sprite = _defaultSprite;
            // Reset player rotation
            _player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


}
