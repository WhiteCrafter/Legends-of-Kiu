using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    private Transform pTransform;
    public float gravity;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        pTransform = gameObject.GetComponent<Transform>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            velocity.y = 10;
            Debug.Log("jumped");
        }
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.6f);
        // if(hit.collider == null)
        //     velocity.y -= gravity*Time.fixedDeltaTime;
        // else if(velocity.y<0) velocity.y = 0;    
        velocity.x = Input.GetAxis("Horizontal") * 10;
    }
    void FixedUpdate(){
        pTransform.position = pTransform.position + velocity*Time.deltaTime;
    }

}
