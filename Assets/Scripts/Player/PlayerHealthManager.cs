using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{


	[SerializeField]
	private int MaxHP;
	[SerializeField]
	private int HP;

	public event EventHandler OnHPChange;

	private PlayerStateManager stateManager;

	void Start()
	{
		stateManager = GetComponent<PlayerStateManager>();
	}

	public void UseItem(int hpIncrease)
	{
		HP += hpIncrease;
		if (HP > MaxHP)
		{
			HP = MaxHP;
			HPChanged();
		}
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

	public void TakeCombatDamage(int damage)
	{
		if(!stateManager.IsBlocking)
		TakeHPDamage(damage);
	}

	private void HPChanged()
	{
		if (OnHPChange != null)
			OnHPChange(this, new EventArgs());
	}

	public string HPInformation { get { return "HP: " + HP + "/" + MaxHP; } }
}
