using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool IsAi;

    public bool p2;

    public GameObject player;

    
    public GameObject ball;

    public float ballRange;
    private Rigidbody2D rb;
    private Vector2 playerMove;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAi){
            AiControl();  
        }
        else{
            PlayerControl();
        }
        
    }

    private void PlayerControl(){
        if(!p2){
            if(Input.GetKeyDown(KeyCode.W)){
                playerMove= new Vector2(0,1);
            }
            if(Input.GetKeyDown(KeyCode.S)){
                playerMove= new Vector2(0,-1);
            }
        }else{
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                playerMove= new Vector2(0,1);
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                playerMove= new Vector2(0,-1);
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }

    private void AiControl(){
        if(ball.transform.position.y > transform.position.y+ballRange){
            playerMove= new Vector2(0,1);
        }
        else if(ball.transform.position.y < transform.position.y-ballRange){
            playerMove= new Vector2(0,-1);
        }
        else{
            playerMove=new Vector2(0,0);
        }
    }

    private void FixedUpdate(){
        float distanceUp = player.transform.position.y+1;
        float distanceDown = player.transform.position.y-1;
        while(player.transform.position.y!=distanceUp||player.transform.position.y!=distanceDown){
            rb.velocity = playerMove*moveSpeed; 
        }
        
    }
}
