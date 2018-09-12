using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backmeun : MonoBehaviour {
    public GameObject Pause;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Pause.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            SceneManager.LoadScene(0);
            GameManage.i = 0;
            BossMove.posi = 0;
        }
    }
    public void BackGame()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
    }
    public void BackMaun()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        GameManage.i = 0;
        BossMove.posi = 0;
    }
}
