using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public static InventoryManager instance = null;
	public int Money;
	public List<Weapon> InventoryWeapons = new List<Weapon>();
	public Weapon EquippedWeapon;

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
		if (EquippedWeapon == null)
			EquippedWeapon = InventoryWeapons[0];
	}

	private void MoneyChanged()
	{
		if (OnMoneyChange != null)
			OnMoneyChange(this, new EventArgs());
	}

	public void TryBuyWeapon(int moneyToSpend, Weapon weaponToBuy)
	{
		if (OwnsWeapon(weaponToBuy))
			throw new NotifyException("You already own this weapon.");

		if (moneyToSpend > Money)
			throw new NotifyException("You cannot afford this weapon.");


		Money -= moneyToSpend;
		InventoryWeapons.Add(weaponToBuy);
		MoneyChanged();
	}

	public void TryEquipWeapon(Weapon weaponToEquip)
	{
		if (!OwnsWeapon(weaponToEquip))
			throw new NotifyException("You do not own this weapon.");

		EquippedWeapon = weaponToEquip;
	}

	public bool OwnsWeapon(Weapon weaponToCheck)
	{
		if (InventoryWeapons.Contains(weaponToCheck))
			return true;

		return false;
	}

	public bool IsEquipped(Weapon weaponToCheck)
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
