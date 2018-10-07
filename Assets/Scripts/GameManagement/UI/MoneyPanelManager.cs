using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPanelManager : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI MoneyText;
	[SerializeField]
	private Image MoneyPanel;

	private SceneTransitionManager sceneTransitionManager;

	void Awake()
	{
		sceneTransitionManager = GetComponent<SceneTransitionManager>();
		sceneTransitionManager.OnLevelLoad += (s, e) => ChangeMoneyPanelVisibility();
		MoneyText.text = InventoryManager.instance.Money.ToString();
		InventoryManager.instance.OnMoneyChange += (s, e) => UpdateMoneyText();
	}

	void ChangeMoneyPanelVisibility()
	{
		if (sceneTransitionManager.currentSceneType == ESceneType.Arena)
			MoneyPanel.gameObject.SetActive(false);
		else if (sceneTransitionManager.currentSceneType == ESceneType.Town)
			MoneyPanel.gameObject.SetActive(true);
	}

	void UpdateMoneyText()
	{
		MoneyText.text = "$" + InventoryManager.instance.Money.ToString();
	}
}
