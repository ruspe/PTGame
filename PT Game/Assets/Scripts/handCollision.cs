using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class handCollision : MonoBehaviour
{
    public int ballsCaught;
    public TextMeshProUGUI ballsCaughted; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ballsCaughted.text = ("Balls Caught: " + ballsCaught.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HandCollider")
        {
            Debug.Log("Caught");
            ballsCaught += 1; 
            

        }
    }
}
