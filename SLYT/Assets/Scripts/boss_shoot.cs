using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_shoot : MonoBehaviour {
    public bool canshoot = true;
    public GameObject player;
    public float shoot_count;
    public GameObject hongxian;
    public GameObject shoot_1;
    public GameObject shoot_2;
    public GameObject shoot_3;
    public GameObject miaozhun;
    public GameObject ssss;
    public float dis_cant_att;
    public Material mar;
    Color init;
    GameObject boss;

    public AudioSource qinggongji;
    public AudioSource zhonggongji;
    public AudioSource miaozhun_mic;
    public AudioSource jiguang_mic;
    public AudioSource taishou;
    float range_min=1;
    float range_max=4;
    public float z;
    float count = 0;

    // Use this for initialization
    void Start () {
        init = new Color(0, 0.5f, 0.5f,1f);
        boss = this.gameObject;
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(this.transform.position.x>1229)
        {
            if(player.transform.position.x<1248)
            {
                range_max = 3;
                range_min = 3;
            }
            else
            {
                range_max = 4;
                range_min = 1;
                canshoot = true;
                mar.SetColor("_MKGlowColor", init);
            }
        }
        else
        {

            if (Vector3.Distance(this.transform.position, player.transform.position) <= dis_cant_att)
            {
                canshoot = false;
                mar.SetColor("_MKGlowColor", Color.red);
            }
            else
            {
                mar.SetColor("_MKGlowColor", init);
                canshoot = true;
            }
        }


        

        z = Mathf.Atan2(this.transform.position.x-player.transform.position.x ,this.transform.position.y - player.transform.position.y);
        z = -z * 180 / Mathf.PI;
        count += Time.deltaTime;
		if(canshoot&&count>shoot_count)
        {
            int stage =(int) Random.Range(range_min, range_max);
            switch(stage)
            {
                
                case 1:
                    {
                        StartCoroutine(shooooo1());
                        
                        count = 0;
                    }
                    break;
                case 2:
                    {
                        StartCoroutine(shoooo2());

                        count = 0;
                    }
                    break;
                case 3:
                    {
                        StartCoroutine(dadadadaddaajiguang());
                        count = 0;
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
        }
	}
    IEnumerator dadadadaddaajiguang()
    {
        hongxian= Instantiate(miaozhun);
        miaozhun_mic.Play();
        yield return new WaitForSeconds(2f);
        
        Destroy(hongxian);

        float z = boss.GetComponent<boss_shoot>().z;
        //Vector3 jiguang_pos = new Vector3((player.transform.position.x + boss.transform.position.x) / 2, (player.transform.position.y + boss.transform.position.y) / 2, 0);
        Vector3 jiguang_Scale = new Vector3(this.transform.localScale.x, 30+Vector3.Distance(player.transform.position, boss.transform.position) / 2, this.transform.localScale.z);
        Quaternion jiguang_Rotation = Quaternion.Euler(new Vector3(0, 0, z + 180));
        Vector3 jiguang_pos = new Vector3((player.transform.position.x + boss.transform.position.x) / 2, (player.transform.position.y + boss.transform.position.y) / 2, 0);
        Vector3 dir = new Vector3(player.transform.position.x - boss.transform.position.x, player.transform.position.y - boss.transform.position.y, 0);
        dir = Vector3.Normalize(dir);
        jiguang_pos += dir * 30;

        
        yield return new WaitForSeconds(0.65f);
        jiguang_mic.Play();

        GameObject jiguang= Instantiate(shoot_3);
        jiguang.transform.position = jiguang_pos;
        jiguang.transform.localScale = jiguang_Scale;
        jiguang.transform.localRotation = jiguang_Rotation;
        
        yield return null;
    }
    IEnumerator shoooo2()
    {
        ssss= Instantiate(shoot_2, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        yield return new WaitForSeconds(0.5f);
        taishou.Play();
        float speeeeeee = ssss.GetComponent<zidan>().speed;
        ssss.GetComponent<zidan>().speed = 0;
       
        for(int i=0;i<40;i++)
        {
            ssss.transform.localScale = new Vector3(0.2f + 0.01f * i, 0.2f + 0.01f * i, 0.2f + 0.01f * i);
            ssss.transform.localRotation = Quaternion.Euler(0, 0, z + 180);
            yield return null;
        }
        zhonggongji.Play();
        ssss.transform.localRotation = Quaternion.Euler(0, 0, z + 180);
        ssss.GetComponent<zidan>().speed = speeeeeee*3.5f;
        yield break;
    }
    IEnumerator shooooo1()
    {
        Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        qinggongji.Play();

        yield return new WaitForSeconds(0.15f);
        Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        qinggongji.Play();

        yield return new WaitForSeconds(0.15f);
        Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        qinggongji.Play();

        yield return new WaitForSeconds(0.15f);
        yield break;
    }
}
