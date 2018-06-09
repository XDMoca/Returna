using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnManager : MonoBehaviour {

    [ReadOnly]
    public bool LockedOn = false;
    [SerializeField]
    private float lockOnRange;
    [SerializeField]
    private float lockOnWidth;
    [HideInInspector]
    public Transform LockOnTarget;
    private InputManager inputManager;
    [SerializeField]
    private bool DebugMode;

    void Start () {
        inputManager = GetComponent<InputManager>();
	}
	
	void Update () {
        CheckIfTargetIsNull();
        CheckInput();    
	}

    void CheckIfTargetIsNull()
    {
        if (LockOnTarget == null)
            DisableLockOn();
    }

    void CheckInput()
    {
        if (!inputManager.inputsContainer.lockOnPressed)
            return;

        if (LockedOn)
            DisableLockOn();
        else
            LockOn();
    }

    void DisableLockOn()
    {
        LockedOn = false;
        LockOnTarget = null;
    }

    void LockOn()
    {
        if(DebugMode)
            DebugHelper.DrawBoxCastBox(transform.position, new Vector3(lockOnWidth, 1, 0), transform.forward, transform.rotation, lockOnRange, Color.green, 0.5f);

        RaycastHit hit;
        bool didHitSomething = Physics.BoxCast(transform.position, new Vector3(lockOnWidth, 1, 0), transform.forward,out hit, transform.rotation, lockOnRange, LayerMask.GetMask(Constants.Layers.Enemy));
        if (didHitSomething)
        {
            LockedOn = true;
            LockOnTarget = hit.transform;
        }
    }
}
