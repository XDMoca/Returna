using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : APickup
{
	[SerializeField]
	private int ammoAmount;

	protected override void ApplyPickup(VehiclePickupReceiver pickupReceiver)
	{
		pickupReceiver.CollectAmmo(ammoAmount);
	}
}
