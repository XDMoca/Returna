using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour {

	[SerializeField]
	private GameObject statusIndicatorPrefab;
	private StatusIndicator statusIndicator;

	private HungerManager hungerManager;
	private SleepManager sleepManager;
	private PlayerHealthManager healthManager;

	private void Start()
	{
		hungerManager = GetComponent<HungerManager>();
		sleepManager = GetComponent<SleepManager>();
		healthManager = GetComponent<PlayerHealthManager>();
		statusIndicator = GameObject.Instantiate(statusIndicatorPrefab).GetComponent<StatusIndicator>();
		statusIndicator.player = transform;
	}

	private void Update()
	{
		if (hungerManager.IsHungry)
		{
			statusIndicator.Show(EStatus.Hungry);
		}
		else if (sleepManager.IsTired)
		{
			statusIndicator.Show(EStatus.Tired);
		}
		else
		{
			statusIndicator.Hide();
		}
	}

	public void UseItem(ConsumableItem item)
    {
		healthManager.UseItem(item.HPIncrease);
		hungerManager.EatItem(item.HungerIncrease);
    }
}
