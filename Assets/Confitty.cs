using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confitty : MonoBehaviour
{
    public GameObject confetti, confetti1;

    private void Start()
    {
        confetti.SetActive(false);
        confetti1.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confetti.SetActive(true);
            confetti1.SetActive(true);
        }
    }
}
