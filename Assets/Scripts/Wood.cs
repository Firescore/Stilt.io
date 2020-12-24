using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public movement Movement;

    public cameraFollow cameraFollow;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            Movement.maxSize -= 0.05f;
            PlayerMovement.maxSize += PlayerMovement.incrementSize;
            cameraFollow.maxPos -= 1f;
            Destroy(gameObject);
        }
    
}
}
