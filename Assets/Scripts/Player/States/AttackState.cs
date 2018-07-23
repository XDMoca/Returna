using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackState : IPlayerState
{
    [ReadOnly]
    [SerializeField]
    private bool attacking = false;

    private int currentAttackCounter = 0;
    private int maxAttackCounter = 3;

    private float currentTimeInAttackAnimation = 0;

    public void AnimatorUpdate(PlayerStateManager stateManager)
    {
        stateManager.animator.SetBool("Attacking", attacking);
        stateManager.animator.SetInteger("AttackCounter", currentAttackCounter);
    }

    public IPlayerState CheckTransition(PlayerStateManager stateManager)
    {
        attacking = currentTimeInAttackAnimation < stateManager.animator.GetCurrentAnimatorStateInfo(0).length;
        if (!attacking)
        {
            currentAttackCounter = 0;
            stateManager.animator.SetBool("Attacking", attacking);
            stateManager.animator.SetInteger("AttackCounter", currentAttackCounter);
            return stateManager.states.FreeMovement;
        }

        return this;
    }

    public void StateUpdate(PlayerStateManager stateManager)
    {
        InputsContainer inputs = stateManager.inputManager.inputsContainer;
        currentTimeInAttackAnimation += Time.deltaTime;

        if (inputs.attackPressed)
        {
            PerformAttack(stateManager);
        }
    }

    private void PerformAttack(PlayerStateManager stateManager)
    {
        if (currentAttackCounter == maxAttackCounter)
            return;

        if (!stateManager.animationFlags.CanTransitionToNextAttack)
            return;

        ++currentAttackCounter;
        currentTimeInAttackAnimation = 0;
		stateManager.soundPlayer.PlaySwordSwing();
    }

    public void StateEntered(PlayerStateManager stateManager)
    {
        attacking = true;
    }
}
