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
		dialogueManager = GetComponent<DialogueManager>();
	}

	void Start()
	{
		dialogueManager.OnDialogueStart += (s, e) => StartDialog();
		dialogueManager.OnDialogueNextSentence += (s, e) => ShowNextSentence();
		dialogueManager.OnDialogueEnd += (s, e) => EndDialogue();
		dialoguePanel.gameObject.SetActive(false);
	}

	private void Update()
	{
		HandleInteractPress();
	}

	public void HandleInteractPress()
	{
		if (!InputManager.instance.inputsContainer.interactPressed)
			return;

		if (!dialogueManager.InDialogue)
		{
			if (InteractionInterface.instance.InteractionTargetInRange)
			{
				DialoguePartner partner = InteractionInterface.instance.interactionTarget as DialoguePartner;
				if (partner != null)
				{
					InitiateDialogue(partner.DialoguePartnerInformation, partner.Dialogue);
				}
			}
		}
		else
		{
			if (isTypingOutQuote)
			{
				StopAllCoroutines();
				isTypingOutQuote = false;
				quoteText.text = dialogueManager.CurrentDialogueItem.Text;
			}
			else
			{
				dialogueManager.NextSentence();
			}
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
		dialogueManager.StartDialogue(dialoguePartnerInformation, dialogue);
	}
}
