using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleWeaponManager : MonoBehaviour
{
    public GameObject BigWeapon;
    public GameObject SmallWeapon;
    public bool chosen, big;
    // Start is called before the first frame update
    void Start()
    {
        chosen = false;
        big = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!chosen)
            {
            BigWeapon.SetActive(false);
            SmallWeapon.SetActive(false);
            }
    }
    public void UseBig()
        {
        BigWeapon.SetActive(true);
        chosen = true;
        big = true;
        }
    public void UseSmall()
        {
        SmallWeapon.SetActive(true);
        chosen = true;
        big = false;
        }
}
