using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Lscript : MonoBehaviour
{
    public int playerscore;
    public Text scoreText;

    public AudioSource coming;
    public GameObject gameOverScreen;

    public AudioSource bgmusic;

    public AudioSource tenPoints;
    private bool bgisplaying=true;
    private bool iscoming=true;
    public GameObject Tutorial;

    void Start(){
        bgmusic.Play();

    }

    void Update(){
        if(!bgmusic.isPlaying&&bgisplaying){
            bgmusic.Play();
        }

        
        
    }
    
    [ContextMenu("increase score")]
    public void AddScore(int scoretoadd){
        playerscore=playerscore+scoretoadd;
        if(playerscore%10==0){
            tenPoints.Play();
        }

        if(playerscore>=2){
            Tutorial.SetActive(false);
        }
        
        scoreText.text=playerscore.ToString();
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(){
        bgisplaying=false;
        bgmusic.Stop();
        if(iscoming){
           coming.Play(); 
        }
        iscoming=false;
        gameOverScreen.SetActive(true);

   }

    public void QuitGame(){
        Application.Quit();
    }
     
    
   

}
