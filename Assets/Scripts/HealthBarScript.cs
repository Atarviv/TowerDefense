using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public GameObject parentTank;
    float health,lasthealth,firstlocalscale;

    // Start is called before the first frame update
    void Awake()
    {
        health = parentTank.GetComponent<TankMovement>().health;
        lasthealth = health;
        firstlocalscale = transform.localScale.x; 
        }

    // Update is called once per frame
    void Update()
    {
        health = parentTank.GetComponent<TankMovement>().health;
        if (health < lasthealth)
            {
            lasthealth -= Time.deltaTime*100;
            }
        transform.localScale = new Vector3(lasthealth / 100 * firstlocalscale, transform.localScale.y, transform.localScale.z);
        }
    
}
