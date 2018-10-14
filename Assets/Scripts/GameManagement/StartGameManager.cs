using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
	public static StartGameManager instance = null;

	public Weapon[] AllWeapons;

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

	public void LoadSavedGame()
	{
		if (!SaveFileExists())
			return;

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream fileStream = File.Open(Constants.SaveFilePath, FileMode.Open);
		SaveData saveData = (SaveData)formatter.Deserialize(fileStream);
		fileStream.Close();
		CurrentGameDataManager.instance.Money = saveData.Money;
		CurrentGameDataManager.instance.EquippedWeapon = AllWeapons.Where(weapon => weapon.ID == saveData.EquippedWeapon).First();
		CurrentGameDataManager.instance.InventoryWeapons = AllWeapons.Where(weapon => saveData.InventoryWeapons.Contains(weapon.ID)).ToList();
		LoadGameMode();
	}

	public void StartNewGame()
	{
		CurrentGameDataManager.instance.Money = 0;
		CurrentGameDataManager.instance.EquippedWeapon = AllWeapons.Where(weapon => weapon.ID == 1).First();
		CurrentGameDataManager.instance.InventoryWeapons = AllWeapons.Where(weapon => weapon.ID == 1).ToList();
		LoadGameMode();
	}

	void LoadGameMode()
	{
		SceneManager.LoadScene(Constants.TownSceneName);
	}

	public bool SaveFileExists()
	{
		return File.Exists(Constants.SaveFilePath);
	}
}
