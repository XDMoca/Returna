using System;
using UnityEngine;

public class PlayerExpManager : MonoBehaviour
{

	[ReadOnly]
	public int CurrentLevel = 1;
	[ReadOnly]
	public int MaxLevel = 3;
	[ReadOnly]
	public int CurrentExp = 0;

	public int ExpToNextLevel;
	
	public event EventHandler OnExpChanged;

	public void GainExp(int expGained)
	{
		if (CurrentLevel == MaxLevel)
		{
			CurrentExp = 0;
			ExpChanged();
			return;
		}

		CurrentExp += expGained;
		if (CurrentExp >= ExpToNextLevel)
		{
			int remainingExp = CurrentExp - ExpToNextLevel;
			CurrentExp = 0;
			CurrentLevel += 1;
			GainExp(remainingExp);
		}
		ExpChanged();
	}

	private void ExpChanged()
	{
		if (OnExpChanged != null)
			OnExpChanged(this, new EventArgs());
	}
}
