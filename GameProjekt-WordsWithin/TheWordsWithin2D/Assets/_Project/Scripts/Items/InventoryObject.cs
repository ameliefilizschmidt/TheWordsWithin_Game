using _Project.Scripts.Player;
using UnityEngine;
using Yarn.Unity;

namespace _Project.Scripts.Items
{
    public class InventoryObject : MonoBehaviour
    {
        public GameObject player;
        private string _name;

        public InventoryObject(string name)
        {
            _name = name;
        }
        
        [YarnCommand("pickupObject")]
        // ReSharper disable once UnusedMember.Global -> yarn will call this
        public void PickupObject(string objectName, string destroyAfterPickup = "destroy")
        {
            _name = objectName;
            
            PlayerInventory playerInventory = player?.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddObject(this);
            }
            else
            {
                Debug.LogError($"Player has not been assigned. Can't add {_name} to inventory.");
            }
        
            Debug.Log($"{_name} has been added to the inventory!");
            
            if(destroyAfterPickup == "destroy")
            {
                Destroy(gameObject);
                PlayerPrefs.SetString("$water_collected", "true");
            }
        }
    }
}
