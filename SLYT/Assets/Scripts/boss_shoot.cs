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




    float z;
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


        z = Mathf.Atan2(this.transform.position.x-player.transform.position.x ,this.transform.position.y - player.transform.position.y);
        z = -z * 180 / Mathf.PI;
        count += Time.deltaTime;
		if(canshoot&&count>shoot_count)
        {
            int stage = Random.Range(1, 1);
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

                    }
                    break;
                case 3:
                    {

                    }
                    break;
                default:
                    {

                    }
                    break;
            }
        }
	}
    IEnumerator shooooo1()
    {
        Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        yield return new WaitForSeconds(0.3f);
        Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        yield return new WaitForSeconds(0.3f);
        Instantiate(shoot_1, this.transform.position, Quaternion.Euler(0, 0, z + 180));
        yield return new WaitForSeconds(0.3f);
        yield break;
    }
}
