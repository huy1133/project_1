using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFolow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwad = target.transform.forward;
        if (forwad.x != 0||forwad.z!=0)
        {
            offset = new Vector3(-6 * forwad.x, 3.5f, -6 * forwad.z);
        }
        transform.position = target.transform.position + offset;
       
        transform.LookAt(target.transform.position+ new Vector3 (0,2,0));
        

    }
}
