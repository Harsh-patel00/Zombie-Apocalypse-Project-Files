using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingIdentifier : MonoBehaviour
{
    public string Name;

    [TextArea(3, 10)]
    public string[] dialogue;

    [HideInInspector]
    public GameObject Things;

    [HideInInspector]
    public bool playerInRange;

    void Start()
    {
        FindObjectOfType<DialogueManager>().dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (FindObjectOfType<DialogueManager>().dialoguePanel.activeInHierarchy)
            {
                FindObjectOfType<DialogueManager>().dialoguePanel.SetActive(false);
            }
            else
            {
                FindObjectOfType<DialogueManager>().dialoguePanel.SetActive(true);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Things = gameObject;
        FindObjectOfType<DialogueManager>().NextDialogue(dialogue, Name);

        gameObject.name = Name;

        if(collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            //Debug.Log("Collided with: " + gameObject.name);
            //Debug.Log("Tag with collided item is: " + gameObject.tag);
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Things.tag != null)
        {
            playerInRange = false;
            //Debug.Log("Conversation over with: " + Things.name);
            FindObjectOfType<DialogueManager>().dialoguePanel.SetActive(false);
        }
        else
        {

        }
    }
}
