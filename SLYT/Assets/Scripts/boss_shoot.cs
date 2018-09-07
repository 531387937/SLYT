using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_shoot : MonoBehaviour {
    public bool canshoot = true;
    public GameObject player;
    public float shoot_count;
    
    public GameObject shoot_1;
    public GameObject shoot_2;
    public GameObject shoot_3;
    public GameObject miaozhun;



    public float z;
    float count = 0;

    // Use this for initialization
    void Start () {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(this.transform.position,player.transform.position)<=5)
        {
            canshoot = false;
        }
        else
        {
            canshoot = true;
        }


        z = Mathf.Atan2(this.transform.position.x-player.transform.position.x ,this.transform.position.y - player.transform.position.y);
        z = -z * 180 / Mathf.PI;
        count += Time.deltaTime;
		if(canshoot&&count>shoot_count)
        {
            int stage = Random.Range(3, 3);
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
        GameObject hongxian= Instantiate(miaozhun);
        yield return new WaitForSeconds(2f);
        Destroy(hongxian);
        Instantiate(shoot_3);

        yield return null;
    }
    IEnumerator shoooo2()
    {
        GameObject ssss= Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        yield return new WaitForSeconds(0.5f);
        float speeeeeee = ssss.GetComponent<zidan>().speed;
        ssss.GetComponent<zidan>().speed = 0;
        for(int i=0;i<40;i++)
        {
            ssss.transform.localScale = new Vector3(0.2f + 0.01f * i, 0.2f + 0.01f * i, 0.2f + 0.01f * i);
            ssss.transform.localRotation = Quaternion.Euler(0, 0, z + 180);
            yield return null;
        }
        ssss.transform.localRotation = Quaternion.Euler(0, 0, z + 180);
        ssss.GetComponent<zidan>().speed = speeeeeee*3.5f;
        yield break;
    }
    IEnumerator shooooo1()
    {
        Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        yield return new WaitForSeconds(0.15f);
        Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        yield return new WaitForSeconds(0.15f);
        Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        yield return new WaitForSeconds(0.15f);
        yield break;
    }
}
