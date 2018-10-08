using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMenuManager : MonoBehaviour
{

	public static DialogueMenuManager instance = null;

	[SerializeField]
	private TextMeshProUGUI speakerNameText;
	[SerializeField]
	private TextMeshProUGUI quoteText;
	[SerializeField]
	private Image dialoguePanel;
	[SerializeField]
	private float timeBetweenLetters;

	private DialogueManager dialogueManager;
	private DialoguePartnerInformation dialoguePartnerInformation;
	private DialogueItem[] dialogueItems;

	public bool InDialogue { get { return dialogueManager.InDialogue; } }
	private bool isTypingOutQuote = false;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		dialogueManager = DialogueManager.instance;
		dialogueManager.OnDialogueStart += (s, e) => StartDialog();
		dialogueManager.OnDialogueNextSentence += (s, e) => ShowNextSentence();
		dialogueManager.OnDialogueEnd += (s, e) => EndDialogue();
		dialoguePanel.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (dialoguePartnerInformation == null)
			return;

		HandleInteractPress();
	}

	public void HandleInteractPress()
	{
		if (!dialogueManager.InDialogue)
		{
			dialogueManager.StartDialogue(dialoguePartnerInformation, dialogueItems);
		}
		else if (InputManager.instance.inputsContainer.interactPressed)
		{
			if (isTypingOutQuote)
			{
				StopAllCoroutines();
				isTypingOutQuote = false;
				quoteText.text = dialogueManager.CurrentDialogueItem.Text;
			}
			else
				dialogueManager.NextSentence();
		}
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
		StopAllCoroutines();
		quoteText.text = "";
		dialoguePartnerInformation = null;
		dialogueItems = null;
		dialoguePanel.gameObject.SetActive(false);
	}

	IEnumerator TypeOutSentence(string sentence)
	{
		isTypingOutQuote = true;
		quoteText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			yield return new WaitForSeconds(timeBetweenLetters);
			quoteText.text += letter;
		}
		isTypingOutQuote = false;
	}

	public void InitiateDialogue(DialoguePartnerInformation dialoguePartnerInformation, params DialogueItem[] dialogue)
	{
		this.dialoguePartnerInformation = dialoguePartnerInformation;
		this.dialogueItems = dialogue;
	}
}
