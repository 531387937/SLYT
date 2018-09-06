using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green : MonoBehaviour {
    public GameObject greenGuidao;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (greenGuidao != null)
                Destroy(greenGuidao);
            other.GetComponent<PlayerSkill>().isGreen = true;
            other.GetComponent<PlayerSkill>().Green = this;
            this.gameObject.SetActive(false);
        }
    }
}
