using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OpenScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
