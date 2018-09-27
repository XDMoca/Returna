using System;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

	public int Money;

	public event EventHandler OnMoneyChange;

	private void MoneyChanged()
	{
		if (OnMoneyChange != null)
			OnMoneyChange(this, new EventArgs());
	}

	public bool SpendMoney(int moneyToSpend)
	{
		if (moneyToSpend > Money)
			return false;

		Money -= moneyToSpend;
		return true;
	}

	public void EarnMoney(int moneyGained)
	{
		Money += moneyGained;
		MoneyChanged();
	}
}
