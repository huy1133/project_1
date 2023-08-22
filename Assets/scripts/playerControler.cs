using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControler : MonoBehaviour
{
    enum DriverMode
    {
        Manual,
        Automatic
    }
    
    public float speed;
    public float rotationSpeed;
    public Vector3[] point;
    public int current;
    private DriverMode mode;
    private Rigidbody rb;
    private int damager;
    private float fuel;
    private float capacity;
    private int laps;
    private Vector3 pointstar ;
    public GameObject[] barrier = new GameObject[4];
    public Vector3[] pointBarrier = new Vector3[8];

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "hit")
        {
            damager += 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            laps++;
            resetBarrier();
            resetFuel();
        }
    }
    void resetFuel() 
    {
        fuel = 100;
    }
    void resetBarrier()
    {
        int[] list = new int[4];
        int index = 0;
        while (index < 4)
        {
            bool check = true;
            int temp = Random.Range(0, 8);
            for (int i = 0; i < index; i++)
            {
                if (list[i] == temp)
                {
                    check = false;
                    break;
                }
                list[index] = temp;
            }
            if (check)
            {
                //Debug.Log(temp);
                GameObject barrierTemp = barrier[index];
                barrierTemp.SetActive(true);
                barrierTemp.transform.position = pointBarrier[temp];
                index++;
            }
        }
    }
   
    
    void Start()
    {
        mode = DriverMode.Manual;
        rb = GetComponent<Rigidbody>();
        
        damager = 0;
        pointstar = new Vector3 (71,0,0);
        transform.position = pointstar;
        laps = 0;
        capacity = 100;
        fuel = 100;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (mode == DriverMode.Automatic)
        {
            Vector3 direction = point[current] - transform.position;
            if (direction.magnitude > 0.1f)
            {
                transform.forward = direction.normalized;
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else
            {
                current++;
                if (current == 4)
                    current = 0;
            }
        }else if (mode == DriverMode.Manual)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            Vector3 moveDirection = new Vector3(0f, 0f, verticalInput);
            transform.Translate(moveDirection * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
            rb.AddForce(transform.forward*verticalInput*speed);
            
        }
        if(damager >= 100)
        {
            SceneManager.LoadScene("lesson_6");
            damager = 0;
        }
        checkfuel();
        GameObject gameObject = GameObject.Find("gameManager");
        gameObject.GetComponent<gameManager>().setlaps(laps);
        gameObject.GetComponent<gameManager>().bloodLoss(damager);
        gameObject.GetComponent<gameManager>().fuel(capacity, fuel);

    }
    void checkfuel()
    {
        if (Input.GetAxis("Vertical") != 0) {
            fuel -= 0.1f ;
        }
    }
}
