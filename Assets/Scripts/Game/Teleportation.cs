using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform x1,x2;
    public float distance;
    void Update()
    {
        distance = x2.position.y-x1.position.y;
    }
}
