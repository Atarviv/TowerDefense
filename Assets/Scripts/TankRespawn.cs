using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TankRespawn : MonoBehaviour
{
    public Transform RespawnPos;
    public float RespawnTime;
    [Header("Tanks")]
    public GameObject RedTank;
    public GameObject BlueTank;
    public GameObject GreenTank;
    public GameObject YellowTank;
    List<GameObject> Tanks;
    public bool GameRunning;
    int rnd;
    // Start is called before the first frame update
    void Start()
    {
        Tanks = new List<GameObject>();
        Tanks.Add(RedTank);
        Tanks.Add(BlueTank);
        Tanks.Add(GreenTank);
        Tanks.Add(YellowTank);
        StartCoroutine("TankRespawnFunc");
        GameRunning = true;
    }
    IEnumerator TankRespawnFunc()
        {
        while (RespawnTime > 2)
            {
            rnd = Random.Range(0, 4);
            Instantiate(Tanks[rnd], RespawnPos.position, BlueTank.transform.rotation);
            yield return new WaitForSeconds(RespawnTime);
            }
        }
    // Update is called once per frame
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
