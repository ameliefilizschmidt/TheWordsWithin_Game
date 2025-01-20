using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int maxHp;
    public Healthbar Healthbar;
    public GameObject player;

    public GameObject bullet;
    public int bulletSpeed = 1;

    public FightSelector fightSelector;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        
        hp = maxHp;
        Healthbar.SetHealth(hp, maxHp);
    }

    private int counter = 0;
    
    private void FixedUpdate()
    {
        counter += 1;

        if (counter < 10) return;
        counter = 0;
        
        GameObject temporaryBulletHandler = Instantiate(bullet ,gameObject.transform.position, gameObject.transform.rotation);
         
        Rigidbody2D temporaryRigidBody = temporaryBulletHandler.GetComponent<Rigidbody2D>();

        if (_camera is null) return;
        
        Vector2 position = gameObject.transform.position;
        
        Vector2 worldMousePosition = player.transform.position;
        Vector2 direction = worldMousePosition - position;
        direction.Normalize();
        
        temporaryRigidBody.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Friendly")) return;
        
        hp -= 1;
        Healthbar.SetHealth(hp, maxHp);
        
        if(hp <= 0)
            Destroy(gameObject);
        
        fightSelector.moveLeft();
    }
}
