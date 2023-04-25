using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackingBalls : MonoBehaviour
{

    public TextMeshProUGUI ballsCaughted;
    public int ballsCaught;

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
        if (other.tag == "projectile")
        {
            Debug.Log("Caught");
            ballsCaught += 1;


        }
    }
}
