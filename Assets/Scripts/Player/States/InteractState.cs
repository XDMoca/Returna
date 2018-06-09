using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractState : IPlayerState
{
    public void AnimatorUpdate(PlayerStateManager stateManager)
    {
        
    }

    public IPlayerState CheckTransition(PlayerStateManager stateManager)
    {
        if (!stateManager.interactionManager.Interacting)
        {
            return stateManager.states.FreeMovement;
        }
        return this;
    }

    public void StateEntered(PlayerStateManager stateManager)
    {
        
    }

    public void StateUpdate(PlayerStateManager stateManager)
    {
        if (stateManager.inputManager.inputsContainer.interactPressed)
        {
            stateManager.interactionManager.Interact();
        }
    }
}
