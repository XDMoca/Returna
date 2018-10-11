using UnityEngine;

public class MenuSoundSource : MonoBehaviour
{
	public static MenuSoundSource instance = null;
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip OpenMenuClip;
	[SerializeField]
	private AudioClip CloseMenuClip;
	[SerializeField]
	private AudioClip NextMenuItemClip;
	[SerializeField]
	private AudioClip ActionSuccessfulClip;
	[SerializeField]
	private AudioClip ActionFailedClip;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		audioSource = GetComponent<AudioSource>();
	}

	private void PlayClip(AudioClip clipToPlay)
	{
		audioSource.PlayOneShot(clipToPlay);
	}

	public void PlayOpenSound()
	{
		PlayClip(OpenMenuClip);
	}

	public void PlayCloseSound()
	{
		PlayClip(CloseMenuClip);
	}

	public void PlayNextItemSound()
	{
		PlayClip(NextMenuItemClip);
	}

	public void PlayActionSuccessSound()
	{
		PlayClip(ActionSuccessfulClip);
	}

	public void PlayActionFailedSound()
	{
		PlayClip(ActionFailedClip);
	}
}
