using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : ItemInteract
{
    public Dialogue dialogues;

    // TODO: Remove pls
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) Action();
    }

    internal override void Action()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues);
    }
}
