using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

	public DateTime worldTime;

	[SerializeField]
	private float lightChangeDamp;
	[SerializeField]
	private float secondsPerMinute;
	[SerializeField]
	private int lightChangeTime;

	[SerializeField]
	private Color dayColor;
	[SerializeField]
	private Color nightColor;
	private Color targetColor;

	private new Light light;
	private Animator animator;

	[SerializeField]
	private int SleepHours;

	public event EventHandler OnTick;


	void Start()
	{
		animator = GetComponent<Animator>();
		worldTime = new DateTime(1, 1, 1, 6, 50, 0);
		FireTickEvent();
		SetupLightReference();
		targetColor = dayColor;
		SceneManager.sceneLoaded += OnLevelLoaded;
		StartCoroutine(Tick());
	}

	void Update()
	{
		SetTargetColor();
		UpdateLightColor();
	}

	private IEnumerator Tick()
	{
		while (true)
		{
			yield return new WaitForSeconds(secondsPerMinute);
			IncrementTime();
			FireTickEvent();
		}
	}

	private void IncrementTime()
	{
		worldTime = worldTime.AddMinutes(1);
		setDayToZero();
	}

	private void SetTargetColor()
	{
		if (worldTime.Hour < lightChangeTime || worldTime.Hour >= lightChangeTime + 12)
		{
			targetColor = nightColor;
		}
		else
		{
			targetColor = dayColor;
		}
	}

	private void UpdateLightColor()
	{
		if (light == null)
			return;

		light.color = Color.Lerp(light.color, targetColor, lightChangeDamp);
	}

	private void SetupLightReference()
	{
		light = GameObject.FindGameObjectWithTag(Constants.Tags.AreaLight).GetComponent<Light>();
		setLightColorInstantly();
	}

	public void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		SetupLightReference();
	}

	public void StartSleep()
	{
		animator.SetTrigger("FadeInThenOut");
	}

	private void AdvanceTimeForSleep()
	{
		worldTime = worldTime.AddHours(SleepHours);
		setDayToZero();
		setLightColorInstantly();
	}

	private void setDayToZero()
	{
		if (worldTime.Day > 1)
		{
			worldTime = new DateTime(1, 1, 1, 0, 0, 0);
		}
	}

	private void setLightColorInstantly()
	{
		if (worldTime.Hour < lightChangeTime || worldTime.Hour >= lightChangeTime + 12)
		{
			light.color = nightColor;
		}
		else
		{
			light.color = dayColor;
		}
	}

	private void FireTickEvent()
	{
		if (OnTick != null)
			OnTick(this, new EventArgs());
	}

	public string GetTime()
	{
		return worldTime.ToString("HH:mm");
	}
}
