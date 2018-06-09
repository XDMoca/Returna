using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public class Inputs
    {
        public static readonly string Horizontal = "Horizontal";
        public static readonly string Vertical = "Vertical";
        public static readonly string Attack = "Attack";
        public static readonly string Evade = "Evade";
        public static readonly string LockOn = "LockOn";
        public static readonly string Interact = "Interact";
    }

    public class Layers
    {
        public static readonly string Player = "Player";
        public static readonly string Enemy = "Enemy";
        public static readonly string Interactable = "Interactable";
    }

    public class Tags
    {
        public static readonly string Player = "Player";
        public static readonly string GameController = "GameController";
        public static readonly string AreaLight = "AreaLight";
    }
}
