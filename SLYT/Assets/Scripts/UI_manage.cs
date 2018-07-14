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
        PlayerPrefs.DeleteAll();
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
        SceneManager.LoadScene(1);
    }
    //载入游乐园场景
    public void Park()
    {
        SceneManager.LoadScene(2);
    }
    //载入微观场景
    public void little()
    {
        SceneManager.LoadScene(3);
    }
    //载入未来场景
    public void future()
    {
        SceneManager.LoadScene(4);
    }
    //载入Boss场景
    public void Boss()
    {
        SceneManager.LoadScene(5);
    }
}
