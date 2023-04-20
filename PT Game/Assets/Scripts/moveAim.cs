using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAim : MonoBehaviour
{
    [Header("Horizontal")]
    public float horizontalSpeed = 2f; //speed of aim moving on x axis
    public float horizontalRange = 2f; //x axis aim range
    private float minX;
    private float maxX;

    [Header("Vertical")]
    public float verticalSpeed = 4f; //speed of aim moving on y axis
    public float verticalRange = 2f; //y axis aim range
    private float minY;
    private float maxY;






    // Start is called before the first frame update
    void Start()
    {
        minX = transform.position.x - horizontalRange;
        maxX = transform.position.x + horizontalRange;
        minY = transform.position.y - verticalRange;
        maxY = transform.position.y + verticalRange;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, maxX - minX) + minX, Mathf.PingPong(Time.time * verticalSpeed, maxY-minY) + minY, transform.position.z);

    }
}
