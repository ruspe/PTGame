using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootProjectile : MonoBehaviour
{

    //vars
    public GameObject projectile; //prefab, object that is going to be shot. should have a rigidbody
    public Transform shootPoint; // point to shoot from
    public float shootForce = 50; // force applied to projectile
    public float timeBetweenShots = 5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timedShoot());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   //shoots projectile from shootpoint to a transform in the scene 
    public void shoot()
    {
        GameObject newProjectile = Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation); //creates
        newProjectile.GetComponent<Rigidbody>().AddForce(shootPoint.transform.forward * shootForce);

    }

    //shoots, waits for seconds, and then shoots again. infinite loop right now but should have a way to break later on
    IEnumerator timedShoot()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        shoot();
        StartCoroutine(timedShoot());
    }
}
