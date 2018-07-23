using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
	AudioSource source;

	[SerializeField]
	private AudioClip footstepClip;
	[SerializeField]
	private AudioClip swordSwingClip;
	[SerializeField]
	private AudioClip swordHitClip;

	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	private void PlaySound(AudioClip clip)
	{
		if(clip == null)
			return;

		source.PlayOneShot(clip);
	}
	private void PlaySoundInstance(AudioClip clip)
	{
		if (clip == null)
			return;

		AudioSource.PlayClipAtPoint(clip, transform.position);
	}

	public void PlayFootstep()
	{
		PlaySound(footstepClip);
	}
	public void PlaySwordSwing()
	{
		PlaySound(swordSwingClip);
	}
	public void PlaySwordHit()
	{
		PlaySoundInstance(swordHitClip);
	}
}
