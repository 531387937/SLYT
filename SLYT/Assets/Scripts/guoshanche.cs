using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guoshanche : MonoBehaviour {
    public GameObject danyuan;
    public float r;
    public bool left;
    float hu = 1;
    public float yaunbuyan;
	// Use this for initialization
	void Start () {
		if(left)
        {
            float n = hu / r;
            float geshu = 2*Mathf.PI / n;
            for(int i=0;i<geshu* yaunbuyan; i++)
            {
                Vector3 pos = new Vector3(transform.position.x + Mathf.Sin(i * n) * r, transform.position.y - Mathf.Cos(i * n) * r, 0);
                float z = ((Mathf.PI / 2) + i * n)*(180/Mathf.PI)-90;
                Instantiate(danyuan, pos, Quaternion.Euler(0,0,z));
            }
           // Instantiate(danyuan,)
        }
        else
        {
            float n = hu / r;
            float geshu = 2*Mathf.PI / n;
            for (int i = 1; i < geshu* yaunbuyan; i++)
            {
                Vector3 pos = new Vector3(transform.position.x - Mathf.Sin(i * n) * r, transform.position.y - Mathf.Cos(i * n) * r, 0);
                float z = ((Mathf.PI / 2) - i * n) * (180 / Mathf.PI) -90 ;
                Instantiate(danyuan, pos, Quaternion.Euler(0, 0, z));
            }
        }





	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
