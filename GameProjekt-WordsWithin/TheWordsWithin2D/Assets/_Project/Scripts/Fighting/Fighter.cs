using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts
{
    public class Fighter : MonoBehaviour
    {
        [FormerlySerializedAs("Bubble")] public GameObject bubble;
        [FormerlySerializedAs("BubbleSpeed")] public float bubbleSpeed = 300;
        public FightSelector fightSelector;
        
        private Camera _camera;
        private bool _shooting = false;

        private void Start()
        {
            _camera = Camera.main;
        }

        // Update is called once per frame
        private void Update()
        {
            if(Input.GetButtonDown("Fire1")|| Input.GetKeyDown(KeyCode.Space))
            {
                _shooting = true;
            }
        }

        private void FixedUpdate()
        {
            if (!_shooting) return;
        
            _shooting = false;
            
            GameObject temporaryBulletHandler = Instantiate(bubble ,gameObject.transform.position, gameObject.transform.rotation);
         
            Rigidbody2D temporaryRigidBody = temporaryBulletHandler.GetComponent<Rigidbody2D>();

            if (_camera is null) return;
        
            Vector2 position = gameObject.transform.position;
        
            Vector2 worldMousePosition = _camera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y));
            Vector2 direction = worldMousePosition - position;
            direction.Normalize();
        
            temporaryRigidBody.GetComponent<Rigidbody2D>().AddForce(direction * bubbleSpeed);


            // Destroy(Temporary_Bullet_Handler, 10.0f);

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Hostile")) return;
        
            fightSelector.moveRight();
        }
    }
}
