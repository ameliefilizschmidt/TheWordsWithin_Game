using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class FightHandler : MonoBehaviour
{
    [YarnCommand("startFight")]
    public void startFight(string loadThisSceneAfterFight, string winDialogue, string looseDialogue, string topText)
    {
        Savefile.continueInThisSceneAfterFight = loadThisSceneAfterFight;
        Savefile.winDialogue = winDialogue;
        Savefile.looseDialogue = looseDialogue;
        Savefile.topText = topText;

        SceneManager.LoadScene("Fight2");
    }
}
