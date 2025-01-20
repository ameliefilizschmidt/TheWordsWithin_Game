using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FightObject : MonoBehaviour
{
    public int speed = 100;
    public int timeToLive = 30;
    
    private Rigidbody2D _rigidbody;
    private bool _dying = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        Random.Range(speed-2, speed+2);
        
        _rigidbody.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _dying = true;
        print("dying");
    }

    private void FixedUpdate()
    {
        if (_dying)
        {
            print(timeToLive);
            if (timeToLive > 0)
                timeToLive -= 1;
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
