using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iaSpawn : MonoBehaviour
{
    public GameObject ia;
    public float spwanrate=2;
    private float timer = 0;
    public float heightset=10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnIa();
    }

    // Update is called once per frame
    void Update() {
        if(timer<spwanrate){
        timer+=Time.deltaTime;
    }
    else{
       SpawnIa();
        timer=0;
    }
    }

    void SpawnIa(){
        float highestpoint=transform.position.y+heightset;
        float lowestpoint=transform.position.y-heightset;

         Instantiate(ia,new Vector3(transform.position.x,Random.Range(lowestpoint,highestpoint),0),transform.rotation);
    }



}
