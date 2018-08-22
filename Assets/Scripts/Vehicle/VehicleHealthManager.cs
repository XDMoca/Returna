using UnityEngine;

public class VehicleHealthManager : MonoBehaviour
{

	[SerializeField]
	private int Health;
	[SerializeField]
	private int MaxHealth;

	void Start()
	{
		Health = MaxHealth;
	}

	void Update()
	{

	}

	public void ReceiveDamage(int damage)
	{
		if (Health == 0)
			return;

		Health -= damage;

		if (Health < 0)
			Health = 0;
	}
}
