using UnityEngine;

[CreateAssetMenu(menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
	public Weapon Weapon;
	public int Price;
	public string DisplayName;
	public string DisplayDamage;
	public string DisplayFireRate;
}