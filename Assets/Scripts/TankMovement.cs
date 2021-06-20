using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMovement : MonoBehaviour
{
    public ParticleSystem explosion;
    GameObject trig;
    public float health;
    public Transform EndPosition;
    TankRespawn respawn;
    // Start is called before the first frame update
    void Awake()
    {
        trig = null;
        health = 100;
        EndPosition = GameObject.Find("DestinationLocation").transform;
        GetComponent<NavMeshAgent>().SetDestination(EndPosition.position);
        respawn = GameObject.Find("TankRespawnManager").GetComponent<TankRespawn>();
        }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<20||health<=0)
            {
            if (health <= 0) Instantiate(explosion, transform.position, transform.rotation);
            else respawn.gameObject.GetComponent<LivesHandler>().decreaseLives();
            respawn.RespawnTime -= 0.25f;
            if (trig != null) trig.GetComponent<CircleEnter>().inCircle.Remove(gameObject);
            Destroy(gameObject);
            }

        }

    private void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "Circle")
            {
            trig = other.gameObject;
            other.GetComponent<CircleEnter>().inCircle.Add(gameObject);
            }
        }
    public void ChangeHealth(int substract) {
        health -= substract; 
        }
    }
