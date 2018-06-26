using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	[SerializeField]
	Text HPText;
	[SerializeField]
	Text TimeText;

	private TimeManager timeManager;
	private PlayerStatusManager playerStatus;
	void Start () {
		timeManager = GetComponent<TimeManager>();
		playerStatus = GameObject.FindObjectOfType<PlayerStatusManager>();

		timeManager.OnTick += (s, e) => UpdateTime();
		playerStatus.OnHPChange += (s, e) => UpdateHP();

		HPText.text = playerStatus.GetHPInformation();
		TimeText.text = timeManager.GetTime();
	}
	
	
	void Update () {
		
	}

	private void UpdateTime()
	{
		TimeText.text = timeManager.GetTime();
	}

	private void UpdateHP()
	{
		HPText.text = playerStatus.GetHPInformation();
	}
}
