using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Lscript script;

    // Start is called before the first frame update
    void Start()
    {
        script=GameObject.FindGameObjectWithTag("score").GetComponent<Lscript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            script.AddScore(1);
    
        

    }
}
