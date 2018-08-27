using UnityEngine;

public class BattleSetupManager : MonoBehaviour
{
	[SerializeField]
	private GameObject playerVehicle;

	private GameObject enemyVehicle;

	public void SetupBattleScenario(GameObject enemyVehicle)
	{
		this.enemyVehicle = enemyVehicle;
	}

	public void SetupBattle()
	{
		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(Constants.Tags.VehicleSpawnPoint);
		Instantiate(playerVehicle, spawnPoints[0].transform.position, spawnPoints[0].transform.rotation);
		Instantiate(enemyVehicle, spawnPoints[1].transform.position, spawnPoints[1].transform.rotation);
	}
}