using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour {

	[SerializeField]
	private float sensorRadius;

	[HideInInspector]
	public bool playerInRange = false;

	void Update() {
		ScanForPlayer();
	}

	private void ScanForPlayer()
	{
		Collider[] collidersinRange = Physics.OverlapSphere(transform.position, sensorRadius, LayerMask.GetMask(Constants.Layers.Player));

		if (collidersinRange.Length > 0)
		{
			playerInRange = true;
		}
		else
		{
			playerInRange = false;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(transform.position, sensorRadius);
	}
}
