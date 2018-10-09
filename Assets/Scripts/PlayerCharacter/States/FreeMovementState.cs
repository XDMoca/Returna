using UnityEngine;

[System.Serializable]
public class FreeMovementState : AState<PlayerStateManager>
{

	[SerializeField]
	private float movementSpeed;
	[SerializeField]
	private float rotationDampSpeed;

	public override void StateUpdate()
	{
		InputsContainer inputs = stateManager.inputManager.inputsContainer;
		Transform transform = stateManager.transform;

		float movementSpeed = this.movementSpeed;
		Vector3 movementVector = new Vector3(inputs.HorizontalMovementInput, 0, inputs.VerticalMovementInput) * movementSpeed;
		movementVector = Vector3.ClampMagnitude(movementVector, movementSpeed);
		stateManager.rigidbody.MovePosition(transform.position + movementVector * Time.deltaTime);
		SetRotation(movementVector, stateManager.rigidbody, transform);
	}

	private void SetRotation(Vector3 movementVector, Rigidbody rigidbody, Transform transform)
	{
		if (movementVector.magnitude == 0)
			return;

		rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector.normalized), rotationDampSpeed));

	}

	public override IState CheckTransition()
	{
		if (stateManager.interactionInterface.Interacting)
		{
			stateManager.animator.SetBool("Walking", false);
			return stateManager.states.Interact;
		}

		return this;
	}

	public override void AnimatorUpdate()
	{
		bool walking = stateManager.inputManager.inputsContainer.HorizontalMovementInput != 0 || stateManager.inputManager.inputsContainer.VerticalMovementInput != 0;
		stateManager.animator.SetBool("Walking", walking);
	}

	public override void EnterState()
	{
	}

	public override void ExitState()
	{
	}
}
