using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public ParticleSystem explosion;
    int kill;
    Vector3 dir,startLocation;
    bool gameRunning;
    public bool smallGun;
    RaycastHit hit;
    float sinceFired, requireWait;
    // Start is called before the first frame update
    void Start()
        {
        if (smallGun)
            {
            kill = 25;
            requireWait = 1;
            }
        else
            {
            kill = 17;
            requireWait = 0.5f;
            }
        startLocation = transform.position;
        sinceFired = requireWait;
        }

    // Update is called once per frame
    void Update()
    {
        transform.position = startLocation;
        gameRunning = GameObject.Find("TankRespawnManager").GetComponent<TankRespawn>().GameRunning;
        if (GetComponentInParent<CircleEnter>().NearestOne != null)
            {

            transform.LookAt(new Vector3(GetComponentInParent<CircleEnter>().NearestOne.transform.position.x,0, GetComponentInParent<CircleEnter>().NearestOne.transform.position.z));
            if (smallGun)
                {
                dir = transform.forward;
                transform.Rotate(-90, 0, 0);
                }
            else
                {
                dir = transform.forward;
                transform.Rotate(-transform.localRotation.x, 0, 0);
                }
            sinceFired += Time.deltaTime;
            if (sinceFired >= requireWait)
                {
                if (Physics.Raycast(transform.position,dir, out hit, 2000))
                    {
                    if (hit.transform.tag == "Tank")
                        {
                    sinceFired = 0;
                    explosion.Play();
                    hit.transform.GetComponent<TankMovement>().ChangeHealth(kill);
                        }
                    }
                }
            }
    }


}