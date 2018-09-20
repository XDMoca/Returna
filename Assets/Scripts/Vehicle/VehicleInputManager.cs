using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AVehicleInputManager : MonoBehaviour {

	[ReadOnly]
	public float HorizontalMovementInput = 0;
	[ReadOnly]
	public float VerticalMovementInput = 0;
	[ReadOnly]
	public bool handbrakeHeld = false;
	[ReadOnly]
	public bool fireHeld = false;

	void Update()
	{
		ClearInputs();
		CheckInputs();
	}

	protected void ClearInputs()
	{
		HorizontalMovementInput = 0;
		VerticalMovementInput = 0;
		handbrakeHeld = false;
		fireHeld = false;
	}

	protected abstract void CheckInputs();
}
