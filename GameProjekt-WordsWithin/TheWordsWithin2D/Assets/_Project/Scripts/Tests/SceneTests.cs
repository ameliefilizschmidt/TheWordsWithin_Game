using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace _Project.Scripts.Tests
{
    public class SceneTests
    {
        private const string TestThisScene = "Assets/_Project/Scenes/Start.unity";
    
    
        [UnityTest]
        [LoadScene(TestThisScene)]
        public IEnumerator PlayerIsInScene()
        {
            GameObject a = GameObject.Find("Player"); 
            Debug.Assert(a != null); 
            yield return null;
        }
    
        [UnityTest]
        [LoadScene(TestThisScene)]
        public IEnumerator WarpIsInScene()
        {
            GameObject a = GameObject.Find("WarpToNextScene"); 
            Debug.Assert(a != null); 
            yield return null;
        }
    
        [UnityTest]
        [LoadScene(TestThisScene)]
        public IEnumerator UIIsInScene()
        {
            GameObject a = GameObject.Find("UI"); 
            Debug.Assert(a != null); 
            yield return null;
        }
    
        [UnityTest]
        [LoadScene(TestThisScene)]
        public IEnumerator CameraIsInScene()
        {
            GameObject a = GameObject.Find("Main Camera"); 
            Debug.Assert(a != null); 
            yield return null;
        }
    }
}


