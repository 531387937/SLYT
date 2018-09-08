using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class savePlace : MonoBehaviour
{
    public GameObject BOSS;
    private void Start()
    {
        BOSS = GameObject.FindGameObjectWithTag("boss");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetFloat("save_x", transform.position.x);
            PlayerPrefs.SetFloat("save_y", transform.position.y);
            if(SceneManager.GetActiveScene().name=="boss")
            {
                PlayerPrefs.SetFloat("boss_x", BOSS.transform.position.x);
                PlayerPrefs.SetFloat("boss_y", BOSS.transform.position.y);
            }
        }
    }
}
