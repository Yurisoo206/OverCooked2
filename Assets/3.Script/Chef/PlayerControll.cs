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
    public bool getCook = false;
    public bool ishand = false;//손에 무언가 있는지 확인
    public bool cookend = false;//다지기 끝나고

    public GameObject[] hand_Grip = new GameObject[2];
    public GameObject[] hand_Open = new GameObject[2];
    public GameObject[] cookware  = new GameObject[2];

    public GameObject isWorkTop;// workTop 실시간 검출 중
    public GameObject isWorkTop2;//키 입력시 저장할 workTop;

    public LayerMask layerMask;


    
    public GameObject cookWorkTop;
    public GameObject choppingBoar;

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
    }

    void FixedUpdate()
    {
        Run();
        
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
        if (!ishand)
        {
            ani.SetBool("Run", isRun);
        }
        if (ishand)
        {
            ani.SetBool("DishRun", isRun);
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChppingBoard") && isCook)//다지기
        {
            cookware[0].SetActive(true);
            ani.SetBool("Cook", true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
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

        //if (other.CompareTag("WorkTop") && isWorkTop != null)//접촉한  workTop
        //{
        //    preWorkTop = isWorkTop;
        //}

        //if (other.CompareTag("WorkTop") && isWorkTop == null && ischeck)//접촉한  workTop
        //{
        //    preWorkTop_2 = isWorkTop;
        //}
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ChppingBoard") && !isCook)
        {
            ani.SetBool("Cook", false);
            cookware[0].SetActive(false);
        }

        if (other.CompareTag("WorkTop"))//접촉한  workTop
        {
            isWorkTop = null;
            //Debug.Log();
        }
    }

}
