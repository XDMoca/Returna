using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour {

    [SerializeField]
    private int MaxHP;
    [SerializeField]
    private int HP;
    [SerializeField]
    private float MaxWokeness;
    [SerializeField]
    private float Wokeness;

	[SerializeField]
	private GameObject statusIndicatorPrefab;
	private StatusIndicator statusIndicator;

	private HungerManager hungerManager;

	private void Start()
	{
		hungerManager = GetComponent<HungerManager>();
		statusIndicator = GameObject.Instantiate(statusIndicatorPrefab).GetComponent<StatusIndicator>();
		statusIndicator.player = transform;
	}

	private void Update()
	{
		if (hungerManager.IsHungry())
		{
			statusIndicator.Show(EStatus.Hungry);
		}
		else
		{
			statusIndicator.Hide();
		}
	}

	public void UseItem(ConsumableItem item)
    {
        HP += item.HPIncrease;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
		hungerManager.EatItem(item.HungerIncrease);
    }

	public void TakeHPDamage(int damage)
	{
		HP -= damage;
	}
}
