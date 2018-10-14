using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGameDataManager : MonoBehaviour
{
	public static SaveGameDataManager instance = null;

	void Awake()
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

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			Save();
		}
	}

	void Save()
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fileStream = File.Open(Constants.SaveFilePath, FileMode.OpenOrCreate);
		SaveData saveData = new SaveData()
		{
			Money = InventoryManager.instance.Money,
			InventoryWeapons = InventoryManager.instance.InventoryWeapons.Select(Weapon => Weapon.ID).ToArray(),
			EquippedWeapon = InventoryManager.instance.EquippedWeapon.ID
		};
		formatter.Serialize(fileStream, saveData);
		fileStream.Close();
		NotificationHandler.instance.DisplayNotification("Save Successful");
	}
}

[System.Serializable]
public class SaveData
{
	public int Money;
	public int[] InventoryWeapons;
	public int EquippedWeapon;
}