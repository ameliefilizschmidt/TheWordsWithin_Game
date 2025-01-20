using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSound : MonoBehaviour
{
   public string chatSoundName;
   
   public void playChatSound()
   {
      Debug.Log("playChatSound");
      FindObjectOfType<AudioManager>().Play(chatSoundName);
   }
}
