using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusIndicator : MonoBehaviour {

	private new Transform camera;
	private Animator animator;
	private SpriteRenderer sprite;
	private PlayerStatusManager playerStatus;
	private EStatus currentStatus;

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
		animator.SetBool("Tired", false);
	}

	public void Show(EStatus status)
	{
		if (currentStatus == status)
			return;
		
		SetStatusType(status);
		sprite.enabled = true;
	}

	private void SetStatusType(EStatus status)
	{
		currentStatus = status;
		animator.SetTrigger("Appear");
		switch (status)
		{
			case EStatus.Hungry:
				animator.SetBool("Hungry", true);
				animator.SetBool("Tired", false);
				break;
			case EStatus.Tired:
				animator.SetBool("Tired", true);
				animator.SetBool("Hungry", false);
				break;
		}
	}
}
