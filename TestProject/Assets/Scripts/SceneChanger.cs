using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Very Simple Scene Changer to switch between screens
/// </summary>
public class SceneChanger : MonoBehaviour
{
    public void SetDesignScene()
    {
        SceneManager.LoadScene(0);
    }
    public void SetProblemScene()
    {
        SceneManager.LoadScene(1);
    }

}
