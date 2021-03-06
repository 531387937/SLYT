﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCtr : MonoBehaviour {
    private Rigidbody rig;
    public float movespeed;
    public float jump_velociy;
    private Vector3 point;
    public bool isground;
    public AudioSource A;
    private Vector3 tran;
    private bool tr;
    private bool no=false;
    public bool piao = false;
    private GameObject children;
    public bool speedup = false;
    // Use this for initialization
    void Start()
    {
        //children = transform.GetChild(0).gameObject;
        tr = false;
        // Horizontal Vertical
        tran = Vector3.zero;
        rig =GetComponent<Rigidbody>();
        transform.position = new Vector3(PlayerPrefs.GetFloat("save_x"), PlayerPrefs.GetFloat("save_y"), 0);


        if (SceneManager.GetActiveScene().name == "boss")
        {
            if(this.transform.position.x>322)
            {
                movespeed = 15;
                this.GetComponent<TrailRenderer>().material.SetColor("_MKGlowColor", Color.red);
                speedup = true;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (no)
        { transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * movespeed * Time.deltaTime); }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && isground)
        {
            A.Play();
            rig.velocity += new Vector3(rig.velocity.x, jump_velociy, 0);

        }
        if (isground && Input.GetAxis("Horizontal") == 0)
        {
            rig.velocity = new Vector3(0, rig.velocity.y, 0);
        }

        if(piao)
        {
            rig.useGravity = false;

        }
        else
        {
            rig.useGravity = true;
        }
        if(isground)
        {
            StartCoroutine(delay());
           

        }
        else
        {
            this.gameObject.GetComponent<TrailRenderer>().time = 0.5f;

        }


    }
    IEnumerator delay()
    {
        if(!speedup)
        {

        
             for (int i=0;i<=9;i++)
             {
                 this.gameObject.GetComponent<TrailRenderer>().time  -=0.005f;
                 yield return null;
             }
        }
        else
        {
            this.gameObject.GetComponent<TrailRenderer>().time = 0.5f;
        }
    }
    private void FixedUpdate()
    {
        if (!no)
        {
            if(piao)
            {
              
                rig.velocity = new Vector3(Input.GetAxis("Horizontal") * movespeed*0.5f, Input.GetAxis("Vertical") * movespeed*0.5f, 0) + tran;
            }
            if(!piao)
            {
                transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * movespeed * Time.deltaTime);
            }
            
            tran = new Vector3(tran.x, 0, 0);
        }
         point = transform.position - transform.up * 0.5f;
        Collider[] outputCols = Physics.OverlapSphere(point, 0.15f, LayerMask.GetMask("ground"));

        if (outputCols.Length != 0)
        {
            //if(this.GetComponent<PlayerSkill>().beg_move)
            //{
                isground = true;
            //}
          
        }
        else
        {
            isground = false;

        }
        if(isground)
        {

            tran = Vector3.zero;
            no = false;
        }

    }
    public void death()
    {

        StartCoroutine(end());

    }

    public void succeed(string str)
    {
        PlayerPrefs.SetFloat("save_x", -1.5f);
        //PlayAnimation(str);

        StartCoroutine(coRoutine(str));

    }
    public void Trans(object trans)
    {
        tran = (Vector3)trans;
        tr = true;
    }
    public void stop(bool yes)
    {
        no = yes;
    }
    IEnumerator coRoutine(string str)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(str);
    }
    IEnumerator end()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(str);
    }
}
