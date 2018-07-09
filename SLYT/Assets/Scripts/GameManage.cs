using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {
    public static int i = 0;
    public GameObject begin;
    // Use this for initialization
    void Awake()
    {
        if (i == 0)
        {
            PlayerPrefs.SetFloat("save_x", begin.transform.position.x);
            PlayerPrefs.SetFloat("save_y", begin.transform.position.y);
            i++;
        }
        else;
    }
}
