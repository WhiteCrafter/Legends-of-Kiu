using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SElectScript : MonoBehaviour
{
    public void StartHelmut(){
        SceneManager.LoadScene(9);
    }

    public void StartWolfGang(){
        SceneManager.LoadScene(8);
    }

    public void StartMarkus(){
        SceneManager.LoadScene(10);
    }

    public void StartSelect(){
        SceneManager.LoadScene(7);
    }
    




}
