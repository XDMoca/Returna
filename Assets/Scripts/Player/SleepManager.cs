using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepManager : MonoBehaviour, ITickable
{

	[SerializeField]
	private float MaxWokeness;
	[SerializeField]
	private float Wokeness;
	[SerializeField]
	private float WokenessDecreasePerWorldMinute;
	[SerializeField]
	private float WokenessIndicatorThreshold;
	[SerializeField]
	private float StatDecreaseThreshold;
	[SerializeField]
	private int HPLossPerZeroWokenessTick;

	private PlayerHealthManager playerHealth;
	private InputManager inputManager;
	private TimeManager timeManager;

	void Start()
	{
		playerHealth = GetComponent<PlayerHealthManager>();
		inputManager = GetComponent<InputManager>();
		timeManager = GameObject.FindObjectOfType<TimeManager>();
	}

	void Update()
	{
		CheckInput();
	}

	public void Tick()
	{
		DecreaseWokenessStat();
		CheckShowIndicator();
		CheckHPLoss();
		CheckStatDecrease();
	}

	private void DecreaseWokenessStat()
	{
		Wokeness -= WokenessDecreasePerWorldMinute;
		if (Wokeness < 0)
			Wokeness = 0;
	}

	private void CheckShowIndicator()
	{
		if (Wokeness < WokenessIndicatorThreshold)
		{
			//show indicator
		}
	}

	private void CheckHPLoss()
	{
		if (Wokeness <= 0)
		{
			playerHealth.TakeHPDamage(HPLossPerZeroWokenessTick);
		}
	}

	private void CheckStatDecrease()
	{
		if (Wokeness < StatDecreaseThreshold)
		{
			//decreaseStats
		}
	}

	public bool IsTired
	{
		get { return Wokeness < WokenessIndicatorThreshold; }
	}

	private void CheckInput()
	{
		if (inputManager.inputsContainer.sleepPressed)
		{
			Sleep();
		}
	}

	private void Sleep()
	{
		if (!IsTired)
			return;

		Wokeness = MaxWokeness;

		timeManager.StartSleep();
	}
}