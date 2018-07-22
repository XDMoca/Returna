using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
	private CharacterStats playerStats;
	public event EventHandler OnHPChange;

	private PlayerStateManager stateManager;

	void Awake()
	{
		stateManager = GetComponent<PlayerStateManager>();
		playerStats = AssetLoadHelper.GetPlayerStats();
	}

	public void UseItem(int hpIncrease)
	{
		playerStats.HP += hpIncrease;
		if (playerStats.HP > playerStats.MaxHP)
		{
			playerStats.HP = playerStats.MaxHP;
			HPChanged();
		}
	}

	public void TakeHPDamage(int damage)
	{
		playerStats.HP -= damage;
		if (playerStats.HP <= 0)
		{
			playerStats.HP = 0;
		}
		HPChanged();
	}

	public void TakeCombatDamage(int damage)
	{
		if (stateManager.IsBlocking)
		{
			damage = DamageCalculator.ApplyDefense(damage, playerStats.Defense);
		}

		TakeHPDamage(damage);
	}

	private void HPChanged()
	{
		if (OnHPChange != null)
			OnHPChange(this, new EventArgs());
	}

	public string HPInformation { get { return "HP: " + playerStats.HP + "/" + playerStats.MaxHP; } }
}
