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
                    PlayerPrefs.SetFloat("boss_x", BOSS.GetComponent<BossMove>().trs[BossPos-1].position.x);
                    PlayerPrefs.SetFloat("boss_y", BOSS.GetComponent<BossMove>().trs[BossPos-1].position.y);
                    this.GetComponent<AudioSource>().Play();
                    this.gameObject.GetComponentInChildren<MeshRenderer>().material.SetFloat("_MKGlowPower", 10);
                }
                else;
            }
            else
            {
                PlayerPrefs.SetFloat("save_x", transform.position.x);
                PlayerPrefs.SetFloat("save_y", transform.position.y);
                this.gameObject.GetComponentInChildren<MeshRenderer>().material.SetFloat("_MKGlowPower", 10);
                this.GetComponent<AudioSource>().Play();
            }
        }
    }
}
