using UnityEngine;

public class ShopMenuManager : MonoBehaviour
{
	public static ShopMenuManager instance = null;

	[SerializeField]
	private GameObject ShopItemButtonPrefab;
	[SerializeField]
	private GameObject ShopCanvasPrefab;
	private ShopCanvas shopCanvasInstance;

	[ReadOnly]
	public bool IsShopMenuOpen = false;

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

	public void OpenShopMenu(ShopItem[] shopItems)
	{
		if (IsShopMenuOpen)
			return;

		shopCanvasInstance = Instantiate(ShopCanvasPrefab).GetComponent<ShopCanvas>();
		foreach (ShopItem shopItem in shopItems)
		{
			GameObject button = Instantiate(ShopItemButtonPrefab);
			button.GetComponent<ShopItemButton>().Initialise(shopItem);
			shopCanvasInstance.AddShopItemButton(button);
		}
		shopCanvasInstance.SetFirstElementAsActive();
		IsShopMenuOpen = true;
	}

	public void UpdateItemDetailPanel(ShopItem selectedShopItem)
	{
		shopCanvasInstance.SetItemDetails(selectedShopItem);
	}

	public void CloseShopMenu()
	{
		if (!IsShopMenuOpen)
			return;

		Destroy(shopCanvasInstance.gameObject);
		IsShopMenuOpen = false;
	}
}
