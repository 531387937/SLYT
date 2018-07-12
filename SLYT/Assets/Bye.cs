using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bye : MonoBehaviour {
    public GameObject Enemy;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Enemy.SetActive(false);
        }
    }
}
