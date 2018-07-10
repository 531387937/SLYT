using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtr : MonoBehaviour {
    public GameObject Player;
    public float speed;
    private Vector3 target;
    private Vector3 vec;
    [SerializeField]
    private float timer;
    private bool Go;
    // Use this for initialization
    private void Awake()
    {
        Go = false;
    }
    void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(timer<2.5)
        {
            timer += Time.deltaTime;
        }
        if(timer>=2.5&&timer<=3)
        {
            timer += Time.deltaTime;
target = Player.transform.position+vec*3;
            vec = (Player.transform.position - transform.position).normalized;
            transform.position -= vec*2 * Time.deltaTime;
        }
        if(timer>3)
        {

            Go = true;
        }
        if(Go)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime); if((transform.position-target).magnitude<3f)
        {
            speed = Mathf.Lerp(speed, 0, 0.5f);
           

        }
        }
       
        if ((transform.position - target).magnitude <0.1f)
        {
            speed=15;
            timer = 0;
            Go = false;
            target = Player.transform.position;

        }
    }
    private void FixedUpdate()
    {
    }
   
    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.tag=="Player")
        {
            other.gameObject.SendMessage("death");
        }
    }
}
