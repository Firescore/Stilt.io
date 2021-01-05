using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 0.01f, turnInput, turnStrength = 100f, moveInput, timer;
    public float speed = 1;
    public Animator anime;
    public Animator fallAnime;
    public GameObject child;
    public GameObject Ripple;
    public movement mv;
    public cameraFollow cameraScript;
    public RaycastSystem rS;
    public Transform charecter;
    public GameObject particle1, particle2, c1, c2;


    private Vector3 currentPos;
    private float incrementalPos;
    public float maxSize=0f, currentSize=0, incrementSpeed=0.01f, incrementSize=0.11f, initialSize = 0f;
    public float delay, rippleDelay;
    float x,y,speedR;
    float m,n;
    float currentPosOfMod, modSpeed;
    public float maxMod, initMod = 6;
    

    public bool ab,a;

    private void Start() {
        //child = transform.GetChild(0).gameObject;
        Ripple.SetActive(false);
        a = false;
    }

    public float s = 0;
    private void Update()
    {
        incrementalPos = maxSize * 2;
        if (s >= 0)
        {
            s -= 0.1f;
        }
        if (s <= 0)
        {
            particle1.SetActive(false);
            particle2.SetActive(false);
            c1.GetComponent<Renderer>().material = mat2;
            c2.GetComponent<Renderer>().material = mat2;
        }

        turnInput = Input.GetAxis("Horizontal");
        moveInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward*moveInput*speed*Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0));

        if(moveInput >0){
            anime.SetBool("run",true);
        }else{
            anime.SetBool("run",false);
        }

        if (currentSize <= maxSize)
        {
            currentSize += incrementSpeed;
        }
        if (currentSize >= maxSize && ab)
        {
            currentSize -= incrementSpeed * currentPosOfMod;
        }
        if(currentPosOfMod <= maxMod)
        {
            currentPosOfMod += modSpeed;
        }


        


        if (transform.position == rS.nextPosition )
        {
            ab = false;
            StartCoroutine(ripple(rippleDelay));
            
        }
        value();
        test();
        fallDown();
        StartCoroutine(teleportation(delay));
        animationT();
    }
    void animationT()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            fallAnime.SetTrigger("ff");
            anime.SetTrigger("down");
            Ripple.SetActive(true);
        }
    }
    void value(){
        child.transform.localPosition = new Vector3(child.transform.localPosition.x,currentSize,child.transform.localPosition.z);
    }

    float b, d;
    
    void fallDown(){

        if(Input.GetKeyDown(KeyCode.E)){

            
            /*anime.enabled = false;
            speedR = 5;
            x=50;
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
            charecter.localPosition = new Vector3(0, b, d);*/
            /*cameraScript.enabled = false;*/
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
            /*cameraScript.enabled = true;*/
        }
    }

    public void setInSize(){
        maxSize=initialSize;
        maxMod = initMod;
        currentPosOfMod = maxMod;
    }

    IEnumerator teleportation(float t){
        if(Input.GetKeyDown(KeyCode.E)){
            fallAnime.SetTrigger("fall");
            anime.SetTrigger("fall");
            a = false;
            yield return new WaitForSeconds(t);
            Destroy(Instantiate(mv.woodPartile, mv.wood1.position, Quaternion.Euler(10,5,10)), 1);
            Destroy(Instantiate(mv.woodPartile, mv.wood2.position, Quaternion.Euler(10, 5, 10)), 1);
            mv.setSizeInitial();
            cameraScript.inisalPos();
            setInSize();
            ab = true;
/*            yield return new WaitForSeconds(0.35f);
            */
        }
    }

    public Transform tar, tar1;
    IEnumerator ripple(float t)
    {
        yield return new WaitForSeconds(t);
        if (!a)
        {
            GameObject m = Instantiate(mv.rippleEffect, tar.position, Quaternion.Euler(90, 0, 0));
            m.transform.parent = mv.wood1;
            Destroy(m, 1);
            GameObject l = Instantiate(mv.pEffect, tar.position, Quaternion.identity);
            l.transform.parent = mv.wood1;
            Destroy(l, 1);
            GameObject n = Instantiate(mv.rippleEffect, tar1.position, Quaternion.Euler(90, 0, 0));
            n.transform.parent = mv.wood2;
            Destroy(n, 1);
            GameObject u = Instantiate(mv.pEffect, tar1.position, Quaternion.identity);
            u.transform.parent = mv.wood1;
            Destroy(u, 1);
            a = true;
        }
    }
    void test()
    {
        if (ab)
        {
            transform.position = Vector3.MoveTowards(transform.position, rS.nextPosition, 4f * Time.deltaTime);
        }
        
    }
    public Material mat1, mat2;

    public void glt()
    {
        s = 2;
        if (s >= 0)
        {
            particle1.SetActive(true);
            particle2.SetActive(true);
            c1.GetComponent<Renderer>().material = mat1;
            c2.GetComponent<Renderer>().material = mat1;
        }
        
    }
   
}