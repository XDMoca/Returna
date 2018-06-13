using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    private InputManager inputManager;
    private PlayerStatusManager playerStatus;

    public List<InventoryItem> items = new List<InventoryItem>();

	void Start () {
        playerStatus = GetComponent<PlayerStatusManager>();
        inputManager = GetComponent<InputManager>();
	}
	
	void Update () {
        CheckInput();
	}

    private void CheckInput()
    {
        if (inputManager.inputsContainer.inventoryPressed)
        {
            UseItem(items[0]);
        }
    }

    private void UseItem(InventoryItem item)
    {
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