using System;
using UnityEngine;

public class DialoguePartner : InteractableEntity
{
	public DialoguePartnerInformation DialoguePartnerInformation;
}

[System.Serializable]
public class DialoguePartnerInformation : IDialoguePartnerInformation
{
	public GameObject Vehicle;
	public DialogueItem PlayerVictoryDialogue;
	public DialogueItem OpponentVictoryDialogue;
	public int PrizeMoney;
	public ShopItem[] ShopItems;

	public void HandleDialogueEvent(EDialogueEvent dialogueEvent)
	{
		switch (dialogueEvent)
		{
			case EDialogueEvent.BattleStart:
				SceneTransitionManager.instance.GoToBattle(this);
				break;
			case EDialogueEvent.PrizeMoneyGain:
				InventoryManager.instance.EarnMoney(PrizeMoney);
				break;
			case EDialogueEvent.ShopOpen:
				ShopMenuManager.instance.OpenShopMenu(ShopItems);
				break;
			default:
				throw new Exception("Dialogue event not supported");
		}
	}
}