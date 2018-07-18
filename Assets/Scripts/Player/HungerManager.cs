using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerManager : MonoBehaviour, ITickable {

	[SerializeField]
	private float MaxHunger;
	[SerializeField]
	private float Hunger;
	[SerializeField]
	private float HungerDecreasePerWorldMinute;
	[SerializeField]
	private float HungerIndicatorThreshold;
	[SerializeField]
	private float StatDecreaseThreshold;
	[SerializeField]
	private int HPLossPerZeroHungerTick;

	private PlayerHealthManager playerHealth;

	void Start () {
		playerHealth = GetComponent<PlayerHealthManager>();
	}

	public void Tick()
	{
		DecreaseHungerStat();
		CheckShowIndicator();
		CheckHPLoss();
		CheckStatDecrease();
	}

	private void DecreaseHungerStat()
	{
		Hunger -= HungerDecreasePerWorldMinute;
		if (Hunger < 0)
			Hunger = 0;
	}

	private void CheckShowIndicator()
	{
		if (Hunger < HungerIndicatorThreshold)
		{
			//show indicator
		}
	}

	private void CheckHPLoss()
	{
		if (Hunger <= 0)
		{
			playerHealth.TakeHPDamage(HPLossPerZeroHungerTick);
		}
	}

	private void CheckStatDecrease()
	{
		if (Hunger < StatDecreaseThreshold)
		{
			//decreaseStats
		}
	}

	public void EatItem(float hungerIncrease)
	{
		Hunger += hungerIncrease;
		if (Hunger > MaxHunger)
		{
			Hunger = MaxHunger;
		}
	}

	public bool IsHungry
	{
		get { return Hunger < HungerIndicatorThreshold; }
	}
}
