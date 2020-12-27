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
    public cameraFollow cameraScript;
    public Transform charecter;

    private Vector3 currentPos;
    private float incrementalPos;
    public float maxSize=0.42f, currentSize=0, incrementSpeed=0.01f, incrementSize=0.11f, initialSize = 0.42f;
    public float delay;
    float x,y,speedR;
    float m,n;
    private void Start() {
    child = transform.GetChild(0).gameObject;
}
    private void Update()
    {
        currentPos = transform.position;
        incrementalPos = maxSize * 2;
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
        fallDown();
        StartCoroutine(teleportation(delay));
    }
    void value(){
        child.transform.localPosition = new Vector3(child.transform.localPosition.x,currentSize,child.transform.localPosition.z);
    }

    float a, b, c, d, e;
    
    void fallDown(){

        if(Input.GetKey(KeyCode.E)){
            anime.enabled = false;
            speedR = 5;
            x=75;
            if(y <= x){
                y += speedR;
            }

            m = 55;

            if (n >= m)
            {
                n -= speedR;
            }

            e = 0.0000001f;
            a = 0.185f;
            c = 0.34f;

            transform.rotation = Quaternion.Euler(y,transform.eulerAngles.y,transform.eulerAngles.z);

            charecter.rotation = Quaternion.Euler(n, transform.eulerAngles.y, transform.eulerAngles.z);
            charecter.localPosition = new Vector3(0, b, d);

            cameraScript.enabled = false;
        }

        if(Input.GetKeyUp(KeyCode.E)){
            y=0;
            n = 0;
            b = 0;
            d = 0;
            anime.enabled = true;
            transform.rotation = Quaternion.Euler(y,transform.eulerAngles.y,transform.eulerAngles.z);

            charecter.rotation = Quaternion.Euler(n, transform.eulerAngles.y, transform.eulerAngles.z);
            charecter.localPosition = new Vector3(0, b, d);
            cameraScript.enabled = true;
        }
    }

    public void setInSize(){
        maxSize=initialSize;
        currentSize=initialSize;
    }

    IEnumerator teleportation(float t){
        if(Input.GetKeyDown(KeyCode.E)){
            yield return new WaitForSeconds(t);
            transform.position += charecter.forward * incrementalPos;
            mv.setSizeInitial();
            cameraScript.inisalPos();
            setInSize();
        }
    }
}