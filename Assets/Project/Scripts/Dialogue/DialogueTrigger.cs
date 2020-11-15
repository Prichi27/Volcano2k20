using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : ItemInteract
{
    public Dialogue dialogues;
    
    // TODO: Remove pls
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) Action();

        if (FindObjectOfType<DialogueManager>().DialogueIsOpen() && Input.GetKeyDown(KeyCode.Q))
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }

    internal override void Action()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues);
    }
}
