using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paopaopiaoyapiao : MonoBehaviour {
    private PlayerCtr PlayerCtr;

    public GameObject player;
    // Use this for initialization
    private void Awake()
    {
        PlayerCtr = GetComponent<PlayerCtr>();
    }
    void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            other.GetComponent<PlayerCtr>().piao = true;





        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Vector3.Distance(other.transform.position, this.transform.position) < 0.5f * (this.transform.localScale.x - other.transform.localScale.x)
            
               
                Debug.Log(1);
          

            
              
            
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            other.GetComponent<PlayerCtr>().piao = false;



        }
    }
}
