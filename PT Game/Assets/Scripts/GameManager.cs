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

    //Timer Variables
    public float timeLeft;
    public bool timerON;

    public TextMeshProUGUI timerText; 
   

    private int answer; 


    // Start is called before the first frame update
    void Start()
    {

        conditionTester.SetActive(false);
        timerON = true;
       
    }

    // Update is called once per frame
    void Update()
    {



        //Game Conditions: Timer
        if (timerON == true)
        {
            if(timeLeft >= 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft); 
            }
            else
            {
                Debug.Log("Time is up!");
                timeLeft = 0;
                timerON = false; 
                conditionTester.SetActive(true); 
            }
        }

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

    void UpdateTimer (float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds); 
    }
}
