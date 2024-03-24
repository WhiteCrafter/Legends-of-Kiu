using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iaMoving : MonoBehaviour
{
    public float iamovespeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=(Vector3.left)*iamovespeed*Time.deltaTime;
        if(transform.position.x<-42){
            Destroy(gameObject);
        }
    }
}
