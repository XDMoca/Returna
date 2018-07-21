using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FreeMovementState : IPlayerState {

    [SerializeField]
    private float regularMovementSpeed;
    [SerializeField]
    private float lockOnMovementSpeed;
    [SerializeField]
    private float rotationDampSpeed;

    public void StateUpdate(PlayerStateManager stateManager)
    {
        InputsContainer inputs = stateManager.inputManager.inputsContainer;
        Transform transform = stateManager.transform;

        float movementSpeed = DetermineMovementSpeed(stateManager.lockOnManager);
        Vector3 movementVector = new Vector3(inputs.HorizontalMovementInput, 0, inputs.VerticalMovementInput) * movementSpeed;
        movementVector = Vector3.ClampMagnitude(movementVector, movementSpeed);
        stateManager.rigidbody.MovePosition(transform.position + movementVector * Time.deltaTime);
        SetRotation(movementVector, stateManager.lockOnManager, stateManager.rigidbody, transform);   
    }

    private float DetermineMovementSpeed(LockOnManager lockOnManager)
    {
        return lockOnManager.LockedOn ? lockOnMovementSpeed : regularMovementSpeed;
    }

    private void SetRotation(Vector3 movementVector, LockOnManager lockOnManager, Rigidbody rigidbody, Transform transform)
    {
        if (movementVector.magnitude == 0)
            return;

        if (lockOnManager.LockedOn)
        {
            Vector3 lookDirection = lockOnManager.LockOnTarget.transform.position - transform.position;
            lookDirection.y = 0;
            rigidbody.MoveRotation(Quaternion.LookRotation(lookDirection));
        }
        else
        {

            rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector.normalized), rotationDampSpeed));
        }
    }

    public IPlayerState CheckTransition(PlayerStateManager stateManager)
    {
        InputsContainer inputs = stateManager.inputManager.inputsContainer;
        if (inputs.interactPressed && stateManager.interactionManager.InteractionTargetInRange)
        {
            stateManager.animator.SetBool("Walking", false);
            return stateManager.states.Interact;
        }
        if (inputs.attackPressed && stateManager.animationFlags.CanTransitionToNextAttack)
        {
			stateManager.animator.SetBool("Walking", false);
			return stateManager.states.Attack;
        }
        if (inputs.blockPressed)
        {
			stateManager.animator.SetBool("Walking", false);
			return stateManager.states.Block;
        }

        return this;
    }

    public void AnimatorUpdate(PlayerStateManager stateManager)
    {
        bool walking = stateManager.inputManager.inputsContainer.HorizontalMovementInput != 0 || stateManager.inputManager.inputsContainer.VerticalMovementInput != 0;
        stateManager.animator.SetBool("Walking", walking);
    }

    private EDirection GetForwardDirectionFromMovementInput(float movementInput)
    {
        return movementInput >= 0 ? EDirection.Right : EDirection.Left;
    }

    public void StateEntered(PlayerStateManager stateManager)
    {
    }
}
