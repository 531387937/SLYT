using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paopaopiaoyapiao : MonoBehaviour {
    private PlayerCtr PlayerCtr;
    public float max;
    public float min;
    public Vector3 dir;
    public GameObject player;
    float t;
    float timm;
    float speed;
    public float maxspeed=1.2f;
    public float minspeed=0.6f;
    private AudioSource paopao;
    bool playerin=false;
    
    // Use this for initialization
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerCtr =player. GetComponent<PlayerCtr>();
        paopao = GetComponent<AudioSource>();
    }
    void Start () {
        this.transform.localScale = new Vector3(1, 1, 1);
        speed = Random.Range(minspeed, maxspeed);

    }
	// Update is called once per frame
	void Update () {
        this.transform.position += dir *speed  * Time.deltaTime;
        timm += Time.deltaTime;
        if(timm<0.3f)
        {
            t = timm * (10 / 3);
            this.transform.localScale = new Vector3(Mathf.Lerp(min, max, t), Mathf.Lerp(min, max, t), Mathf.Lerp(min, max, t));

        }
       


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Untagged")
        {

            if (playerin)
            {
                player.GetComponent<PlayerCtr>().piao = false;
                Destroy(this.gameObject);
            }
            else
            Destroy(this.gameObject);

        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            other.GetComponent<PlayerCtr>().piao = true;
            other.GetComponent<PlayerSkill>().power = 1;
            paopao.Play();
            playerin = true;


        }

    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerin = false;
            other.GetComponent<PlayerCtr>().piao = false;



        }
    }
}
