[System.Serializable]
public class InputsContainer
{

	[ReadOnly]
	public float HorizontalMovementInput = 0;
	[ReadOnly]
	public float VerticalMovementInput = 0;
	[ReadOnly]
	public bool interactPressed = false;
	[ReadOnly]
	public bool inventoryPressed = false;

	public void ClearInputs()
	{
		HorizontalMovementInput = 0;
		VerticalMovementInput = 0;
		interactPressed = false;
		inventoryPressed = false;
	}
}
