using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suizhuan : MonoBehaviour {
    public float time_;
    public float count=0;
    bool beginsui = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(beginsui)
        {
            count += Time.deltaTime;
            if (count > time_)
            {
                Destroy(this.gameObject);
            }
        }

	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(collision.gameObject.GetComponent<PlayerCtr>().isground==true)
            {
                beginsui = true;
            }
        }
    }
}
