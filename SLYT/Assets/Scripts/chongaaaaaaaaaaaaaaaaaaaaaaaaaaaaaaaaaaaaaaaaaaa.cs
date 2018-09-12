using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chongaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa : MonoBehaviour {
    public GameObject guidao_40jie;
    public GameObject player;
    bool builded = false;
	// Use this for initialization
	void Start () {
        guidao_40jie = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");

	}
    private void FixedUpdate()
    {
        if(Mathf.Abs(player.transform.position.x-this.transform.position.x)<15)
        {
            if(player.transform.position.y>this.transform.position.y&& !builded&&this.transform.position.y<600)
            {
                Instantiate(guidao_40jie, this.transform.position + new Vector3(0, 40, 0), Quaternion.Euler(Vector3.zero));
                builded = true;
            }
            if (player.transform.position.y > this.transform.position.y+80)
            {
                Destroy(this.gameObject);
            }

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
