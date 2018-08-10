using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputsContainer {

    [ReadOnly]
    public float HorizontalMovementInput = 0;
    [ReadOnly]
    public float VerticalMovementInput = 0;
    [ReadOnly]
    public bool attackPressed = false;
    [ReadOnly]
    public bool blockPressed = false;
	[ReadOnly]
	public bool blockReleased = false;
	[ReadOnly]
    public bool lockOnPressed = false;
    [ReadOnly]
    public bool interactPressed = false;
    [ReadOnly]
    public bool useQuickItemPressed = false;
	[ReadOnly]
	public bool itemBarUpPressed = false;
	[ReadOnly]
	public bool itemBarDownPressed = false;
	[ReadOnly]
	public bool sleepPressed = false;

	public void ClearInputs()
    {
        HorizontalMovementInput = 0;
        VerticalMovementInput = 0;
        attackPressed = false;
        blockPressed = false;
		blockReleased = false;
		lockOnPressed = false;
        interactPressed = false;
        useQuickItemPressed = false;
		itemBarUpPressed = false;
		itemBarDownPressed = false;
		sleepPressed = false;
    }
}
