using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour {
    public static int collect = 0;
    // Use this for initialization
    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            collect++;
            print(collect);
            Destroy(this.gameObject);
        }
    }
}
