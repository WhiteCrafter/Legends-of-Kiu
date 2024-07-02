using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class DifficultyManager : MonoBehaviour
{
    public void LoadEasy(){
        SceneManager.LoadScene(2);
    }

    public void LoadMedium(){
        SceneManager.LoadScene(3);
    }

    public void LoadHard(){
        SceneManager.LoadScene(4);
    }

    public void LoadImpossible(){
        SceneManager.LoadScene(5);
    }

    public void LoadMultiplayer(){
        SceneManager.LoadScene(7);
    }

    public void LoadSingleplayer(){
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
