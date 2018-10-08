using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public static InventoryManager instance = null;
	public int Money;
	public List<Weapon> InventoryWeapons = new List<Weapon>();

	public event EventHandler OnMoneyChange;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void MoneyChanged()
	{
		if (OnMoneyChange != null)
			OnMoneyChange(this, new EventArgs());
	}

	public bool TryBuyWeapon(int moneyToSpend, Weapon weaponToBuy)
	{
		if (moneyToSpend > Money)
			return false;

		if (OwnsWeapon(weaponToBuy))
			return false;

		Money -= moneyToSpend;
		InventoryWeapons.Add(weaponToBuy);
		MoneyChanged();
		return true;
	}

	public bool OwnsWeapon(Weapon weaponToCheck)
	{
		if (InventoryWeapons.Contains(weaponToCheck))
			return true;

		return false;
	}

	public void EarnMoney(int moneyGained)
	{
		Money += moneyGained;
		MoneyChanged();
	}
}
