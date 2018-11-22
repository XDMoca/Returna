using UnityEngine;

public class VehicleWeaponManager : MonoBehaviour
{

	AVehicleInputManager inputs;
	
	[SerializeField]
	private Weapon ActiveWeapon;

	private WeaponObject weaponObject;

	[SerializeField]
	[ReadOnly]
	private bool Firing = false;

	private float timeSinceLastFire = 0;

	void Start()
	{
		inputs = GetComponentInParent<AVehicleInputManager>();

		if (ActiveWeapon == null)
			ActiveWeapon = InventoryManager.instance.EquippedWeapon;

		weaponObject = Instantiate(ActiveWeapon.WeaponObject, transform, false).GetComponent<WeaponObject>();
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
		if (timeSinceLastFire < ActiveWeapon.FireRate)
		{
			timeSinceLastFire += Time.deltaTime;
		}

		if (Firing)
		{
			if (timeSinceLastFire >= ActiveWeapon.FireRate)
			{
				FireProjectile();
			}
		}
	}

	void FireProjectile()
	{
		timeSinceLastFire = 0;
		Instantiate(ActiveWeapon.Projectile, weaponObject.ProjectileSpawnPoint.position, transform.rotation);
		AudioSource.PlayClipAtPoint(ActiveWeapon.FireSound, transform.position);
	}
}
