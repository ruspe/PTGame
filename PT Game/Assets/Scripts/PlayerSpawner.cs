using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    public Transform playerSpawn; 
    
    // Start is called before the first frame update
   
    void Start()
    {
        player.transform.position = playerSpawn.position;  
        player.transform.position = Vector3()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
