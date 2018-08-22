using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileManager : MonoBehaviour
{

	[SerializeField]
	private float speed;
	[SerializeField]
	private int damage;

	private new Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.velocity = transform.rotation * new Vector3(0, 0, speed);
		Destroy(gameObject, 5f);
	}

	private void OnTriggerEnter(Collider other)
	{
		VehicleHealthManager healthManager = other.GetComponentInParent<VehicleHealthManager>();
		if (healthManager != null)
		{
			healthManager.ReceiveDamage(damage);
		}
		Destroy(gameObject);
	}
}
