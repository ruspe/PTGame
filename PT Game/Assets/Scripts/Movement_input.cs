using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_input : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float z = -6.35f;
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        gameObject.transform.position = new Vector3(transform.position.x + (h * speed),
           transform.position.y + (v * speed), -6.35f);
    }
}
