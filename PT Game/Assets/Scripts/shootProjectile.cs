using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootProjectile : MonoBehaviour
{

    //vars
    [Header("Shoot Settings")]
    public GameObject projectile; //prefab, object that is going to be shot. should have a rigidbody
    public Transform shootPoint; // point to shoot from
    public float shootForce = 50; // force applied to projectile. affects speed 
    public float timeBetweenShots = 5f;
    public float chargeSpeed = .5f;

    [Header("Aim Settings")]
    public Transform aimLeft;
    public Transform aimRight;

    private Animator anims;


    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponent<Animator>();
        anims.SetFloat("chargeSpeed", chargeSpeed);

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

    void decideAim() //chooses which hand to shoot at randomly
    {
        int choiceint = Random.Range(0, 2); //generates a 0 or 1, 0 is left 1 is right
        if (choiceint == 0)
        {
            shootPoint.LookAt(aimLeft.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0));
        }

        else
        {
            shootPoint.LookAt(aimRight.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0));
        }
    }

    public void chargeShot()
    {
        //triggers charge shot animation
        anims.SetTrigger("chargeShot");
    }

    //shoots, waits for seconds, and then shoots again. infinite loop right now but should have a way to break later on
    IEnumerator timedShoot()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        decideAim();
        chargeShot();
        StartCoroutine(timedShoot());
    }
}
