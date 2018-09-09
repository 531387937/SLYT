using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dajiguangbianchengxiaojiguang : MonoBehaviour {
    public float  speed;
    public GameObject player;
    public GameObject boss;
    public float dam_time;
    // Use this for initialization
    private void Awake()
    {

    }
    void Start () {
        StartCoroutine(bianxiao());
	}
	
	// Update is called once per frame
	void Update () {
        dam_time -= Time.deltaTime;
        if(dam_time<0)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
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
