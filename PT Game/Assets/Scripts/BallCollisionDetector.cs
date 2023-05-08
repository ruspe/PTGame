using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDetector : MonoBehaviour
{

    public bool ballHit;
    public int testNumber = 5; 
    
    // Start is called before the first frame update
    void Start()
    {
        ballHit = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "projectile")
        {
            ballHit = true;
            Destroy(other.gameObject);
            //ballHit = false; 
            //StartCoroutine(ResetBoolTime());

        }
    }

    IEnumerator ResetBoolTime()
    {
        yield return new WaitForSeconds(2f);
        ballHit = false; 
    }
}
