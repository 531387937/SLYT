using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paopaogululu : MonoBehaviour {
    public GameObject paopao;
    public float maxscal;
    public float minscal;
    public float jiange;
    float taimu = 0;
    float taimu2 = 3;
	// Use this for initializationd
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        taimu += Time.deltaTime;
        taimu2 += Time.deltaTime;
        if (taimu>jiange)
        {
            taimu = 0;
            Instantiate(paopao, new Vector3(this.transform.position.x + Random.Range(-6,0),this.transform.position.y,0),Quaternion.Euler(Vector3.zero));
            
        }
        if(taimu2>jiange)
        {
            taimu2 = 0;
            Instantiate(paopao, new Vector3(this.transform.position.x + Random.Range(0, 6), this.transform.position.y, 0), Quaternion.Euler(Vector3.zero));
        }
	}
}
