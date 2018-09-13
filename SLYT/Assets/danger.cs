using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danger : MonoBehaviour {
    public GameObject dangerous;
    public GameObject Player;
    private bool IsVisible;
    private float an;
    private float i = 0;
	// Use this for initialization
	void Start () {
        Player=GameObject.FindGameObjectWithTag("Player");
        dangerous = GameObject.FindGameObjectWithTag("Danger");
	}
	// Update is called once per frame
	void Update () {
        float x = transform.position.x-Player.transform.position.x;
        float y =  transform.position.y-Player.transform.position.y;
        an = Mathf.Atan(y / x);
        if (y < 0 && x < 0)
        {
            an += Mathf.PI;
        }
        if (y > 0 && x < 0)
        {
            an += Mathf.PI;
        }
        if (!IsVisible)
        {
            dangerous.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(IsVisible)
        {
            dangerous.transform.GetChild(0).gameObject.SetActive(false);
        }
        dangerous.transform.position = new Vector3(Player.transform.position.x + 11 * Mathf.Cos(an), Player.transform.position.y + 11 * Mathf.Sin(an),0);
	}
    private void OnBecameInvisible()
    {
        IsVisible = false;
        if (i==1&& this.gameObject.GetComponent<zidan>().speed != 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnBecameVisible()
    {
        IsVisible = true;
        
            i = 1;
        
    }
}
