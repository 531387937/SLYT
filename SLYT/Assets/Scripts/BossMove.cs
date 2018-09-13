using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {
    public Transform[] trs;
    private bool move=false;
    private bool Touch=true;
    public static int posi = 0;
    public int pos = 0;
    public static int i = 0;
    // Use this for initialization
    void Awake()
    {
        if (i == 0)
        {
            PlayerPrefs.SetFloat("boss_x", transform.position.x);
            PlayerPrefs.SetFloat("boss_y", transform.position.y);
            i++;
        }
        else;
        pos = posi;
    }
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(PlayerPrefs.GetFloat("boss_x"), PlayerPrefs.GetFloat("boss_y"), 0);
    }
	
	// Update is called once per frame
	void Update () {
		if(move)
        {
           
            gameObject.transform.position = Vector3.MoveTowards(transform.position, trs[pos - 1].position, 15f*Time.deltaTime);
            if (gameObject.transform.position==trs[pos-1].position)
            {
                move = false;
                Touch = true;
                this.GetComponent<boss_shoot>().enabled = true;
            }
        }
       
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"&&Touch)
        {
            pos += 1;
            move = true;
            this.GetComponent<boss_shoot>().StopAllCoroutines();
            Destroy(this.GetComponent<boss_shoot>().hongxian);
            Destroy(this.GetComponent<boss_shoot>().ssss);
            this.GetComponent<boss_shoot>().jiguang_mic.Stop();
            this.GetComponent<boss_shoot>().miaozhun_mic.Stop();
            this.GetComponent<boss_shoot>().taishou.Stop();
            this.GetComponent<boss_shoot>().zhonggongji.Stop();





            this.GetComponent<boss_shoot>().enabled = false;
           Touch = false;
        }
    }
}
