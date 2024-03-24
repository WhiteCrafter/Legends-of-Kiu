using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class DifficultyManager : MonoBehaviour
{
    public void LoadEasy(){
        SceneManager.LoadScene(1);
    }

    public void LoadMedium(){
        SceneManager.LoadScene(4);
    }

    public void LoadHard(){
        SceneManager.LoadScene(2);
    }

    public void LoadImpossible(){
        SceneManager.LoadScene(3);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
