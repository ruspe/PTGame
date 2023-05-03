using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rerouteAnimCall : MonoBehaviour
{
    public shootProjectile parentScript;
    // Start is called before the first frame update
  
    //anim events can only call scripts that are on the same gameobject so this is kind of a workaround
    public void shoot()
    {
        parentScript.shoot();
    }
}
