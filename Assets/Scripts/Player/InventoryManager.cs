using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    private InputManager inputManager;
    private PlayerStatusManager playerStatus;

    public List<InventoryItem> items = new List<InventoryItem>();

	private ItemQuickUseBar quickUseBar;

	void Start () {
        playerStatus = GetComponent<PlayerStatusManager>();
        inputManager = GetComponent<InputManager>();
		quickUseBar = GameObject.FindObjectOfType<ItemQuickUseBar>();
		quickUseBar.setItems(items.ToArray());
	}
	
	void Update () {
        CheckInput();
	}

    private void CheckInput()
    {
        if (inputManager.inputsContainer.useQuickItemPressed)
        {
            UseSelectedQuickItem(quickUseBar.GetSelectedItem());
			quickUseBar.setItems(items.ToArray());
		}
		if (inputManager.inputsContainer.itemBarDownPressed)
		{
			quickUseBar.SelectNextItem();
		}
		if (inputManager.inputsContainer.itemBarUpPressed)
		{
			quickUseBar.SelectPreviousItem();
		}
	}

    private void UseSelectedQuickItem(InventoryItem item)
    {
		if (item.count <= 0)
			return;

        --item.count;
        playerStatus.UseItem(item.item);
    }

    [System.Serializable]
    public class InventoryItem
    {
        public ConsumableItem item;
        public int count;
    }
}