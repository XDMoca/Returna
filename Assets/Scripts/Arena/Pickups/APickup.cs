using System.Collections;
using UnityEngine;

public abstract class APickup : MonoBehaviour {

	[SerializeField]
	[ReadOnly]
	private bool isActive;

	[SerializeField]
	private float respawnTime;

	private MeshRenderer pickupMesh;
	private Collider pickupCollider;

	private void Start()
	{
		isActive = true;
		pickupMesh = GetComponent<MeshRenderer>();
		pickupCollider = GetComponent<Collider>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!isActive)
			return;

		VehiclePickupReceiver pickupReceiver = other.GetComponentInParent<VehiclePickupReceiver>();
		if (pickupReceiver == null)
			return;

		ApplyPickup(pickupReceiver);
		MarkAsCollected();
	}

	protected abstract void ApplyPickup(VehiclePickupReceiver pickupReceiver);

	private void MarkAsCollected()
	{
		isActive = false;
		pickupMesh.enabled = false;
		pickupCollider.enabled = false;
		StartCoroutine(Respawn());
	}

	private IEnumerator Respawn()
	{
		yield return new WaitForSecondsRealtime(respawnTime);
		isActive = true;
		pickupMesh.enabled = true;
		pickupCollider.enabled = true;
	}
}
