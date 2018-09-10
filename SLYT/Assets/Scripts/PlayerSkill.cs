using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour {
    public GameObject player_sign;
    public float sign_speed;
    public AudioSource R1;
    public AudioSource R2;
    public int power = 1;
    public green Green;
    public bool isGreen = false;
    public bool beg_move = false;
    Vector3 target;
    public GameObject greenGameObject;
    public GameObject guidaooo;
    Vector3 fangxiang = Vector3.right;
    Vector3 beifen_fangxiang = Vector3.right;
    public float time_count = 1.5f;
    float time_ = 0;
    public bool cam_guding;
    // Use this for initialization
    void Start()
    {


    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "noPower"&&!beg_move)
            power = 2;
    }
    private void FixedUpdate()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            beifen_fangxiang = Input.GetAxis("Horizontal") * Vector3.right;
            beifen_fangxiang = beifen_fangxiang.normalized;
        }
        //Vector3.Distance(player_sign.transform.position, this.transform.position) < 1f &&

        if ((Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.Z)) && Vector3.Distance(player_sign.transform.position, this.transform.position) < 3f && !beg_move&&power!=0)
        {
            this.gameObject.GetComponent<TrailRenderer>().time = 0.5f;
            R1.Play();
            player_sign.GetComponent<Follow>().enabled = false;
            beg_move = true;
            fangxiang = new Vector3(Input.GetAxis("4"), Input.GetAxis("5"), 0f);
            if (fangxiang == new Vector3(0, 0, 0))
            {
                fangxiang = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            }
            fangxiang = fangxiang.normalized;
            if (fangxiang.magnitude == 0)
            {
                fangxiang = beifen_fangxiang;
            }
        }
        if (Input.GetMouseButtonDown(0) && !beg_move && Vector3.Distance(player_sign.transform.position, this.transform.position) < 3f && power != 0)
        {
            this.gameObject.GetComponent<TrailRenderer>().time = 0.5f;
            R1.Play();
            player_sign.GetComponent<Follow>().enabled = false;
            beg_move = true;
            Vector3 pos = Camera.main.WorldToScreenPoint(player_sign.transform.position);


            fangxiang =Input.mousePosition -pos;
      
            //if (fangxiang == new Vector3(0, 0, 0))
            //{
            //    fangxiang = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            //}

            fangxiang = fangxiang.normalized;
            //if (fangxiang.magnitude == 0)
            //{
            //    fangxiang = beifen_fangxiang;
            //}
        }
        if (!isGreen)
        {
            if (power == 0)
            {
                this.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowColor", Color.red);
                //this.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowTexColor", Color.red);
            }
            else
            {
                this.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowColor", Color.blue);
                //this.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowTexColor", Color.blue);
            }
        }
       else
        {
            this.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowColor", Color.green);
            // this.GetComponentInChildren<MeshRenderer>().material.SetColor("_MKGlowTexColor", Color.green);
        }
        if (beg_move)
        {
            time_ += Time.deltaTime;

            player_sign.GetComponent<Rigidbody>().velocity = fangxiang * sign_speed;

            if ( time_ >= time_count+0.4)
            {
                player_sign.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                //  player_sign.GetComponent<MeshRenderer>().material.SetColor("_GlowColor", Color.yellow);

                player_sign.GetComponent<Follow>().enabled = true;
                time_ = 0;
                beg_move = false;
            }
            if (!isGreen)
            {
              

                if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(1))
                {
                    power -= 1;
                    R2.Play();
                    transform.position = player_sign.transform.position;

                    player_sign.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);


                    player_sign.GetComponent<Follow>().enabled = true;
                    Color c = Random.ColorHSV(0.5f, 1f, 0.5f, 1f, 0.5f, 1f);
                   
                    time_ = 0;
                    beg_move = false;
                }
            }
            if (isGreen)
            {
               

                if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(1))
                {
                    float x = player_sign.transform.position.x - transform.position.x;
                    float y= player_sign.transform.position.y - transform.position.y;
                    float a=Mathf.Atan(y / x);
                    if(y<0&&x<0)
                    {
                        a += Mathf.PI;
                    }
                   if(y>0&&x<0)
                    {
                        a += Mathf.PI;
                    }
                    //if (a > 0)
                    //{
                        Vector3 ve = new Vector3(2*transform.position.x + 7.5f*Mathf.Cos(a), 2*transform.position.y +7.5f*Mathf.Sin(a), 0)/2;
                        Green.greenGuidao=Instantiate(greenGameObject, ve, Quaternion.EulerAngles(0, 0, a));
                        Green.greenGuidao.SetActive(true);
                    //}
                    //if (a < 0)
                    //{
                    //    Vector3 ve = new Vector3(2 * transform.position.x + 7.5f * Mathf.Cos(a+Mathf.PI), 2 * transform.position.y + 7.5f * Mathf.Sin(a+Mathf.PI), 0) / 2;
                    //    Green.greenGuidao=Instantiate(greenGameObject, ve, Quaternion.EulerAngles(0, 0, a -Mathf.PI));
                    //    Green.greenGuidao.SetActive(true);
                    //}
                    R2.Play();
                    player_sign.transform.position=transform.position;

                    player_sign.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);


                    player_sign.GetComponent<Follow>().enabled = true;
                    Color d = Random.ColorHSV(0.5f, 1f, 0.5f, 1f, 0.5f, 1f);

                    time_ = 0;
                    beg_move = false;
                    isGreen = false;
                }
            }
            if (time_ >= time_count-0.1f&&time_<time_count+0.4)
            {
                player_sign.GetComponent<Rigidbody>().velocity = 0.2f * fangxiang * sign_speed;
                player_sign.GetComponent<MeshRenderer>().material.SetColor("_GlowColor", Random.ColorHSV(0.5f, 1f, 0.5f, 1f, 0.5f, 1f));
             }
        }
    }
    public void back()
    {
        time_ = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="guidao")
        {
            guidaooo = other.gameObject;
            cam_guding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="guidao")
        {
            cam_guding = false;
        }
    }
}
