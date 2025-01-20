using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;

namespace _Project.Scripts.Items
{
    public class Fridge : MonoBehaviour
    {
        public Sprite open;
        public Sprite closed;
        
        private DialogueRunner _dialogueRunner;
        private LootBox _lootBox;
        private SpriteRenderer _spriteRenderer;
        private bool inRange = false;
        private bool ePressed = false;
        
        public Fridge()
        {
        
        }

        private void Start()
        {
            _dialogueRunner = GameObject.Find("Dialogue Runner")?.GetComponent<DialogueRunner>(); 
            _spriteRenderer = GetComponent<SpriteRenderer>();
        
            _lootBox = gameObject.AddComponent<LootBox>();

            List<string> fridgeItemNames = new List<string> {"Brot", "Pudding", "Wein"};

            foreach (InventoryObject fridgeItem in fridgeItemNames.Select(unused => gameObject.AddComponent<InventoryObject>()))
            {
                _lootBox.lootableObjects.Add(fridgeItem);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            inRange = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            inRange = false;
        }

        private void Update()
        {
            ePressed = Input.GetKeyDown(KeyCode.E);
            
            if (inRange && ePressed && !_dialogueRunner.IsDialogueRunning)
            {
                _dialogueRunner.startNode = "Fridge";
                _dialogueRunner.StartDialogue();
            }
        }

        [YarnCommand("openFridge")]
        public void OpenDoor()
        {
            _spriteRenderer.sprite = open;
        }

        [YarnCommand("closeFridge")]
        public void CloseDoor()
        {
            _spriteRenderer.sprite = closed;
        }
    }
}