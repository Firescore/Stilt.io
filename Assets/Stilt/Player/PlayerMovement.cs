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
    public GameObject particle1, particle2, c1, c2, camera;
    public GameObject en1, en2;

    private Vector3 currentPos;
    private float incrementalPos;
    public float maxSize=0f, currentSize=0, incrementSpeed=0.01f, incrementSize=0.11f, initialSize = 0f;
    public float delay, rippleDelay, waterFallDelay;
    float x, y;
    public float JumpSpeed = 4f;
    float m,n;
    public float currentPosOfMod, modSpeed = 0.5f;
    public float maxMod, initMod = 6;
    

    public bool ab,a, iniPosOfPlayer = false;



    private void Start() {
        //child = transform.GetChild(0).gameObject;
        Ripple.SetActive(false);
        a = false;

        en1.GetComponent<enemyMovementData>().walk();
        en2.GetComponent<enemyMovementData>().walk();
        en1.GetComponent<Animator>().enabled = false;
        en2.GetComponent<Animator>().enabled = false;
        //en1.SetActive(false);
        //en2.SetActive(false);
    }

    public float s = 0;
    private void Update()
    {
        if(Ripple != null)
        {
            Ripple.transform.position = new Vector3(transform.position.x, Ripple.transform.position.y, transform.position.z);
        }
        
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
        if (currentSize >= maxSize && iniPosOfPlayer)
        {
            currentSize -= incrementSpeed * currentPosOfMod;
        }
        if(currentPosOfMod <= maxMod)
        {
            currentPosOfMod += modSpeed;
        }
        if(currentSize <= (initialSize-0.01f))
        {
            iniPosOfPlayer = false;
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

        if (transform.position == new Vector3(rS.nextPosition.x,0.401f, rS.nextPosition.z))
        {
            ab = false;
            //StartCoroutine(ripple(rippleDelay));

            

        }

        
        value();
        test();
        fallDown();
        StartCoroutine(teleportation(delay));
        StartCoroutine(fallIntoWater(waterFallDelay));
        StartCoroutine(finsihJump());
        //animationT();
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
        if (Input.GetKeyUp(KeyCode.R))
        {
            y = 0;
            n = 0;
            b = 0;
            d = 0;

            transform.rotation = Quaternion.Euler(y, transform.eulerAngles.y, transform.eulerAngles.z);
            charecter.rotation = Quaternion.Euler(n, transform.eulerAngles.y, transform.eulerAngles.z);
            charecter.localPosition = new Vector3(0, b, d);
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
            iniPosOfPlayer = true;
            Destroy(Instantiate(mv.woodPartile, mv.wood1.position, Quaternion.Euler(10,5,10)), 1);
            Destroy(Instantiate(mv.woodPartile, mv.wood2.position, Quaternion.Euler(10, 5, 10)), 1);
            mv.setSizeInitial();
            cameraScript.inisalPos();
            setInSize();
            ab = true;
        }
    }



    IEnumerator fallIntoWater(float t)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            fallAnime.SetTrigger("ff");
            anime.SetTrigger("down");
            yield return new WaitForSeconds(t);
            mv.setSizeInitial();
            setInSize();
            ab = true;
            yield return new WaitForSeconds(0.47f);
            camera.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
            Ripple.SetActive(true);
        }
    }

    public Transform tar, tar1;
    IEnumerator ripple(float t)
    {
        
        if (!a)
        {
            yield return new WaitForSeconds(t);
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
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(rS.nextPosition.x,0.401f, rS.nextPosition.z), JumpSpeed * Time.deltaTime);
        }
        
    }
    public Material mat1, mat2;

    public void glt()
    {
        s = 1.5f;
        if (s >= 0)
        {
            particle1.SetActive(true);
            particle2.SetActive(true);
            c1.GetComponent<Renderer>().material = mat1;
            c2.GetComponent<Renderer>().material = mat1;
        }
        
    }
   

    public IEnumerator finsihJump()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            anime.SetTrigger("FALLDOWN");
            fallAnime.SetTrigger("FALLDOWN");
            yield return new WaitForSeconds(1.5f);
            mv.setSizeInitial();
            cameraScript.inisalPos();
            setInSize();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "1":
                //en1.SetActive(true);
                en1.GetComponent<Animator>().enabled = true;                
                break;

            case "2":
                //en2.SetActive(true);
                en2.GetComponent<Animator>().enabled = true;
                break;
        }
    }
}