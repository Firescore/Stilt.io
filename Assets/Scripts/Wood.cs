using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public PlayerMovement pM;
    public movement move;
    public cameraFollow cF;

private void Start() {
    pM = FindObjectOfType<PlayerMovement>();
    move = FindObjectOfType<movement>();
    cF = FindObjectOfType<cameraFollow>();
}
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            move.maxSize -= 0.00064f;
            pM.maxSize += pM.incrementSize;
            cF.maxPos -= 0.35f;
            Destroy(gameObject);
        }
    
    }
}
