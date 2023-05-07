using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enableGame;
using Unity.VisualScripting;

public class shootProjectile : MonoBehaviour
{
    public Animator anims;
    //vars
    [Header("Shoot Settings")]
    public GameObject projectile; //prefab, object that is going to be shot. should have a rigidbody
    public Transform shootPoint; // point to shoot from
    public egFloat shootForce = 750; // force applied to projectile. affects speed 
    public egFloat timeBetweenShots = 5f;
    public egFloat chargeSpeed = .5f;

    [Header("Aim Settings")]
    public Transform aimLeft;
    public Transform aimRight;


    // Awake() is called when the script instance is being loaded.
    void Awake()
    {
        VariableHandler.Instance.Register(ParameterStrings.SHOOTFORCE, shootForce);

        VariableHandler.Instance.Register(ParameterStrings.TIMEBETWEENSHOTS, timeBetweenShots);

        VariableHandler.Instance.Register(ParameterStrings.CHARGESPEED, chargeSpeed);
    }


    // Start is called before the first frame update
    void Start()
    {
       
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
