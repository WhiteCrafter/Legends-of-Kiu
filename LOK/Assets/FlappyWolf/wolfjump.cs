using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfjump : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float wolfhump;
    public Lscript script;

    public bool wolfIsAlive=true;


    // Start is called before the first frame update
    void Start()
    {
        script=GameObject.FindGameObjectWithTag("score").GetComponent<Lscript>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))&&wolfIsAlive){
           myrigidbody.velocity = Vector2.up * wolfhump; 
        }
       
    }

    public void OnCollisionEnter2D(Collision2D collision){
        script.GameOver();
        wolfIsAlive=false;
    }
}
