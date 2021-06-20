using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnter : MonoBehaviour
{
    public List<GameObject> inCircle;
    public GameObject NearestOne;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (inCircle.Count > 0 && inCircle[0] == null)
            inCircle.RemoveAt(0);
        if (inCircle.Count > 0)
            {
            NearestOne = inCircle[0];
            foreach (GameObject exp in inCircle)
                {
                if (exp != null)
                    if (Vector3.Distance(exp.transform.position, transform.position) < Vector3.Distance(NearestOne.transform.position, transform.position)) NearestOne = exp;
                }
            }
        else NearestOne = null;

    }
    private void OnTriggerExit(Collider other)
        {
        inCircle.Remove(other.gameObject);
        }
    }
