using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemInteract : MonoBehaviour
{
    internal bool playerInRange;
    public GameObject contextClue;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            contextClue.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            contextClue.SetActive(false);
        }
    }

    internal abstract void Action();
}
