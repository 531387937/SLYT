using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dajiguangbianchengxiaojiguang : MonoBehaviour {
    public float  speed;
    public GameObject player;
    public GameObject boss;
    // Use this for initialization
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("boss");

        float z = boss.GetComponent<boss_shoot>().z;
        this.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) / 2, (player.transform.position.y + boss.transform.position.y) / 2, 0);
        this.transform.localScale = new Vector3(this.transform.localScale.x, Vector3.Distance(player.transform.position, boss.transform.position) / 2+ 50, this.transform.localScale.z);
        this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, z + 180));
    }
    void Start () {
        StartCoroutine(bianxiao());
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localScale.x < 0)
        {
            Destroy(this.gameObject);
            
        }
    }
    IEnumerator bianxiao()
    {
        for(int i=0;i<30;i++)
        {
            this.transform.localScale -=new Vector3(speed, 0, speed);
            yield return null;
        }
        yield break;

    }
}
