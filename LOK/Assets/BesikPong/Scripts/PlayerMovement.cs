using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool IsAi;

    public bool p2;

   
    
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

        float pl1 = Input.GetAxisRaw("Vertical");

        float pl2 = Input.GetAxisRaw("Vertical2");




        if(!p2){
        
         playerMove = new Vector2(0,pl1);
        
        }else{
           
         playerMove = new Vector2(0,pl2);
           
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
         if(SceneManager.GetActiveScene().buildIndex==7||SceneManager.GetActiveScene().buildIndex==1){
            SceneManager.LoadScene(0);
          }
         else{
            SceneManager.LoadScene(1);
            }
            
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
        
         rb.velocity = playerMove*moveSpeed;
    
    
    }
}
