using UnityEngine;

public class InventoryMenuManager : MonoBehaviour
{
	public static InventoryMenuManager instance = null;

	[SerializeField]
	private GameObject InventoryItemButtonPrefab;
	[SerializeField]
	private GameObject InventoryCanvasPrefab;
	private InventoryCanvas inventoryCanvasInstance;

	[ReadOnly]
	public bool IsInventoryMenuOpen = false;

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
		HandleInventoryPress();
	}

	private void HandleInventoryPress()
	{
		if (!InputManager.instance.inputsContainer.inventoryPressed)
			return;

		if (InteractionInterface.instance.Interacting)
			return;

		OpenInventoryMenu();
	}

	public void OpenInventoryMenu()
	{
		if (IsInventoryMenuOpen)
			return;

		inventoryCanvasInstance = Instantiate(InventoryCanvasPrefab).GetComponent<InventoryCanvas>();
		foreach (Weapon inventoryItem in InventoryManager.instance.InventoryWeapons)
		{
			GameObject button = Instantiate(InventoryItemButtonPrefab);
			button.GetComponent<InventoryItemButton>().Initialise(inventoryItem);
			inventoryCanvasInstance.AddInventoryItemButton(button);
		}
		inventoryCanvasInstance.SetFirstElementAsActive();
		IsInventoryMenuOpen = true;
	}

	public void UpdateItemDetailPanel(Weapon selectedInventoryItem)
	{
		inventoryCanvasInstance.SetItemDetails(selectedInventoryItem);
	}

	public void UpdateButtons()
	{
		inventoryCanvasInstance.UpdateAllButtonText();
	}

	public void CloseInventoryMenu()
	{
		if (!IsInventoryMenuOpen)
			return;

		Destroy(inventoryCanvasInstance.gameObject);
		IsInventoryMenuOpen = false;
	}
}
