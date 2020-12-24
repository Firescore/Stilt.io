using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 0.01f, turnInput, turnStrength = 90f, moveInput, timer;
    public float speed = 1;
    public Animator anime;
    public GameObject child;
    public movement mv;

    public float maxSize=0.42f, currentSize=0, incrementSpeed=0.01f, incrementSize=0.11f;

private void Start() {
    child = transform.GetChild(0).gameObject;
}
    private void Update()
    {
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
    }
    void value(){
        child.transform.localPosition = new Vector3(child.transform.localPosition.x,currentSize,child.transform.localPosition.z);
    }
}