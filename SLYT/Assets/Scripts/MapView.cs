using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour {
    [SerializeField]
    private bool view;
    private bool view1;
    private float ViewField;
    public Camera cam;
    public GameObject player;
    public float ScaleSpeed;
    // Use this for initialization
    private void Awake()
    {
        view = false;
        view1 = false;
    }
    void Start () {
        ViewField = cam.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Joystick1Button9)&&!view)
        {
            print("ea");
                
                cam.gameObject.GetComponent<CameraCtr>().enabled = false;
                player.GetComponent<PlayerCtr>().enabled = false;
                player.GetComponent<PlayerSkill>().enabled = false;
            view1 = true;
          
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button9) && view)
        {
            
            cam.gameObject.GetComponent<CameraCtr>().enabled = true;
            player.GetComponent<PlayerCtr>().enabled = true;
            player.GetComponent<PlayerSkill>().enabled = true;
            view1 = false;
        }
        view = view1;
        if(view)
        {
            if(Input.GetKey(KeyCode.Joystick1Button4))
            {
                cam.fieldOfView += ScaleSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Joystick1Button5))
            {
                cam.fieldOfView -= ScaleSpeed * Time.deltaTime;
            }
        }
        if(!view)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,ViewField,ScaleSpeed*Time.deltaTime);
        }
        if (cam.fieldOfView <= 40)
            cam.fieldOfView = 40;
        if (cam.fieldOfView >= 80)
            cam.fieldOfView = 80;
    }
}
