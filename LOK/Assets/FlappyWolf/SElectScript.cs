using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SElectScript : MonoBehaviour
{
    public void StartHelmut(){
        SceneManager.LoadScene(2);
    }

    public void StartWolfGang(){
        SceneManager.LoadScene(1);
    }

    public void StartMarkus(){
        SceneManager.LoadScene(3);
    }

    public void StartSelect(){
        SceneManager.LoadScene(4);
    }
    




}
