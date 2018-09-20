using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{

	public string Name;
	public float FireRate;
	public GameObject Projectile;
	public GameObject WeaponModel;
	public string Description;
	public AudioClip FireSound;
}