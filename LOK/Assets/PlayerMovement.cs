using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool IsAi;
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
        playerMove=new Vector2(0,Input.GetAxisRaw("Vertical"));
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
        rb.velocity = playerMove*moveSpeed; 
    }
}
