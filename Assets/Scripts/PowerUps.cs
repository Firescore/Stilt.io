using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();
    public GameObject WoodBundle;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            Points.Add(child.transform);
        }
        for(int i=0;i<Points.Count;i++){
           GameObject a = Instantiate(WoodBundle,Points[i].transform.position,Quaternion.Euler(0,9,0));
           a.transform.parent = transform;
        }
    }
}
