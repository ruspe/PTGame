using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterSeconds : MonoBehaviour
{
    public float secondsToWait = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitThenDestroy());
    }

    IEnumerator waitThenDestroy()
    {
        yield return new WaitForSeconds(secondsToWait);
        Destroy(this.gameObject);
    }
}
