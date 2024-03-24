using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    private Transform pTransform;
    public TrailRenderer tr;
    public float gravity;
    public float maxSpeed;
    public float aceleration;

    public Vector3 velocity;
    bool ariJump, lJump, rJump;
    
    float slide = 0f;
    float coyoteJ = 0.5f;
    float lCoyoteJ = 0.1f;
    float rCoyoteJ = 0.1f;
    private Gradient red = new Gradient();
    private Gradient white = new Gradient();

    // float time = 0f;

    void Start()
    {
        pTransform = gameObject.GetComponent<Transform>();


        red.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f)},
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f)}
        );

        red.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f)},
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f)}
        );
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            if(coyoteJ > 0) { 
                Debug.Log("Jump");
                jump();
            }  
            else if(ariJump ){
                Debug.Log("airJump");

                ariJump = false;
                jump();
            }else if(lJump && lCoyoteJ > 0){
                Debug.Log("leftWall");
                lJump = false;
                jump();
            }else if(rJump && rCoyoteJ > 0){
                Debug.Log("rightWall");

                rJump = false;
                jump();
            }

        }


        
        else coyoteJ -= Time.deltaTime;
        if(lWallCheck()) {
            rJump = true;
            lCoyoteJ = 0.1f;
        }
        else lCoyoteJ-= Time.deltaTime;
        if(rWallCheck()){
            lJump = true;
            rCoyoteJ = 0.1f;
        }
        if(groundCheck()) {
            ariJump = rJump = lJump = true;
            coyoteJ = 0.1f;
        }
        else rCoyoteJ-= Time.deltaTime;
        ceilingCheck();
        // velocity.x = velocity.x + Input.GetAxis("Horizontal") * (grounded? 10 : 1);
    }   

    void jump(){
        velocity.y = 15;
        slide = 0.2f;
    }
    void FixedUpdate(){
// ---------------- calculate velocity ----------\\\
    // horizontal velocity
        float tragetVelocity = Input.GetAxis("Horizontal") * maxSpeed;
        float velocityChange = Time.fixedDeltaTime *(Math.Abs(velocity.y)< 1? aceleration :aceleration/10 );
        if(Math.Abs(velocity.y) > 1) {
            tr.colorGradient = red;
        }
        if(Math.Abs(tragetVelocity - velocity.x) < velocityChange) velocity.x = tragetVelocity;
        else velocity.x += (((tragetVelocity - velocity.x)<0)? -velocityChange:velocityChange );


    // vertical velocity fall and slide
        if(!groundCheck()){
            if(slide > 0f && velocity.y <=0 && (lWallCheck() || rWallCheck()))  {
                velocity.y-= gravity*Time.fixedDeltaTime/5;
                // slide -= Time.fixedDeltaTime;  
                // Debug.Log(slide);
            }
            else {
                velocity.y -= gravity*Time.fixedDeltaTime;
            }
        }


// ---------------- update position _----------\\\
        pTransform.position = pTransform.position + velocity*Time.deltaTime;
    }


    ///<summary>
    ///removes downward momentum
    ///</summary>
    ///<returns>boolean - touching ground</returns>
    bool groundCheck(){
        float radius =  0.49f;
        float length;
        bool grounded = false;
        RaycastHit2D hit;
        for(float offset = 0.0f; offset <radius/2; offset += 0.01f){
            length = (float)Math.Sqrt(radius*radius - offset * offset);
            hit = Physics2D.Raycast(transform.position + Vector3.right * offset , Vector2.down, length);
            if(hit.collider == null)
                grounded = false;
            else {
                grounded = true;  
                if(velocity.y<0) velocity.y = 0;  
                if(hit.distance < 0.5) pTransform.position += Vector3.up * (length - hit.distance);
                break;

            }

            hit = Physics2D.Raycast(transform.position - Vector3.right * offset , Vector2.down, length);
            if(hit.collider == null)
                grounded = false;
            else {
                grounded = true;  
                if(velocity.y<0) velocity.y = 0;  
                if(hit.distance < 0.5) pTransform.position += Vector3.up * (length - hit.distance);
                break;

            }
        }
         return grounded;
        
    }

    ///<summary>
    ///removes upward momentum 
    ///</summary>
    ///<returns>boolean - touching ceiling</returns>

    bool ceilingCheck(){
        bool ceiling = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.501f);
        if(hit.collider == null)
            ceiling = false;
        else {
            if(velocity.y > 0) velocity.y = 0;   
            ceiling = true;  
            if(hit.distance < 0.5) pTransform.position += Vector3.down * (0.5f - hit.distance);
        }
        return ceiling;
    }

    ///<summary>
    /// prevents form going in wall removes left momentum
    ///</summary>
    ///<returns>boolean - touching left wall</returns>
    bool lWallCheck(){
        //wall
        bool wall = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.501f);
        if(hit.collider == null)
            wall = false;
        else {
            if(velocity.x<0) velocity.x= 0;   
            wall = true;  
            if(hit.distance < 0.5) pTransform.position += Vector3.right * (0.5f - hit.distance);
        }
        return wall;
    }
    ///<summary>
    /// prevents form going in wall removes right momentum
    ///</summary>
    ///<returns>boolean - touching rihgt wall</returns>
    bool rWallCheck(){
        bool wall = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.501f);
        if(hit.collider == null)
            wall = false;
        else {
            if(velocity.x<0) velocity.x= 0;   
            wall = true;  
            if(hit.distance < 0.5) pTransform.position += Vector3.left * (0.5f - hit.distance);
        }
        return wall;
    }
}
