using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBegin : MonoBehaviour {
    private bool Plane=false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!Plane)
            {
                this.transform.parent.GetComponent<Animator>().enabled = true;
                Plane = true;
            }
        }
    }
}
