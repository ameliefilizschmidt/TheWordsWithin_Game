using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

// thanks to bobbaluba https://forum.unity.com/threads/play-mode-tests-scenehandling.751049/
public class LoadSceneAttribute : NUnitAttribute, IOuterUnityTestAction
{
    private string scene;

    public LoadSceneAttribute(string scene) => this.scene = scene;

    IEnumerator IOuterUnityTestAction.BeforeTest(ITest test)
    {
        Debug.Assert(scene.EndsWith(".unity"));
        yield return EditorSceneManager.LoadSceneAsyncInPlayMode(scene, new LoadSceneParameters(LoadSceneMode.Single));
    }

    IEnumerator IOuterUnityTestAction.AfterTest(ITest test)
    {
        EditorSceneManager.UnloadSceneAsync(scene);
        yield return null;
    }
}