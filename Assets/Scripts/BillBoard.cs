using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    Transform Camera;
    // Start is called before the first frame update
    void Awake()
    {
        Camera = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + Camera.forward);

    }
}
