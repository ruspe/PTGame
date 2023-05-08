using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDragonHead : MonoBehaviour
{
    public Transform targetTransform;
    public Transform IKController;

    Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null)
        {
            return;
        }

        else
        {
            IKController.transform.position = Vector3.SmoothDamp(IKController.transform.position, targetTransform.position, ref velocity, 1f);
        }
    }
}
