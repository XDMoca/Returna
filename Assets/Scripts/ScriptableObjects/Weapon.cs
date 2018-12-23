using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
	public int ID;
	public string Name;
	public float FireRate;
	public int MaxAmmoCount;
	public GameObject Projectile;
	public GameObject WeaponObject;
	public string Description;
	public AudioClip FireSound;
}