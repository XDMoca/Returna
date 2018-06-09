using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EvadeState : IPlayerState
{

    private float currentTimeInEvadeAnimation = 0;

    public void AnimatorUpdate(PlayerStateManager stateManager)
    {
        stateManager.animator.SetBool("Evading", true);
    }

    public IPlayerState CheckTransition(PlayerStateManager stateManager)
    {
        bool evading = currentTimeInEvadeAnimation < stateManager.animator.GetCurrentAnimatorStateInfo(0).length;
        if (!evading)
        {
            EndEvade(stateManager);
            return stateManager.states.FreeMovement;
        }

        return this;
    }

    public void StateUpdate(PlayerStateManager stateManager)
    {
        currentTimeInEvadeAnimation += Time.deltaTime;
    }

    public void StateEntered(PlayerStateManager stateManager)
    {
    }

    private void EndEvade(PlayerStateManager stateManager)
    {
        currentTimeInEvadeAnimation = 0;
        stateManager.animator.SetBool("Evading", false);
    }
}
