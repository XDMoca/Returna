using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelManager : MonoBehaviour {

    [SerializeField]
    private Text speakerNameText;
    [SerializeField]
    private Text quoteText;
    [SerializeField]
    private Image dialoguePanel;
    [SerializeField]
    private float timeBetweenLetters;

	private DialogueManager dialogueManager;

	void Start () {
		dialogueManager = GameObject.FindGameObjectWithTag(Constants.Tags.Player).GetComponent<DialogueManager>();
		dialogueManager.OnDialogueStart += (s, e) => StartDialog();
		dialogueManager.OnDialogueNextSentence += (s, e) => ShowNextSentence();
		dialogueManager.OnDialogueEnd += (s, e) => EndDialogue();
		dialoguePanel.gameObject.SetActive(false);
	}

    public void StartDialog()
    {
        dialoguePanel.gameObject.SetActive(true);
    }

    public void ShowNextSentence()
    {
        StopAllCoroutines();
		speakerNameText.text = dialogueManager.CurrentDialogueItem.SpeakerName;
        StartCoroutine(TypeOutSentence(dialogueManager.CurrentDialogueItem.Text));
    }

    public void EndDialogue()
    {
        quoteText.text = "";
        dialoguePanel.gameObject.SetActive(false);
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
