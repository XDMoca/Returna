using UnityEngine;

public class PlayerVehicleInputManager : MonoBehaviour
{

	[ReadOnly]
	public float HorizontalMovementInput = 0;
	[ReadOnly]
	public float VerticalMovementInput = 0;
	[ReadOnly]
	public bool handbrakePressed = false;

	void Update()
	{
		ClearInputs();
		CheckInputs();
	}



	private void CheckInputs()
	{
		HorizontalMovementInput = Input.GetAxisRaw(Constants.Inputs.Horizontal);
		VerticalMovementInput = Input.GetAxisRaw(Constants.Inputs.Vertical);
		handbrakePressed = Input.GetButtonDown(Constants.Inputs.Handbrake);
	}

	public void ClearInputs()
	{
		HorizontalMovementInput = 0;
		VerticalMovementInput = 0;
		handbrakePressed = false;
	}
}
