using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;

public class Stair : MonoBehaviour
{
    public PlayerMovement _playerMovement;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _playerMovement.onStair = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _playerMovement.onStair = false;
    }
}
