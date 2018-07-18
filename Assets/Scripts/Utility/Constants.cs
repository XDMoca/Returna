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
        public static readonly string Block = "Block";
        public static readonly string LockOn = "LockOn";
        public static readonly string Interact = "Interact";
        public static readonly string UseQuickItem = "UseQuickItem";
		public static readonly string ItemBarUp = "ItemBarUp";
		public static readonly string ItemBarDown = "ItemBarDown";
		public static readonly string Sleep = "Sleep";
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
