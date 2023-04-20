using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchProjectile : MonoBehaviour
{

    //catches projectiles that collide with colliders that have this script


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "projectile")
        {
            Destroy(collision.gameObject);
            Debug.Log("Catch!");
        }
    }
}
