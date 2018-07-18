using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

	[SerializeField]
	Text HPText;
	[SerializeField]
	Text TimeText;

	private TimeManager timeManager;
	private PlayerHealthManager playerHealth;

	void Start()
	{
		timeManager = GetComponent<TimeManager>();
		playerHealth = GameObject.FindObjectOfType<PlayerHealthManager>();

		timeManager.OnTick += (s, e) => UpdateTime();
		playerHealth.OnHPChange += (s, e) => UpdateHP();

		HPText.text = playerHealth.HPInformation;
		TimeText.text = timeManager.GetTime();
	}

	private void UpdateTime()
	{
		TimeText.text = timeManager.GetTime();
	}

	private void UpdateHP()
	{
		HPText.text = playerHealth.HPInformation;
	}
}
