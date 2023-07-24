using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [HideInInspector] public PlayerInputManager playerInput;
    [HideInInspector] public Worktop workTop;
    public float speed;

    private Rigidbody player_R;
    private Animator ani;
    public bool ischeck = false;//그 도마 같은거 접촉
    public bool isPlate= false;//접시 접촉
    public bool getCook = false;
    public bool ishand = false;//손에 무언가 있는지 확인
    public bool cookend = false;//다지기 끝나고
    public bool isCollision = false;//아무것도 접촉 안 할 때 알 기 위해
    public bool isfall = false;//바닥에 떨어진 재료 하나만 인식

    public GameObject[] hand_Grip = new GameObject[2];
    public GameObject[] hand_Open = new GameObject[2];
    public GameObject[] cookware  = new GameObject[2];

    public GameObject isWorkTop;// workTop 실시간 검출 중
    public GameObject isWorkTop2;//키 입력시 저장할 workTop;

    public LayerMask layerMask;
    
    public GameObject cookWorkTop;//도마
    public GameObject choppingBoar;

    public Queue<GameObject> colqueue;

    private int preChildcount;//자식 객체수 받아옴(손에 무언가를 들면 자식이 추가됨 그 수를 비교해서 손에 무언가 있는지 알 수 있음)
    
    //그릇 관련
   
    private bool hasCollision = false;

    public GameObject plate;

    //행동
    public bool isRun = false;
    public bool isCook = false;

    private static PlayerControll Instance;

    public static PlayerControll instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<PlayerControll>();
            }

            return Instance;
        }
    }
    void Start()
    {
        player_R = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        playerInput = FindObjectOfType<PlayerInputManager>();
        colqueue = new Queue<GameObject>();
        plate = GetComponent<GameObject>();
    }

    void FixedUpdate()
    {
        Run();

        Transform parentTransform = transform;
        int childCount = parentTransform.childCount;

        preChildcount = childCount;

        RaycastHit rayobject;
        if (Physics.Raycast(transform.position, transform.forward, out rayobject, 1f, layerMask))
        {
            isWorkTop = rayobject.transform.GetComponentsInParent<Transform>()[2].gameObject;

            if (isWorkTop != null)
            {
                ani.SetBool("Run", false);
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 1f, Color.black);
    }
  

    private void Run()
    {
        isRun = false;

        if ((playerInput.inputX != 0 || playerInput.inputZ != 0 ))
        {
            isRun = true;
            Vector3 velocity = new Vector3(playerInput.inputX, 0, playerInput.inputZ).normalized;
            transform.position += velocity * speed * Time.deltaTime;
            transform.LookAt(transform.position + velocity);          
        }

        if (preChildcount < 3)
        {
            ishand = false;
            ani.SetBool("DishRun", false);
            ani.SetBool("Run", isRun);
        }
        if (preChildcount >= 3)
        {
            ishand = true;
            ani.SetBool("DishRun", isRun);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WorkTop"))
        {
            isCollision = true;
            Debug.Log("인지중");

        }
        if (other.CompareTag("ChppingBoard") && isCook)//다지기
        {
            cookware[0].SetActive(true);
            ani.SetBool("Cook", true);
        }

        if (other.CompareTag("Plate") && !hasCollision)
        {
            plate = other.gameObject;
            hasCollision = true;
            
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WorkTop"))
        {
            isCollision = true;
            Debug.Log("인지중");
        }

        if (other.CompareTag("ChppingBoard") && isCook)//다지기
        {
            cookware[0].SetActive(true);
            ani.SetBool("Cook", true);
        }
        if (other.CompareTag("ChppingBoard") && !isCook)//다지기 끝
        {
            cookware[0].SetActive(false);
            ani.SetBool("Cook", false);
        }
        if (other.CompareTag("Plate") && !hasCollision)
        {
            if (plate != other.gameObject)
            {
                plate = other.gameObject;
                hasCollision = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WorkTop"))
        {
            isCollision = false;
            Debug.Log("인지 안 함");
        }

        if (other.CompareTag("ChppingBoard") && !isCook)
        {
            ani.SetBool("Cook", false);
            cookware[0].SetActive(false);
        }

        if (other.CompareTag("WorkTop"))//접촉한  workTop
        {
            isWorkTop = null;
            
        }
        if (other.CompareTag("Plate") && hasCollision)
        {
            plate = null;

            // 충돌한 오브젝트에 대한 처리

            hasCollision = false;
        }
    }

}
