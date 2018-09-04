using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green_born : MonoBehaviour {
    public GameObject green;
    GameObject son;
    float count = 0;
    public float time_;
	// Use this for initialization
	void Start () {
        son=Instantiate(green, this.transform.position, Quaternion.Euler(Vector3.zero));
        son.transform.SetParent(this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if(son==null)
        {
            count += Time.deltaTime;
            if(count>time_)
            {
                count = 0;
                son = Instantiate(green, this.transform.position, Quaternion.Euler(Vector3.zero));
                son.transform.SetParent(this.transform);

            }
        }
	}
}
