using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed = 2f;
    public float maxSize = 0;
    public float currentSize = 0;
    public float initialSize = 0;

    public Transform wood1, wood2;

    [SerializeField] public Animator charecterPlayerAnime;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        currentSize = 0;
        maxSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        increseSize();
    }
    public void increseSize()
    {
        if(currentSize >= maxSize)
        {
            currentSize -= speed;
        }
        
        wood1.localScale = new Vector3(wood1.localScale.x,currentSize,wood1.localScale.z);
        wood2.localScale = new Vector3(wood2.localScale.x,currentSize,wood2.localScale.z);
        
    }
    public void setSizeInitial(){
        maxSize=initialSize;
        currentSize=initialSize;
    }
}