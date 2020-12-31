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
            pM.maxMod += 0.5f;
            pM.maxSize += pM.incrementSize;
            cF.maxPos -= 0.35f;
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponentInParent<enemyMovementData>().maxM += other.GetComponentInParent<enemyMovementData>().incrementalM;
            other.GetComponentInParent<enemyMovementData>().maxw1w2 -= other.GetComponentInParent<enemyMovementData>().incrementalSpeedw1w2;
            Destroy(gameObject);
        }
    
    }
}
