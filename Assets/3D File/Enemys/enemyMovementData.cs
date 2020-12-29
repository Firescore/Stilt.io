using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementData : MonoBehaviour
{
    public Animator anime;
    public Transform wood1, wood2;
    public Transform modal;

    [Header("Wood")]
    public float curw1w2;
    public float speedw1w2;
    public float maxw1w2;
    public float incrementalSpeedw1w2;

    [Header("Modal")]
    public float curM;
    public float spM;
    public float maxM;
    public float incrementalM;
    public void walk()
    {
        anime.SetBool("run", true);
    }
    public void walkStop()
    {
        anime.SetBool("run", false);
    }

    public void fall()
    {
        anime.SetTrigger("fall");
    }

    public void reset()
    {
        maxM = 0.112f;
        maxw1w2 = 0;
        curw1w2 =maxw1w2;
    }


    private void Update()
    {
        if (curw1w2 >= maxw1w2)
        {
            curw1w2 -= speedw1w2;
        }
        wood1.localScale = new Vector3(wood1.localScale.x, curw1w2, wood1.localScale.z);
        wood2.localScale = new Vector3(wood2.localScale.x, curw1w2, wood2.localScale.z);

        if(curM <= maxM)
        {
            curM += spM;
        }
        if(curM >= maxM)
        {
            curM -= spM;
        }
        modal.localPosition = new Vector3(modal.localPosition.x, curM, modal.localPosition.z);
    }
}
