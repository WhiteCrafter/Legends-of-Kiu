using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{

    public float initialSpeed=10;
    public float speedIncrease=0.25f;

    private int playerPoints;
    private int opponentsPoints;

    public Text playerScore;
    public Text opponentsScore;

    private int hitCounter=0;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         Invoke("StartBall",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        rb.velocity = Vector2.ClampMagnitude(rb.velocity,initialSpeed+speedIncrease*hitCounter);
    }

    private void StartBall(){
        rb.velocity = new Vector2(-1,0)*(initialSpeed+speedIncrease*hitCounter);
    }

    private void ResetBall(){
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
        hitCounter=0;
        Invoke("StartBall",2f);
    }

    public void PlayerBounce(Transform myObject){
        hitCounter++;
        Vector2 ballPos = transform.position;
        Vector2 PlayerPos = myObject.position;

        float xDir,yDir;

        if(transform.position.x>0){
            xDir=-1;
        }
        else{
            xDir=1;
        }

        yDir = (ballPos.y-PlayerPos.y)/myObject.GetComponent<Collider2D>().bounds.size.y;

        if(yDir==0){
            yDir=0.25f;
        } 

        rb.velocity = new Vector2(xDir,yDir)*(initialSpeed+(speedIncrease*hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Player"||collision.gameObject.name == "Opponent"){
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(transform.position.x>0){
            playerScore.text = (int.Parse(playerScore.text)+1).ToString();
            Invoke("ResetBall",0.1f);
        }
        else if(transform.position.x<0){
            opponentsScore.text = (int.Parse(opponentsScore.text)+1).ToString();
            Invoke("ResetBall",0.1f);
        }
    }

}
