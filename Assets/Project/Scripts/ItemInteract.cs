using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteract : MonoBehaviour
{
    private bool _playerInRange;
    public GameObject contextClue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _playerInRange = true;

            contextClue.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _playerInRange = false;
            contextClue.SetActive(false);
        }
    }
}
