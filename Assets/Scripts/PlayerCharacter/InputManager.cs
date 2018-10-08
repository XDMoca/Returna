using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager instance = null;
	[ReadOnly]
	public InputsContainer inputsContainer;


	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

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
