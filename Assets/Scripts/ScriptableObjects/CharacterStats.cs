using UnityEngine;

[CreateAssetMenu(menuName = "Character Stats")]
public class CharacterStats : ScriptableObject
{
	public int MaxHP;
	public int HP;
	public int Attack;
	public int Defense;
	public int Speed;
	public int Luck;
}
