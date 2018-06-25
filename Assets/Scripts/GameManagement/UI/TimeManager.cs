using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

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

	private ITickable[] tickables;

	[SerializeField]
	private int SleepHours;
    

    void Start () {
		animator = GetComponent<Animator>();
        worldTime = new DateTime(1, 1, 1, 6, 50, 0);
        SetupLightReference();
        targetColor = dayColor;
		tickables = GameObject.FindGameObjectWithTag(Constants.Tags.Player).GetComponents<ITickable>();
        SceneManager.sceneLoaded += OnLevelLoaded;
        StartCoroutine(Tick());
	}
	
	void Update ()
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
			AdvanceTimeForAllTickableObjects();
        }
    }

    private void IncrementTime()
    {
        worldTime = worldTime.AddMinutes(1);
		setDayToZero();
        //print(worldTime.ToString("HH:mm"));
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

	private void AdvanceTimeForAllTickableObjects()
	{
		foreach (ITickable tickable in tickables)
		{
			tickable.Tick();
		}
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
}
