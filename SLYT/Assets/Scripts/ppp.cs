using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ppp : MonoBehaviour {
    public GameObject paopao;
    public float timeee__;
    public float jiange;
    float taimu = 0;
    float taimu2 = 3;
    // Use this for initializationd
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        taimu += Time.deltaTime;
        taimu2 += Time.deltaTime;
        if (taimu > timeee__)
        {
            taimu = 0;
            Instantiate(paopao, new Vector3(this.transform.position.x , this.transform.position.y + Random.Range(-jiange, 0), 0), Quaternion.Euler(Vector3.zero));

        }
        if (taimu2 > timeee__)
        {
            taimu2 = 0;
            Instantiate(paopao, new Vector3(this.transform.position.x , this.transform.position.y + Random.Range(0, jiange), 0), Quaternion.Euler(Vector3.zero));
        }
    }
}
