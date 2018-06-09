using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatesContainer
{
    public FreeMovementState FreeMovement;
    public AttackState Attack;
    public EvadeState Evade;
    public InteractState Interact;
}
