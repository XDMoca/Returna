using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyAttackState : IEnemyState
{
	private float currentTimeInAttackAnimation = 0;

	public void AnimatorUpdate(EnemyStateManager stateManager)
	{

	}

	public IEnemyState CheckTransition(EnemyStateManager stateManager)
	{
		bool attacking = currentTimeInAttackAnimation < stateManager.animator.GetCurrentAnimatorStateInfo(0).length;
		if (!attacking)
		{
			return stateManager.states.MovePosition;
		}

		return this;
	}

	public void StateEntered(EnemyStateManager stateManager)
	{
		currentTimeInAttackAnimation = 0;
		stateManager.animator.SetTrigger("Attack");
	}

	public void StateUpdate(EnemyStateManager stateManager)
	{
		currentTimeInAttackAnimation += Time.deltaTime;
	}
}
