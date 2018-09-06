using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shengcheng : MonoBehaviour {
    public GameObject sc_;
    public GameObject son;
    float count = 0;
    public float time_;
    // Use this for initialization
    void Start () {
        son = this.gameObject.transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (son == null)
        {
            count += Time.deltaTime;
            if (count > time_)
            {
                count = 0;
                son = Instantiate(sc_, this.transform.position, Quaternion.Euler(Vector3.zero));
                son.transform.SetParent(this.transform);

            }
        }
    }
}
