using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockState : IPlayerState
{
	public void AnimatorUpdate(PlayerStateManager stateManager)
	{
	}

	public IPlayerState CheckTransition(PlayerStateManager stateManager)
	{
		if (stateManager.inputManager.inputsContainer.blockReleased)
		{
			stateManager.animator.SetBool("Blocking", false);
			return stateManager.states.FreeMovement;
		}
		return this;
	}

	public void StateEntered(PlayerStateManager stateManager)
	{
		stateManager.animator.SetBool("Blocking", true);
	}

	public void StateUpdate(PlayerStateManager stateManager)
	{
	}
}
