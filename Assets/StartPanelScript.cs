using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }
    public void GameStart()
        {
        Time.timeScale = 1;
        Destroy(gameObject);
        }
}
