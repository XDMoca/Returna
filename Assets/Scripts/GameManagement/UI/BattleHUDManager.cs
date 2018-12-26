using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUDManager : MonoBehaviour {

	[SerializeField]
	private Slider playerHealthSlider;
	[SerializeField]
	private Slider enemyHealthSlider;
	[SerializeField]
	private TextMeshProUGUI AmmoText;

	private VehicleHealthManager playerHealth;
	private VehicleHealthManager enemyHealth;

	private VehicleWeaponManager playerWeaponManager;

	private const string ammoDisplayText = "Ammo: {0}/{1}";

	public void InitialiseHealthBars(VehicleHealthManager playerHealth, VehicleHealthManager enemyHealth)
	{
		this.playerHealth = playerHealth;
		this.enemyHealth = enemyHealth;

		playerHealthSlider.maxValue = playerHealth.MaxHealth;
		enemyHealthSlider.maxValue = enemyHealth.MaxHealth;

		playerHealth.OnHealthChange += (s, e) => UpdateHealthBars();
		enemyHealth.OnHealthChange += (s, e) => UpdateHealthBars();
	}

	public void InitialiseAmmoText(VehicleWeaponManager playerWeaponManager)
	{
		this.playerWeaponManager = playerWeaponManager;
		UpdateAmmoText();
		playerWeaponManager.OnAmmoChange += (s, e) => UpdateAmmoText();
	}

	private void UpdateHealthBars()
	{
		playerHealthSlider.value = playerHealth.Health;
		enemyHealthSlider.value = enemyHealth.Health;
	}

	private void UpdateAmmoText()
	{
		this.AmmoText.text = string.Format(ammoDisplayText, playerWeaponManager.currentAmmo, playerWeaponManager.ActiveWeapon.MaxAmmoCount);
	}
}
