using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int ballsHitGoal = 1;
    public int ballsHit;
    public GameObject conditionTester;
    public TextMeshProUGUI ballCountText;
    public BallCollisionDetector ballCollisionDetectorL;
    public BallCollisionDetector ballCollisionDetectorR;
   

    private int answer; 


    // Start is called before the first frame update
    void Start()
    {

        conditionTester.SetActive(false);
        
       
    }

    // Update is called once per frame
    void Update()
    {



        //Game Conditions: Timer


        //Game Conditions: Hit Ball Count


        if (ballCollisionDetectorL.ballHit == true)
        {
            ballsHit += 1;
            ballCountText.text = "Balls Hit: " + ballsHit.ToString();
            ballCollisionDetectorL.ballHit = false; 
            
        }

        if (ballCollisionDetectorR.ballHit == true)
        {
            ballsHit += 1;
            ballCountText.text = "Balls Hit: " + ballsHit.ToString();
            ballCollisionDetectorR.ballHit = false;

        }

        if (ballsHit >= ballsHitGoal)
        {
            conditionTester.SetActive(true); 
        }


    }
}
