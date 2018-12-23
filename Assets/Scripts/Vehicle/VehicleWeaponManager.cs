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

	[SerializeField]
	[ReadOnly]
	private int currentAmmo;

	void Start()
	{
		inputs = GetComponentInParent<AVehicleInputManager>();

		if (ActiveWeapon == null)
			ActiveWeapon = InventoryManager.instance.EquippedWeapon;

		currentAmmo = ActiveWeapon.MaxAmmoCount;

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
		if (currentAmmo <= 0)
			return;

		timeSinceLastFire = 0;
		Instantiate(ActiveWeapon.Projectile, weaponObject.ProjectileSpawnPoint.position, transform.rotation);
		AudioSource.PlayClipAtPoint(ActiveWeapon.FireSound, transform.position);
		currentAmmo -= 1;
	}

	public void CollectAmmo(int amount)
	{
		currentAmmo += amount;
		if (currentAmmo > ActiveWeapon.MaxAmmoCount)
			currentAmmo = ActiveWeapon.MaxAmmoCount;
	}
}
