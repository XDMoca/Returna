using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusIndicator : MonoBehaviour {

	private new Transform camera;
	private Animator animator;
	private SpriteRenderer sprite;
	private PlayerStatusManager playerStatus;

	[HideInInspector]
	public Transform player;

	[SerializeField]
	private Vector3 offsetFromPlayer;

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		sprite = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
		camera = Camera.main.transform;
		playerStatus = player.GetComponent<PlayerStatusManager>();
		Hide();
	}

	void Update()
	{
		transform.rotation = camera.rotation;
		transform.position = player.position + offsetFromPlayer;
	}

	public void Hide()
	{
		if (sprite == null || !sprite.enabled)
			return;
		sprite.enabled = false;
		animator.SetBool("Hungry", false);
	}

	public void Show(EStatus status)
	{
		if (sprite == null || sprite.enabled)
			return;

		if (!sprite.enabled)
		{
			animator.SetTrigger("Appear");
		}
		sprite.enabled = true;
		SetStatusType(status);
	}

	private void SetStatusType(EStatus status)
	{
		animator.SetBool("Hungry", true);
	}
}
