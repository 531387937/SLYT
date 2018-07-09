using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePlace : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetFloat("save_x", transform.position.x);
            PlayerPrefs.SetFloat("save_y", transform.position.y);

        }
    }
}
