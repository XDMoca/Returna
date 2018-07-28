using System.Collections;
using UnityEngine;

public class HitStopManager : MonoBehaviour
{

	[SerializeField]
	private float TimeScale;
	[SerializeField]
	private float TimeDuration;

	public void HitStop()
	{
		StartCoroutine(HitStopThread());
	}

	private IEnumerator HitStopThread()
	{
		Time.timeScale = TimeScale;
		yield return new WaitForSecondsRealtime(TimeDuration);
		Time.timeScale = 1;
	}


}
