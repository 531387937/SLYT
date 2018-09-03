using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMove : MonoBehaviour {
    public float moveSpeed;
    public float rot;
    public int direction;
	// Use this for initialization
	void Start () {
        rot = this.gameObject.transform.localEulerAngles.z;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (direction >= 0) direction = 1;
        if (direction < 0) direction = -1;
      
	}
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position += new Vector3(moveSpeed * Mathf.Cos(rot / 180 * Mathf.PI), moveSpeed * Mathf.Sin(rot / 180 * Mathf.PI), 0)*Time.deltaTime*direction;
        }
    }
    
}
