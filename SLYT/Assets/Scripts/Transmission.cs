using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {
    public GameObject brother;
    private Vector3 brotherPos;
    private Transform brotherTr;
    private float angle;
    private Vector3 trans;
	// Use this for initialization
	void Start () {
        brotherPos = brother.transform.position;
        brotherTr = brother.transform;
        angle = brotherTr.eulerAngles.z;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {

            brother.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(wait());
            Rigidbody rig = other.transform.GetComponent<Rigidbody>();
            rig.velocity = other.transform.GetComponent<Rigidbody>().velocity;


            other.transform.position = brotherPos;
            float vel = rig.velocity.magnitude;
            Debug.Log(Mathf.Cos(angle * (3.14f / 180)));
            rig.velocity = Vector3.zero;
            trans=rig.velocity = new Vector3(-Mathf.Sin(angle*(Mathf.PI/180)), Mathf.Cos(angle*(Mathf.PI / 180)), 0) *vel;
            other.SendMessage("Trans",(object)trans);
            //print(other.GetComponent<Rigidbody>().velocity);

        }
    }
   IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        brother.GetComponent<BoxCollider>().enabled = true;
    }
}
