using UnityEngine;
using TMPro;

public class movement : MonoBehaviour
{

    public float speed = 2f;
    public float maxSize = 0;
    public float currentSize = 0;
    public float initialSize = 0;

    public Transform wood1, wood2;
    public Transform pointSpwanPos;

    public GameObject woodPartile;
    public GameObject rippleEffect;
    public GameObject pEffect;
    public GameObject points;
    [SerializeField] public Animator charecterPlayerAnime;

    public TextMeshPro Player;
    public TextMeshPro E1;
    public TextMeshPro E2;
    public TextMeshPro E3;


    public string PlayerName;
    public string Enemy1;
    public string Enemy2;
    public string Enemy3;


    private PlayerMovement pM;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        pM = FindObjectOfType<PlayerMovement>();
        currentSize = 0;
        maxSize = 0;
        playerNameTag();
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
    public void setSizeInitial()
    {
        maxSize = initialSize;
        currentSize = initialSize;
    }



    void playerNameTag()
    {
        Player.text = PlayerName.ToString();
        E1.text = Enemy1.ToString();
        E2.text = Enemy2.ToString();
        E3.text = Enemy3.ToString();
    }

/*    public void run()
    {
        pM.anime.SetBool("run", true);
    }
    public void stop()
    {
        pM.anime.SetBool("run", false);
    }*/
}