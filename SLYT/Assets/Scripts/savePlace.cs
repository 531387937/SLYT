using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class savePlace : MonoBehaviour
{
    public GameObject BOSS;
    public int BossPos;
    private void Start()
    {
        BOSS = GameObject.FindGameObjectWithTag("boss");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (SceneManager.GetActiveScene().name == "boss")
            {
                if (BossPos == BOSS.GetComponent<BossMove>().pos)
                {
                    BossMove.posi = BossPos;
                    PlayerPrefs.SetFloat("save_x", transform.position.x);
                    PlayerPrefs.SetFloat("save_y", transform.position.y);
                    PlayerPrefs.SetFloat("boss_x", BOSS.transform.position.x);
                    PlayerPrefs.SetFloat("boss_y", BOSS.transform.position.y);
                }
                else;
            }
            else
            {
                PlayerPrefs.SetFloat("save_x", transform.position.x);
                PlayerPrefs.SetFloat("save_y", transform.position.y);
            }
        }
    }
}
