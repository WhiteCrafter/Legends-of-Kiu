using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outofbounds : MonoBehaviour
{
     public Lscript script;
    // Start is called before the first frame update
    void Start()
    {
        script=GameObject.FindGameObjectWithTag("score").GetComponent<Lscript>();
    }


    public void OnTriggerEnter2D(){
        script.GameOver();
    }
}
