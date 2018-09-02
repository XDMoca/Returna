using System;
using UnityEngine;

public class VehicleHealthManager : MonoBehaviour
{
	public int Health;
	[SerializeField]
	private int MaxHealth;

	public event EventHandler OnHealthChange;

	void Start()
	{
		Health = MaxHealth;
	}

	public void ReceiveDamage(int damage)
	{
		if (Health == 0)
			return;

		Health -= damage;

		if (Health < 0)
			Health = 0;
		
		HealthChanged();
	}

	private void HealthChanged()
	{
		if (OnHealthChange != null)
			OnHealthChange(this, new EventArgs());
	}
}
