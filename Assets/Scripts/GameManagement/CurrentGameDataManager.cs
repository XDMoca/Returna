using System.Collections.Generic;
using UnityEngine;

public class CurrentGameDataManager : MonoBehaviour
{
	public static CurrentGameDataManager instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	public int Money;
	public List<Weapon> InventoryWeapons;
	public Weapon EquippedWeapon;
}
