using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class DestroyIfCollectedAlready : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    public string varName;

    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner = GameObject.Find("Dialogue Runner").GetComponent<DialogueRunner>();
        if (string.Equals(PlayerPrefs.GetString(varName), "true"))
            Destroy(gameObject);
    }

}
