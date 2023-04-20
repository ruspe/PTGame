using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnProjectile : MonoBehaviour
{
    //despawns things tagged projectile


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "projectile");
        Destroy(other.gameObject);
        Debug.Log("Miss!");
    }
}
