using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator {

	public static int ApplyDefense(int damage, int defense)
	{
		return Mathf.FloorToInt(damage * ((float)damage/defense));
	}
}
