using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance { get; set; }
    public GameObject dialoguePanel;

    [HideInInspector]
    public string Name;

    [HideInInspector]
    public List<string> dialogueLines = new List<string>();

    public Button continueButton;

    public Text dialogueText;
    public Text nameText;

    [HideInInspector]
    public int index;

    // Start is called before the first frame update
    void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Dialogues").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
    }

    public void NextDialogue(string[] lines, string name)
    {
        index = 0;
        dialogueLines = new List<string>();
        foreach (string line in lines)
        {
            dialogueLines.Add(line);
        }

        this.Name = name;
        CreateDialogue();

    }

    public void CreateDialogue()
    {
        nameText.text = Name;
        dialogueText.text = dialogueLines[index];
    }

    public void ContinueDialogue()
    {
        if (index < dialogueLines.Count-1)
        {
            index++;
            dialogueText.text = dialogueLines[index];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
