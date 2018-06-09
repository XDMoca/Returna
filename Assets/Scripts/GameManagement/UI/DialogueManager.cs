using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    [SerializeField]
    private Text speakerNameText;
    [SerializeField]
    private Text quoteText;
    [SerializeField]
    private Image dialoguePanel;
    [SerializeField]
    private float timeBetweenLetters;

    private Queue<string> sentences;

	void Start () {
        dialoguePanel.gameObject.SetActive(false);
	}

    public void StartDialog(string speaker, Queue<string> sentences)
    {
        this.sentences = sentences;
        dialoguePanel.gameObject.SetActive(true);
        speakerNameText.text = speaker;
        ShowNextSentence();
    }

    public bool ShowNextSentence()
    {
        if (sentences.Count == 0)
            return EndDialogue();
        StopAllCoroutines();
        StartCoroutine(TypeOutSentence(sentences.Dequeue()));
        return true;
    }

    bool EndDialogue()
    {
        quoteText.text = "";
        dialoguePanel.gameObject.SetActive(false);
        return false;
    }

    IEnumerator TypeOutSentence(string sentence)
    {
        quoteText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            quoteText.text += letter;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
	

}
