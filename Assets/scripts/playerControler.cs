using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
 
    public float speed;
    public Vector3[] point;
    public int current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = point[current]-transform.position;
        if (direction.magnitude > 0.1f)
        {
            transform.forward = direction.normalized;
            transform.position +=transform.forward * speed *Time.deltaTime;
        }
        else
        {
            current++;
            if(current == 4)
                current = 0;
        }
    }
    
}
