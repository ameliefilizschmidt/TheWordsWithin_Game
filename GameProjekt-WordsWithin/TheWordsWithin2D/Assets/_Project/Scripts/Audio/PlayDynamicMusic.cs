using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDynamicMusic : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool isAPlayer = other.gameObject.CompareTag("Player");
        if (isAPlayer)
        {
            Debug.Log("Musik an!");
            FindObjectOfType<AudioManager>().Play("WaldMusic");
            FindObjectOfType<AudioManager>().Play("StadtMusic");
            FindObjectOfType<AudioManager>().Play("BarMusic");
            FindObjectOfType<AudioManager>().Play("HausMusic");
            FindObjectOfType<AudioManager>().Play("PolizeiMusic");
            FindObjectOfType<AudioManager>().Play("WasserMusic");
            FindObjectOfType<AudioManager>().Play("MazeMusic");
        }

        
    }

}
