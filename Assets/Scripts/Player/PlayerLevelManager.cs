using UnityEngine;

public class PlayerLevelManager : MonoBehaviour
{

	[ReadOnly]
	public int CurrentLevel = 1;
	[ReadOnly]
	public int MaxLevel = 2;
	[ReadOnly]
	public int CurrentExp = 0;

	public int ExpToNextLevel;

	public void GainExp(int expGained)
	{
		if (CurrentLevel == MaxLevel)
		{
			CurrentExp = 0;
			return;
		}

		CurrentExp += expGained;
		if (CurrentExp >= ExpToNextLevel)
		{
			int remainingExp = CurrentExp - ExpToNextLevel;
			CurrentLevel += 1;
			GainExp(remainingExp);
		}
	}
}
