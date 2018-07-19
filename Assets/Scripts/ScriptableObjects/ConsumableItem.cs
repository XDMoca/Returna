using UnityEngine;

[CreateAssetMenu(menuName = "Consumable Item")]
public class ConsumableItem : ScriptableObject
{

	public string Name;
	public int HPIncrease;
	public int HungerIncrease;
	public string Description;
}
