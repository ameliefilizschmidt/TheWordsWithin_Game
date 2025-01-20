using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;
using Yarn.Unity;

public class Gamestation : MonoBehaviour
{
    public float zoomSpeed = 4;
    public PlayerMovement snake;
    public PlayerMovement player;

    private float targetZoom = 5.84f;
    private float targetX = 0;
    private float targetY = 0.68f;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void StandardView()
    {
        _camera.orthographicSize = 5.84f;
        _camera.transform.position =
            new Vector3(0, 0.68f, _camera.transform.position.z);
    }
    
    [YarnCommand("GameView")]
    public void GameView()
    {
        targetZoom = 0.28f;
        targetX = 0.2f;
        targetY = 3.93f;
        snake.enabled = true;
        player.enabled = false;
    }

    private void FixedUpdate()
    {
        if(_camera.orthographicSize > targetZoom)
            _camera.orthographicSize -= 0.01f * zoomSpeed;

        Vector3 cameraPosition = _camera.transform.position;
        float x = cameraPosition.x;
        float y = cameraPosition.y;

        if (x < targetX)
            x += 0.01f * zoomSpeed;
        
        if (y < targetY)
            y += 0.01f * zoomSpeed;

        Transform transform1 = _camera.transform;
        transform1.position =
            new Vector3(x, y, transform1.position.z);
    }
}
