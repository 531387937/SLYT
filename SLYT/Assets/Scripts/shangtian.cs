using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shangtian : MonoBehaviour {
     public float force;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.SendMessage("stop",true);
            float z = this.gameObject.transform.parent.rotation.eulerAngles.z;
            float x = z * (Mathf.PI / 180);
            if (this.transform.rotation.eulerAngles.z > 180)
            {
                other.GetComponent<Rigidbody>().AddForce(new Vector3(-Mathf.Cos(x) * force * Time.fixedDeltaTime, -Mathf.Sin(x) * force * Time.fixedDeltaTime, 0), ForceMode.Acceleration);
               // other.GetComponent<Rigidbody>().velocity = new Vector3(-Mathf.Cos(x) * force, -Mathf.Sin(x) * force, 0);
            }
            else
                other.GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Cos(x) * force*Time.fixedDeltaTime, Mathf.Sin(x) * force * Time.fixedDeltaTime, 0), ForceMode.Acceleration);
           // other.GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Cos(x) * force+Mathf.Sin(x)*0.15f*force, Mathf.Sin(x) * force, 0);
            //Debug.Log(new Vector3(Mathf.Cos(x) * force, Mathf.Sin(x) * force, 0));
            //other.GetComponent<Rigidbody>().velocity = new Vector3( Mathf.Sin(z - Mathf.PI/2) * force, Mathf.Cos(z - Mathf.PI / 2) * force, 0);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        other.SendMessage("stop",false);
    //    }
    //}
}

