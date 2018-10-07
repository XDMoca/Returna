using UnityEngine;

public class ShopMenuManager : MonoBehaviour
{
	public static ShopMenuManager instance = null;
	private ShopItem[] shopItemsToDisplay;

	[SerializeField]
	private GameObject ShopItemButtonPrefab;
	[SerializeField]
	private GameObject ShopCanvasPrefab;
	private ShopCanvas shopCanvasInstance;

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
		shopItemsToDisplay = shopItems;
		shopCanvasInstance = Instantiate(ShopCanvasPrefab).GetComponent<ShopCanvas>();
		foreach (ShopItem shopItem in shopItems)
		{
			GameObject button = Instantiate(ShopItemButtonPrefab);
			button.GetComponent<ShopItemButton>().Initialise(shopItem);
			shopCanvasInstance.AddShopItemButton(button);
		}
	}

	public void CloseShopMenu()
	{
		Destroy(shopCanvasInstance.gameObject);
	}
}
