using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManagerScript : MonoBehaviour
{
    GameObject Hover;
    public Sprite Hbig, Hsmall;
    public Button ButtonBig, ButtonSmall;
    Ray ray;
    RaycastHit hit;
    int BigInUse, SmallInUse;
    public Text BigInUseText, SmallInUseText;
    public Camera Camera;
    public bool add, big;    
    // Start is called before the first frame update
    void Start()
    {
        BigInUse = 0;
        SmallInUse = 0;
        Hover = GameObject.Find("HoverImage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            {
            ray = Camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
                {
                if (add&&hit.transform.tag=="Circle"&&!hit.transform.GetComponent<CircleWeaponManager>().chosen)
                    {
                    if (big)
                        hit.transform.GetComponent<CircleWeaponManager>().UseBig();
                    else
                        hit.transform.GetComponent<CircleWeaponManager>().UseSmall();
                    ButtonBig.GetComponent<Image>().color = Color.white;
                    ButtonSmall.GetComponent<Image>().color = Color.white;
                    BigInUseText.text = "In Use: " + BigInUse;
                    SmallInUseText.text = "In Use: " + SmallInUse;
                    add = false;
                    Hover.GetComponent<Image>().enabled = false;
                    }
                else
                    {
                    if(hit.transform.tag == "Circle" && hit.transform.GetComponent<CircleWeaponManager>().chosen&&!add)
                        {
                        if (hit.transform.GetComponent<CircleWeaponManager>().big)
                            {
                            BigInUse--;
                            ChooseBig();
                            }
                        else
                            {
                            SmallInUse--;
                            ChooseSmall();
                            }
                        hit.transform.GetComponent<CircleWeaponManager>().chosen = false;
                        }
                    }
                    
                }
            }
    }
    public void ChooseBig()
        {
        ButtonBig.GetComponent<Image>().color = Color.yellow;
        ButtonSmall.GetComponent<Image>().color = Color.white;
        add = true;
        big = true;
        BigInUse++;
        Hover.GetComponent<Image>().enabled = true;
        Hover.GetComponent<Image>().sprite = Hbig;
        }
    public void ChooseSmall()
        {
        ButtonSmall.GetComponent<Image>().color = Color.yellow;
        ButtonBig.GetComponent<Image>().color = Color.white;
        add = true;
        big = false;
        SmallInUse++;
        Hover.GetComponent<Image>().enabled = true;
        Hover.GetComponent<Image>().sprite = Hsmall;
        }
    }

