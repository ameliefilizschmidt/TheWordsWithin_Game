using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Yarn.Unity;

namespace _Project.Scripts
{
    public class Scene : MonoBehaviour
    {
        public int fadeLengthInFrames = 60;
        public int fadeInSpeed = 2;
        public int fadeOutSpeed = 1;
        public RuntimeAnimatorController playThisBeforeSceneSwitch;
        public string sceneNameForInstantSwitch;
        public Volume vignette;

        private UnityEngine.Rendering.Universal.Vignette _vignette;
        private bool _fading;
        private string _loadThisScene;
        private int _initialFadeFrames;
        private const float ScreenIsDarkAtIntensityOf = 0.20f;

        private void Start()
        {
            _vignette = (UnityEngine.Rendering.Universal.Vignette) vignette.profile.components[0];
            _vignette.center.value = new Vector2(3, _vignette.center.value.y);
            _vignette.smoothness.value = 0.4f;
            _vignette.intensity.value = ScreenIsDarkAtIntensityOf;
        
            _vignette.active = true;
            _vignette.center.overrideState = true;
            _vignette.smoothness.overrideState = true;
            _vignette.intensity.overrideState = true;
        

            _initialFadeFrames = fadeLengthInFrames;
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!String.IsNullOrWhiteSpace(sceneNameForInstantSwitch))
                SwitchScene(sceneNameForInstantSwitch);
        }

        [YarnCommand("SwitchScene")]
        // ReSharper disable once UnusedMember.Global -> yarn will call this
        public void SwitchScene(string sceneName)
        {
            _loadThisScene = sceneName;
            _fading = true;
            
            Animator animator = gameObject.GetComponent<Animator>();

            if (animator != null)
                animator.runtimeAnimatorController = playThisBeforeSceneSwitch;

        }
       

        private void FixedUpdate()
        {
            #region fade in

            if (_vignette.intensity.value > 0)
                _vignette.intensity.value -= 0.001f * fadeInSpeed;

            #endregion


            #region fade out

            if (!_fading) return;
        
            if(_vignette.intensity.value > ScreenIsDarkAtIntensityOf)
            {
                PlayerPrefs.SetString("scene", _loadThisScene);
                PlayerPrefs.Save();
                SceneManager.LoadScene(_loadThisScene);
            }
            else
            {
                fadeLengthInFrames -= fadeOutSpeed;
                _vignette.intensity.value = (float)(_initialFadeFrames - fadeLengthInFrames) / _initialFadeFrames;
            }

            #endregion
        }
    }
}