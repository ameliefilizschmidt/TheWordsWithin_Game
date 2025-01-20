using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using _Project.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn;
using Yarn.Unity;

public class Savefile : MonoBehaviour
{
    private List<string> persistThoseVariables;

    public DialogueRunner dialogueRunner;
    public Power powerSlider;
    public static bool beerCollected;
    public static string continueInThisSceneAfterFight;
    public static string winDialogue;
    public static string looseDialogue;
    public static string topText;
    public static string winText;
    public static string looseText;

    private static float _power;

    public static float power
    {
        get
        {
            return _power;
        }
        set
        {
            PlayerPrefs.SetFloat("power", value);
            PlayerPrefs.Save();
            _power = value;
        }
    }

    public void resetSettings()
    {
        dialogueRunner.variableStorage.Clear();
        PlayerPrefs.DeleteAll();
        loadSettings();
        PlayerPrefs.SetString("scene", "Tutorial");
        PlayerPrefs.Save();
    }

    [YarnCommand("save")]
    public void SaveVariable(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        dialogueRunner.variableStorage.SetValue(key, value);
        PlayerPrefs.Save();
    }

    private void loadSettings()
    {
        power = PlayerPrefs.GetFloat("power");
        beerCollected = string.Equals(PlayerPrefs.GetString("$beer_collected"), "true", StringComparison.OrdinalIgnoreCase);
        
        powerSlider.GetComponent<Power>().ChangeSlider(Convert.ToString(power, CultureInfo.CurrentCulture));
    }

    public void writeSettingsToYarn()
    {
        foreach (string element in persistThoseVariables)
            dialogueRunner.variableStorage.SetValue(element, PlayerPrefs.GetString(element));
            
    }
    
    // Start is called before the first frame update
    void Start()
    {
        persistThoseVariables = new List<string>();
        persistThoseVariables.Add("$beer_collected");
        persistThoseVariables.Add("$visitedNeighbourCompletly");
        persistThoseVariables.Add("$visitedNeighbour");
        persistThoseVariables.Add("$knife_collected");
        persistThoseVariables.Add("$fromStartToBar");
        persistThoseVariables.Add("$fromStartToMom");
        persistThoseVariables.Add("$fromStartToPark");
        persistThoseVariables.Add("$visitedMum");
        persistThoseVariables.Add("$warpToPolice");
        persistThoseVariables.Add("$warpToWayPolice");
        persistThoseVariables.Add("$pudding_collected");
        persistThoseVariables.Add("$friendVisited");
        persistThoseVariables.Add("$foughtPolice");
        
        persistThoseVariables.Add("$fromBarToPoliceStation");
        persistThoseVariables.Add("$fromBarToWayPolice");
        persistThoseVariables.Add("$fromBarToPark");
        persistThoseVariables.Add("$allowBarExit");
        persistThoseVariables.Add("$entryBar");
        
        persistThoseVariables.Add("$greenLab");
        persistThoseVariables.Add("$orangeLab");
        persistThoseVariables.Add("$redLab");
        persistThoseVariables.Add("$visitedPolice");

        persistThoseVariables.Add("$self");
        persistThoseVariables.Add("$self1");
        persistThoseVariables.Add("$self2");
        persistThoseVariables.Add("$self3");
        persistThoseVariables.Add("$self4");

        
            
        SceneManager.sceneLoaded += onSceneLoaded;
        
        loadSettings();
        writeSettingsToYarn();
    }

    private void onSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log("Gu");
        writeSettingsToYarn();

        if(SceneManager.GetActiveScene().name != "Fight2" && !string.IsNullOrWhiteSpace(winDialogue))
        {
            dialogueRunner.startNode = winDialogue;
            winDialogue = "";
            dialogueRunner.StartDialogue();
        }
        else if (SceneManager.GetActiveScene().name != "Fight2" && !string.IsNullOrWhiteSpace(looseDialogue))
        {
            dialogueRunner.startNode = looseDialogue;
            looseDialogue = "";
            dialogueRunner.StartDialogue();
        }
    }
}
