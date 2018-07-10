using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour {
    public GameObject enemy;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            enemy.SetActive(true);
        }
    }
}
