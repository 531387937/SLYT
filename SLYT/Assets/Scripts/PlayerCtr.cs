using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCtr : MonoBehaviour {
    private Rigidbody rig;
    public float movespeed;
    public float jump_velociy;
    private Vector3 point;
    private bool isground;
    public AudioSource A;

    // Use this for initialization
    void Start()
    {
        // Horizontal Vertical
        rig = GetComponent<Rigidbody>();
        transform.position = new Vector3(PlayerPrefs.GetFloat("save_x"), PlayerPrefs.GetFloat("save_y"), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rig.velocity.x) > movespeed)
        {
            if (rig.velocity.x > 0)
            {
                rig.velocity = new Vector3(movespeed, rig.velocity.y, 0);
            }
            else
            {
                rig.velocity = new Vector3(-movespeed, rig.velocity.y, 0);
            }

        }
       
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * movespeed * Time.deltaTime);
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && isground)
        {
            //A.Play();
            rig.velocity = new Vector3(rig.velocity.x, jump_velociy, 0);

        }
        if (isground && Input.GetAxis("Horizontal") == 0)
        {
            rig.velocity = new Vector3(0, rig.velocity.y, 0);
        }
    }
    private void FixedUpdate()
    {
         point = transform.position - transform.up * 0.5f;
        Collider[] outputCols = Physics.OverlapSphere(point, 0.05f, LayerMask.GetMask("ground"));

        if (outputCols.Length != 0)
        {
            isground = true;
        }
        else
        {
            isground = false;

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
