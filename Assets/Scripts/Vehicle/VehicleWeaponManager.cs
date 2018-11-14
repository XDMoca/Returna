﻿using UnityEngine;

public class VehicleWeaponManager : MonoBehaviour
{

	AVehicleInputManager inputs;
	
	private Weapon activeWeapon;

	[SerializeField]
	[ReadOnly]
	private bool Firing = false;

	private float timeSinceLastFire = 0;

	void Start()
	{
		inputs = GetComponentInParent<AVehicleInputManager>();
		activeWeapon = InventoryManager.instance.EquippedWeapon;
	}

	void Update()
	{
		CheckInputs();
		UpdateFireLoop();
	}

	void CheckInputs()
	{
		if (inputs.fireHeld)
		{
			Firing = true;
		}
		else
		{
			Firing = false;
		}
	}

	void UpdateFireLoop()
	{
		if (timeSinceLastFire < activeWeapon.FireRate)
		{
			timeSinceLastFire += Time.deltaTime;
		}

		if (Firing)
		{
			if (timeSinceLastFire >= activeWeapon.FireRate)
			{
				FireProjectile();
			}
		}
	}

	void FireProjectile()
	{
		timeSinceLastFire = 0;
		Collider projectileCollider = Instantiate(activeWeapon.Projectile, transform.position + new Vector3(0, 0.2f, 0), transform.rotation).GetComponent<Collider>();
		AudioSource.PlayClipAtPoint(activeWeapon.FireSound, transform.position);
	}
}
