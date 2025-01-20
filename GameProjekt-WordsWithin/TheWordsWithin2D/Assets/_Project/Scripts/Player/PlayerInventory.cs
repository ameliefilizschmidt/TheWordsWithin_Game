using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        private List<Object> inventory;

        public PlayerInventory()
        {
            inventory = new List<Object>();
        }
    
        public void AddObject(Object newInventoryObject)
        {
            inventory.Add(newInventoryObject);
        }
        
        public void RemoveObject(Object inventoryObject)
        {
            inventory.Remove(inventoryObject);
        }

        public List<Object> GetInventory()
        {
            return inventory;
        }
    }
}