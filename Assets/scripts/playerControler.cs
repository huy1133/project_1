using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        mode = DriverMode.Manual;
        
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
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            Vector3 moveDirection = new Vector3(0f, 0f, verticalInput);
            transform.Translate(moveDirection * speed * Time.deltaTime);

            
            transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        }
    }
    
}
