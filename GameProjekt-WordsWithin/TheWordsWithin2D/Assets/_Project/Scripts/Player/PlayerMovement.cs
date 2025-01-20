using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

// https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/

namespace _Project.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody2D body;

        float horizontal;
        float vertical;
        float moveLimiter = 0.7f;

        public float runSpeed = 20.0f;
        public bool onStair = false;
        public ParticleSystem particleSystem;
        public List<ColorMap> colorMaps;
        public static string runSoundName = "run";

        private string cacheRunSound = "run";
        private Animator _animator;
        private DialogueRunner _dialogueRunner;
        private static readonly int YVelocity = Animator.StringToHash("yVelocity");
        private static readonly int XVelocity = Animator.StringToHash("xVelocity");
        private static string _playerTeleport;
        private bool DialogueInScene = true;
        private bool _particleSystemInScene = false;
        private Color _defaultParticleColor;
        private int forceYMovement = 0;
        private int forceXMovement = 0;

        void Start ()
        {
            body = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _dialogueRunner = FindObjectOfType<DialogueRunner>();
        
            if(_dialogueRunner == null)
            {
                Debug.LogError("UI is missing from scene " + SceneManager.GetActiveScene().name);
                DialogueInScene = false;
            }

            _particleSystemInScene = particleSystem != null;
            if (_particleSystemInScene)
                _defaultParticleColor = particleSystem.main.startColor.color;

            if (!string.IsNullOrWhiteSpace(_playerTeleport))
            {
                gameObject.transform.position = GameObject.Find(_playerTeleport).transform.position;
                _playerTeleport = null;
            }
        }

        void Update()
        {
            // Gives a value between -1 and 1
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        }

        [YarnCommand("setSpawn")]
        public void setSpawn(string spawn)
        {
            _playerTeleport = spawn;
        }

        [YarnCommand("moveX")]
        public void moveX(string x)
        {
            forceXMovement = Convert.ToInt32(x);
        }

        [YarnCommand("moveY")]
        public void moveY(string y)
        {
            forceYMovement = Convert.ToInt32(y);
        }
        
        void FixedUpdate()
        {
            if (DialogueInScene && _dialogueRunner.IsDialogueRunning)
            {
                particleSystem.Stop();
                
                float forceXSpeed = 0;

                if(forceXMovement > 0)
                {
                    forceXSpeed = runSpeed;
                    forceXMovement -= 1;
                }
                else if(forceXMovement < 0)
                {
                    forceXSpeed = runSpeed * -1;
                    forceXMovement += 1;
                }
                else
                {

                }

                float forceYSpeed = 0;

                if (forceYMovement > 0)
                {
                    forceYSpeed = runSpeed;
                    forceYMovement -= 1;
                }
                else if (forceYMovement < 0)
                {
                    forceYSpeed = runSpeed * -1;
                    forceYMovement += 1;
                }
                else
                {

                }

                body.velocity = new Vector2(forceXSpeed, forceYSpeed);


                Animation();
                return;
            }

            if (onStair)
            {
                //vertical = 0;

                if (horizontal < 0) vertical = 0.2f;
                if (horizontal > 0) vertical = -0.2f;
            }
            
            else if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            bool isMoving = horizontal != 0 || vertical != 0;

            if(_particleSystemInScene && isMoving)
            {
                FindObjectOfType<AudioManager>().Play(runSoundName);

                if (!particleSystem.isPlaying)
                {
                    particleSystem.Play();  
                }
                    
                
            
                ParticleSystem.MainModule settings = particleSystem.main;

                Color underPlayer = _defaultParticleColor;
            
                if (colorMaps.Any(w => w.activateColor))
                {
                    underPlayer = colorMaps.Where(w => w.activateColor).Select(s => s.activeColor).First();
                }
           
                settings.startColor = new ParticleSystem.MinMaxGradient(underPlayer);
            }
            else
            {
                particleSystem.Stop();
                FindObjectOfType<AudioManager>().Stop(runSoundName);
            }

            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            Animation();
        }

        private void Animation()
        {
           
            if (_animator == null)
            {
                Console.WriteLine("Animator missing");
                return;
            }
        
            _animator.SetInteger(YVelocity,Convert.ToInt32(body.velocity.y) * -1);

            int x = Convert.ToInt32(body.velocity.x);
            if (x < 0) x *= -1;
            _animator.SetInteger(XVelocity, x);
        
            this.FlipCharacter();
        }
    
        private void FlipCharacter()
        {
            Vector3 tmpPlayerScale = transform.localScale;

            if (PlayerNeedsToTurn(tmpPlayerScale, body))
            {
                TurnPlayer(tmpPlayerScale, this.gameObject);
            }
        }
    
        private bool PlayerNeedsToTurn(Vector3 pPlayerDirection, Rigidbody2D pBody)
        {
            return (RunningLeft(pBody) && pPlayerDirection.x > 0 || RunningRight(pBody) && pPlayerDirection.x < 0);
        }
    
        private void TurnPlayer(Vector3 pPlayerDirection, GameObject pTransformThis)
        {
            pPlayerDirection.x *= -1;
            pTransformThis.transform.localScale = pPlayerDirection;
        }
    
        private static bool RunningLeft(Rigidbody2D pBody)
        {
            return pBody.velocity.x < 0;
        }

        private static bool RunningRight(Rigidbody2D pBody)
        {
            return pBody.velocity.x > 0;
        }
    }
}
