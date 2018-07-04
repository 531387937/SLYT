using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour {
    public GameObject player_sign;
    public float sign_speed;
    public AudioSource R1;
    public AudioSource R2;


    bool beg_move = false;
    Vector3 target;
    Vector3 fangxiang = Vector3.right;
    Vector3 beifen_fangxiang;
    public float time_count = 1.5f;
    float time_ = 0;
    // Use this for initialization
    void Start()
    {


    }
    private void FixedUpdate()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        print(Input.GetAxis("4"));
        print(Input.GetAxis("5"));
        if (Input.GetAxis("Horizontal") != 0)
        {
            beifen_fangxiang = Input.GetAxis("Horizontal") * Vector3.right;
            beifen_fangxiang = beifen_fangxiang.normalized;
        }

        if ((Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.Z)) && !beg_move)
        {

            //R1.Play();
            player_sign.GetComponent<Follow>().enabled = false;
            beg_move = true;
            fangxiang = new Vector3(Input.GetAxis("4"), Input.GetAxis("5"), 0f);

            fangxiang = fangxiang.normalized;
            if (fangxiang.magnitude == 0)
            {
                fangxiang = beifen_fangxiang;
            }
        }
        if (beg_move)
        {
            time_ += Time.deltaTime;

            player_sign.GetComponent<Rigidbody>().velocity = fangxiang * sign_speed;

            if ( time_ >= time_count)
            {
                player_sign.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                //  player_sign.GetComponent<MeshRenderer>().material.SetColor("_GlowColor", Color.yellow);

                player_sign.GetComponent<Follow>().enabled = true;
                time_ = 0;
                beg_move = false;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.X))
            {
                //R2.Play();
                transform.position = player_sign.transform.position;
            
                player_sign.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);


                player_sign.GetComponent<Follow>().enabled = true;
                time_ = 0;
                beg_move = false;

            }
            if (time_ >= time_count-0.2f&&time_<time_count)
            {
                player_sign.GetComponent<Rigidbody>().velocity = 0.3f * fangxiang * sign_speed;

               

            }

        }



    }
}
