using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BallHitMarker : MonoBehaviour
{
    //public float speed = 5f;
    public GameObject decalPrefab;
    public LayerMask layerMask;
    
    
    private Transform plane; 

    private Rigidbody rb;
    private GameObject decalInstance; 

    RaycastHit hit; 
    
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.velocity = (transform.forward * speed) * 1f; 
        plane = GameObject.Find("HitPlan").transform; // WHY ISNT THIS WORKING? I NEED TO FIND THE PLANE
        
    }

    private void Update()
    {
        UnityEngine.Vector3 impactPoint = CalculateImpactPoint();
        RaycastHit hit; 

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            if (decalInstance == null)
            {
                decalInstance = SpawnDecal(hit.point, hit.normal); 
            }  
            else
            {
                decalInstance.transform.position = impactPoint;
                decalInstance.transform.rotation = UnityEngine.Quaternion.FromToRotation(UnityEngine.Vector3.forward, hit.normal);
            }
        }
        Debug.DrawLine(transform.position, impactPoint, Color.red); 
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        Vector3 forwardDirection = this.transform.TransformDirection(Vector3.forward); 
        if (Physics.Raycast(origin.transform.position, forwardDirection, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            SpawnDecal(hit.point, hit.normal);
            decalSpawned = true; 
        }
    }*/

    GameObject SpawnDecal(UnityEngine.Vector3 hitPoint, UnityEngine.Vector3 hitNormal)
    {
        GameObject decal = Instantiate(decalPrefab, hitPoint, UnityEngine.Quaternion.FromToRotation(UnityEngine.Vector3.forward, hitNormal));
        decal.transform.SetParent(plane);
        return decal; 
    }

    UnityEngine.Vector3 CalculateImpactPoint()
    {
        UnityEngine.Plane plane = new UnityEngine.Plane(this.plane.up, this.plane.position);
        float enter; 
        Ray ray = new Ray(transform.position, transform.forward);

        if (plane.Raycast(ray, out enter))
        {
            return ray.GetPoint(enter); 
        }

        return UnityEngine.Vector3.zero; 
    }

    /*void SpawnDecal(Vector3 hitPoint, Vector3 hitNormal)
    {
        GameObject decal = Instantiate(decalPrefab, hitPoint, Quaternion.FromToRotation(Vector3.forward, hitNormal));
        decal.transform.SetParent(hit.transform); 
    }*/
}
