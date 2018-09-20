using UnityEngine;

public class PlayerVehicleInputManager : AVehicleInputManager
{
	protected override void CheckInputs()
	{
		HorizontalMovementInput = Input.GetAxisRaw(Constants.Inputs.Horizontal);
		VerticalMovementInput = Input.GetAxisRaw(Constants.Inputs.Vertical);
		handbrakeHeld = Input.GetButton(Constants.Inputs.Handbrake);
		fireHeld = Input.GetButton(Constants.Inputs.Fire);
	}
}
