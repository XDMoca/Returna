using UnityEngine;

public class BGMLooper : MonoBehaviour
{

	private AudioSource audioSource;

	[SerializeField]
	private float loopStartPosition;
	[SerializeField]
	private float loopEndPosition;

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (audioSource.time >= loopEndPosition)
			audioSource.time = loopStartPosition;
	}
}
