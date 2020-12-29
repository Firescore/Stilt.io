using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSystem : MonoBehaviour
{
    public Transform inistialPosition;
    public Vector3 nextPosition;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            distance = Vector3.Distance(inistialPosition.position, hit.point);
            if (Input.GetKeyDown(KeyCode.E))
            {
                nextPosition = hit.point;
            }
        }
       
            
    }
}
