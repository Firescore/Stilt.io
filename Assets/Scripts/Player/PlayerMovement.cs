using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 0.01f, turnInput, turnStrength = 90f, moveInput, timer;
    public float speed = 1;
    public Animator anime, anime1;
    public GameObject child;
    public movement mv;
    public cameraFollow cameraScript;

    private Vector3 currentPos;
    private float incrementalPos;
    public float maxSize=0.42f, currentSize=0, incrementSpeed=0.01f, incrementSize=0.11f, initialSize = 0.42f;
    public float delay;
    float x,y,speedR;
    private void Start() {
    child = transform.GetChild(0).gameObject;
}
    private void Update()
    {
        currentPos = transform.position;
        incrementalPos = maxSize;
        turnInput = Input.GetAxis("Horizontal");
        moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*moveInput*speed*Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0));
        if(moveInput >0){
            anime.SetBool("run",true);
        }else{
            anime.SetBool("run",false);
        }
        if(currentSize<=maxSize){
            currentSize += incrementSpeed;
        }
        value();
        //Animation();
        //fallDown();
        StartCoroutine(teleportation(delay));
    }
    void value(){
        child.transform.localPosition = new Vector3(child.transform.localPosition.x,currentSize,child.transform.localPosition.z);
    }

    // void Animation(){
    //     if(Input.GetKeyDown(KeyCode.F)){
    //         anime1.enabled = true;
    //         cameraScript.enabled = false;
    //     }else{
    //         anime1.enabled = false;
    //         cameraScript.enabled = true;
    //     }
    // }


    // void fallDown(){

    //     if(Input.GetKey(KeyCode.T)){
    //         speedR = 2;
    //         x=75;
    //         if(y <= x){
    //             y += speedR;
    //         }
    //         transform.rotation = Quaternion.Euler(y,transform.eulerAngles.y,transform.eulerAngles.z);
    //         cameraScript.enabled = false;
    //     }

    //     if(Input.GetKeyUp(KeyCode.T)){
    //         y=0;
    //         transform.rotation = Quaternion.Euler(y,transform.eulerAngles.y,transform.eulerAngles.z);
    //         cameraScript.enabled = true;
    //     }
    // }

    public void setInSize(){
        maxSize=initialSize;
        currentSize=initialSize;
    }

    IEnumerator teleportation(float t){
        if(Input.GetKeyDown(KeyCode.T)){
            yield return new WaitForSeconds(t);
            // transform.position = currentPos + new Vector3(incrementalPos,0,incrementalPos);
            mv.setSizeInitial();
            setInSize();
        }
    }
}