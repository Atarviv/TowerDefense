using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesHandler : MonoBehaviour
{
    public GameObject youlosePanel,youwinPanel;
    public Text LivesText;
    int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0) 
            {
            Time.timeScale = 0;
        youlosePanel.SetActive(true);
            }
        else if (lives > 0 && GetComponent<TankRespawn>().RespawnTime <= 2 && GameObject.FindGameObjectsWithTag("Tank").Length == 0) youwinPanel.SetActive(true);
        LivesText.text = "Lives Remaining: " + lives;
    }
    public void decreaseLives()
        {
        lives--;
        }
}
