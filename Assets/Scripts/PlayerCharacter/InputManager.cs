using UnityEngine;

public class InputManager : MonoBehaviour
{

	[ReadOnly]
	public InputsContainer inputsContainer;

	void Start()
	{
		inputsContainer = new InputsContainer();
	}

	void Update()
	{
		inputsContainer.ClearInputs();
		CheckInputs();
	}



	private void CheckInputs()
	{
		inputsContainer.HorizontalMovementInput = Input.GetAxisRaw(Constants.Inputs.Horizontal);
		inputsContainer.VerticalMovementInput = Input.GetAxisRaw(Constants.Inputs.Vertical);
		inputsContainer.interactPressed = Input.GetButtonDown(Constants.Inputs.Interact);
	}
}
