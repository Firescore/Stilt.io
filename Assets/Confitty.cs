using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confitty : MonoBehaviour
{
    public GameObject confetti, confetti1;
    public movement mv;
    private void Start()
    {
        confetti.SetActive(false);
        confetti1.SetActive(false);
        mv = FindObjectOfType<movement>();
        mv.cam.SetActive(true);
        mv.cam2.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(activate(0.5f));
        }
    }

    IEnumerator activate(float t)
    {
        yield return new WaitForSeconds(t);
        confetti.SetActive(true);
        confetti1.SetActive(true);
        mv.cam.SetActive(false);
        mv.cam2.SetActive(true);
    }
}
