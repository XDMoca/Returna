using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour {

    [SerializeField]
    private int MaxHP;
    [SerializeField]
    private int HP;

	[SerializeField]
	private GameObject statusIndicatorPrefab;
	private StatusIndicator statusIndicator;

	private HungerManager hungerManager;
	private SleepManager sleepManager;


	public event EventHandler OnHPChange;

	private void Start()
	{
		hungerManager = GetComponent<HungerManager>();
		sleepManager = GetComponent<SleepManager>();
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
        HP += item.HPIncrease;
        if (HP > MaxHP)
        {
            HP = MaxHP;
			HPChanged();

		}
		hungerManager.EatItem(item.HungerIncrease);
    }

	public void TakeHPDamage(int damage)
	{
		HP -= damage;
		if (HP <= 0)
		{
			HP = 0;
		}
		HPChanged();
	}

	private void HPChanged()
	{
		if (OnHPChange != null)
			OnHPChange(this, new EventArgs());
	}

	public string GetHPInformation()
	{
		return "HP: " + HP + "/" + MaxHP;
	}
}
