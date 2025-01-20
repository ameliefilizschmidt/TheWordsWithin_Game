using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Items;
using _Project.Scripts.Player;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    public List<InventoryObject> lootableObjects;

    public LootBox()
    {
        lootableObjects = new List<InventoryObject>();
    }

    public void loot(PlayerInventory playerInventory, InventoryObject lootThis)
    {
        playerInventory.AddObject(lootThis);
        lootableObjects.Remove(lootThis);
    }

    public void restock(PlayerInventory playerInventory, InventoryObject restockThis)
    {
        lootableObjects.Add(restockThis);
        playerInventory.RemoveObject(restockThis);
    }
}
