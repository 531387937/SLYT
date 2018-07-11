using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanChuang : MonoBehaviour {
    public float speed;
    public AudioSource jump;
    Vector3 rrr;
    // Use this for initialization
    void Start()
    {
        float ro = transform.rotation.z;
        rrr = new Vector3(-Mathf.Sin(ro) * speed, Mathf.Cos(ro) * speed, 0);
        rrr = rrr.normalized;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            jump.Play();
            //collision.rigidbody.velocity = new Vector3(collision.rigidbody.velocity.x,speed, 0);
            collision.rigidbody.velocity = rrr * speed;
        }
    }
}
