using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTest : MonoBehaviour
{

    public ATest testScript;
    public int numberAdding = 5; 
    
    public int answer; 
    
    // Start is called before the first frame update
    void Start()
    {
        answer = testScript.test + numberAdding; 
        
        Debug.Log(answer);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
