using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FASHE : MonoBehaviour {
    public GameObject player;
    public GameObject[] shoot;
    public GameObject[] yujing;
    public GameObject BOOM;
    //public GameObject shoot2;
    //public GameObject shoot3;

    float count = 0;
    public float shoot_delay_time;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(player.transform.position.x - this.transform.position.x) < 15 && player.transform.position.y > 120)
        {
            count += Time.deltaTime;
            if (count > shoot_delay_time)
            {

                count = 0;
                int a = (int)Random.Range(0, 2.9999f);
                for (int i = 0; i <= 2; i++)
                {

                    if (i != a)
                    {
                        StartCoroutine(warning(i));
                    }
                }

            }
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y + 40, 0);



        }
       




	}
    IEnumerator warning(int i)
    {
        yujing[i].GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(2f);
        yujing[i].GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        Instantiate(BOOM, shoot[i].transform.position - new Vector3(0, 40, 0), Quaternion.Euler(Vector3.zero));
        yield break;
    }
}
