using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCanvas : MonoBehaviour
{
	[SerializeField]
	private GameObject InventoryContent;
	[SerializeField]
	private TextMeshProUGUI ItemDetailNameText;
	[SerializeField]
	private TextMeshProUGUI ItemDetailDamageText;
	[SerializeField]
	private TextMeshProUGUI ItemDetailFireRateText;
	[SerializeField]
	private TextMeshProUGUI ItemDetailDescriptionText;

	public void AddInventoryItemButton(GameObject inventoryItemButton)
	{
		inventoryItemButton.transform.SetParent(InventoryContent.transform, false);
	}

	public void SetFirstElementAsActive()
	{
		EventSystem.current.SetSelectedGameObject(InventoryContent.transform.GetChild(0).gameObject);
	}

	public void UpdateAllButtonText()
	{
		InventoryItemButton[] buttons = InventoryContent.transform.GetComponentsInChildren<InventoryItemButton>();
		foreach (InventoryItemButton button in buttons)
		{
			button.SetTextValues();
		}
	}

	public void SetItemDetails(Weapon selectedInventoryItem)
	{
		ItemDetailNameText.text = selectedInventoryItem.Name;
		ItemDetailDamageText.text = "Damage: " + selectedInventoryItem.Name;
		ItemDetailFireRateText.text = "Fire Rate: " + selectedInventoryItem.FireRate;
		ItemDetailDescriptionText.text = selectedInventoryItem.Description;
	}
}