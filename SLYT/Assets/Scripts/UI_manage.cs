using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_manage : MonoBehaviour {
    public GameObject started;
    public GameObject[] maps;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
    }
    public void startgame()
    {
        started.gameObject.SetActive(false);
        for(int i=0; i<maps.Length; i++)
        {
            maps[i].SetActive(true);
        }
    }
    //载入标准场景
    public void stand()
    {
        PlayerPrefs.SetFloat("save_x", 2f);

        SceneManager.LoadScene(1);
    }
    //载入游乐园场景
    public void Park()
    {
        PlayerPrefs.SetFloat("save_x", 0);

        SceneManager.LoadScene(4);
    }
    //载入微观场景
    public void little()
    {
        PlayerPrefs.SetFloat("save_x", -78f);

        SceneManager.LoadScene(2);
    }
    //载入未来场景
    public void future()
    {
        PlayerPrefs.SetFloat("save_x", -60f);

        SceneManager.LoadScene(3);
    }
    //载入Boss场景
    public void Boss()
    {
        SceneManager.LoadScene(5);
    }
}
