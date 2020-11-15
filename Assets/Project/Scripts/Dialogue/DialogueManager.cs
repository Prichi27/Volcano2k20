using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;
    public TextMeshProUGUI name;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public float waitForSecond = 0.2f;
    public GameObject _player;
    private bool _playerFlying;


    private void Start()
    {
        _sentences = new Queue<string>();
        _playerFlying = _player.GetComponent<PlayerSkyMovement>().enabled;
    }

    public void StartDialogue(Dialogue dialogues)
    {
        // Prevent player from walking during dialogue
        _player.GetComponent<PlayerGroundMovement>().enabled = false;
        _player.GetComponent<PlayerSkyMovement>().enabled = false;

        animator.SetBool("IsOpened", true);

        name.text = dialogues.name;

        _sentences.Clear();

        foreach (string sentence in dialogues.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(waitForSecond);
        }
    }

    public void EndDialogue()
    {
            _player.GetComponent<PlayerGroundMovement>().enabled = !_playerFlying;
            _player.GetComponent<PlayerSkyMovement>().enabled = _playerFlying;
        animator.SetBool("IsOpened", false);
    }

    public bool DialogueIsOpen()
    {
        return animator.GetBool("IsOpened");
    }
}
