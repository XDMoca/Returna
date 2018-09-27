using UnityEngine;

public class OpponentCharacter : InteractableEntity
{
	public GameObject Vehicle;
	public PostBattleInformation PostBattleInformation;	
}

[System.Serializable]
public class PostBattleInformation
{
	public DialogueItem PlayerVictoryDialogue;
	public DialogueItem OpponentVictoryDialogue;
	public int PrizeMoney;
}