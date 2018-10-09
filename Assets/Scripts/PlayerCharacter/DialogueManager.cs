using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	private Queue<DialogueItem> dialogueItems;
	private IDialoguePartnerInformation dialoguePartnerInformation;

	[HideInInspector]
	public DialogueItem CurrentDialogueItem;

	public bool InDialogue = false;

	public event EventHandler OnDialogueStart;
	public event EventHandler OnDialogueNextSentence;
	public event EventHandler OnDialogueEnd;

	public void StartDialogue(IDialoguePartnerInformation dialoguePartnerInformation, params DialogueItem[] dialogueItems)
	{
		this.dialoguePartnerInformation = dialoguePartnerInformation;
		InDialogue = true;
		this.dialogueItems = GetDialogueArray(dialogueItems);
		if (OnDialogueStart != null)
			OnDialogueStart(this, new EventArgs());
		NextSentence();
	}

	public void NextSentence()
	{
		CheckDialogueEvents();

		if (dialogueItems.Count == 0)
		{
			EndDialogue();
			return;
		}

		CurrentDialogueItem = dialogueItems.Dequeue();

		if (OnDialogueNextSentence != null)
			OnDialogueNextSentence(this, new EventArgs());
	}

	private void CheckDialogueEvents()
	{
		if (CurrentDialogueItem != null && CurrentDialogueItem.DialogueEvent != EDialogueEvent.None)
		{
			dialoguePartnerInformation.HandleDialogueEvent(CurrentDialogueItem.DialogueEvent);
		}
	}

	public void EndDialogue()
	{
		dialogueItems = null;
		CurrentDialogueItem = null;
		dialoguePartnerInformation = null;
		InDialogue = false;
		if (OnDialogueEnd != null)
			OnDialogueEnd(this, new EventArgs());
	}


	private Queue<DialogueItem> GetDialogueArray(params DialogueItem[] Dialogue)
	{
		Queue<DialogueItem> dialogue = new Queue<DialogueItem>();
		foreach (DialogueItem sentence in Dialogue)
		{
			dialogue.Enqueue(sentence);
		}
		return dialogue;
	}
}

[System.Serializable]
public class DialogueItem
{
	public string Text;
	public string SpeakerName;
	public EDialogueEvent DialogueEvent = EDialogueEvent.None;
}
