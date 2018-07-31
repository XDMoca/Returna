﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : MonoBehaviour
{

	[SerializeField]
	private int Health;
	[SerializeField]
	private int ExperienceGiven;

	private Animator animator;
	private PlayerLevelManager playerLevel;

	private void Start()
	{
		animator = GetComponent<Animator>();
		playerLevel = GameObject.FindGameObjectWithTag(Constants.Tags.Player).GetComponent<PlayerLevelManager>();
	}

	public void ReceiveDamage(int damageReceived)
	{
		if (Health <= 0)
			return;

		Health -= damageReceived;
		if (Health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		playerLevel.GainExp(ExperienceGiven);
		animator.SetTrigger("Die");
		Destroy(gameObject, 1.5f);
	}
}
