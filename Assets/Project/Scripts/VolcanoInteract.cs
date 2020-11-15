using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoInteract : ItemInteract
{
    private GameObject _player;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = GameObject.FindGameObjectWithTag("Lava").GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && _player.GetComponent<PlayerSkyMovement>().enabled && Input.GetKeyDown(KeyCode.E) && CanInteract()) Action();
    }

    internal override void Action()
    {
        _spriteRenderer.enabled = false;
    }
}
