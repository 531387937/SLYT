using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour {
    // Use this for initialization
    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            other.GetComponent<PlayerSkill>().isGreen = true;
            Color c = Color.green;
            other.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowColor", c);
            other.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowTexColor", c);
            this.gameObject.SetActive(false);
        }
    }
}
