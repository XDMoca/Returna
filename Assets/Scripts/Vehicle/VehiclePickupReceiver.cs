using UnityEngine;

public class VehiclePickupReceiver : MonoBehaviour {
	private VehicleWeaponManager weaponManager;

	private void Start()
	{
		weaponManager = GetComponentInChildren<VehicleWeaponManager>();
	}

	public void CollectAmmo(int ammoCollected)
	{
		weaponManager.CollectAmmo(ammoCollected);
	}
}
