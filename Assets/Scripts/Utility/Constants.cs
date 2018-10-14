using UnityEngine;

public class Constants
{
	public static readonly string SaveFilePath = Application.persistentDataPath + "/saveData.dat";
	public static readonly string TownSceneName = "Scenes/TownScene";

	public class Inputs
	{
		public static readonly string Horizontal = "Horizontal";
		public static readonly string Vertical = "Vertical";
		public static readonly string Interact = "Interact";
		public static readonly string Inventory = "Inventory";
		public static readonly string Handbrake = "Handbrake";
		public static readonly string Fire = "Fire";
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
		public static readonly string PlayerVehicle = "PlayerVehicle";
		public static readonly string GameController = "GameController";
		public static readonly string AreaLight = "AreaLight";
		public static readonly string VehicleSpawnPoint = "VehicleSpawnPoint";
	}
}
