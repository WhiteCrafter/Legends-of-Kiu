using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class DifficultyManager : MonoBehaviour
{

    public void Update(){
      if(Input.GetKeyDown(KeyCode.Escape)){
      if(SceneManager.GetActiveScene().buildIndex==7||SceneManager.GetActiveScene().buildIndex==1){       
         SceneManager.LoadScene(0);
      }
      else{
        SceneManager.LoadScene(1);
      }
            
        }
    }
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
