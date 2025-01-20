using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogStarter : MonoBehaviour
{
    
    public String startThisNode;
    public bool requireButtonPress = true;
    public GameObject spawnThis;
    public Vector3 spawnOffset = new Vector3(0.6f, 0.6f, 0);
    
    private DialogueRunner _dialogueRunner;
    private bool _inRange = false;
    private bool _ePressed = false;

    private void Start()
    {
        _dialogueRunner = GameObject.Find("Dialogue Runner")?.GetComponent<DialogueRunner>(); 
        
        if (spawnThis != null)
        {
            spawnThis = Instantiate(spawnThis, gameObject.transform.position + spawnOffset, gameObject.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _inRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _inRange = false;
    }

    private void Update()
    {
        _ePressed = Input.GetKeyDown(KeyCode.E);

        bool requirementsSet = (_ePressed || !requireButtonPress);
        
        if (_inRange && requirementsSet && !_dialogueRunner.IsDialogueRunning)
        {
            // attach Power if asked
            if(startThisNode.Contains("*"))
            {
                string powerText = "Nice";
                if (Savefile.power > 70)
                    powerText = "Hard";
                else if (Savefile.power > 40)
                    powerText = "Normal";
                

                startThisNode = startThisNode.Replace("*", powerText);
            }
            
            Destroy(spawnThis);
            _dialogueRunner.startNode = startThisNode;
            _dialogueRunner.StartDialogue();
        }
    }
}
