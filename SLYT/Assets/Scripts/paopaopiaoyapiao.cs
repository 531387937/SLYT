using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paopaopiaoyapiao : MonoBehaviour {
    private PlayerCtr PlayerCtr;
    public float max;
    public float min;
    public GameObject player;
    float t;
    float timm;
    float speed;
        
       
    
    // Use this for initialization
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerCtr =player. GetComponent<PlayerCtr>();
    }
    void Start () {
        this.transform.localScale = new Vector3(1, 1, 1);
        speed = Random.Range(0.6f, 1.2f);

    }
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.up *speed  * Time.deltaTime;
        timm += Time.deltaTime;
        if(timm<0.3f)
        {
            t = timm * (10 / 3);
            this.transform.localScale = new Vector3(Mathf.Lerp(min, max, t), Mathf.Lerp(min, max, t), Mathf.Lerp(min, max, t));

        }
       
        if(this.transform.position.y>40)
        {
            Destroy(this.gameObject);
        }



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
