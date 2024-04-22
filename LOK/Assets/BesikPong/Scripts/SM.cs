using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM : MonoBehaviour
{
    void Start(){

        StartCoroutine(NextScene());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NextScene(){
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(5);
    }
}