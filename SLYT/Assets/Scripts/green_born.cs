using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green_born : MonoBehaviour {
    GameObject son;
    
    float count = 0;
    public float time_;
    // Use this for initialization
    void Start()
    {

        son = gameObject.transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		if(!son.activeInHierarchy)
        {
            count += Time.deltaTime;
            if(count>time_)
            {
                count = 0;
                son.SetActive(true);

            }
        }
	}
}
