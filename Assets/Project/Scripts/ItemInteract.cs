using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemInteract : MonoBehaviour
{
    internal bool playerInRange;
    private GameObject _contextClue;
    public List<Item> items;

    private void Awake()
    {
        _contextClue = GameObject.FindGameObjectWithTag("ContextClue");
    }
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) Action();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            _contextClue.GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            _contextClue.GetComponent<Renderer>().enabled = false;
        }
    }

    internal abstract void Action();

    internal bool CanInteract()
    {
        if (items.Count == 0)
        {
            return true;
        }
        else
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
    }
}