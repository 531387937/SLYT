using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartManage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //camare2D.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameManage.i = 0;
                //switch(hit.collider.gameObject.GetComponent<LoadScenes>().Which_Scene)
                //{
                //    case 1:
                //        {
                //            PlayerPrefs.SetFloat("save_x", 2);
                //            PlayerPrefs.SetFloat("save_y", 3);
                //        }
                //        break;
                //    case 2:
                //        {
                //            PlayerPrefs.SetFloat("save_x", -78);
                //            PlayerPrefs.SetFloat("save_y", 2);
                //        }
                //        break;
                //    case 3:
                //        {
                //            PlayerPrefs.SetFloat("save_x", -104);
                //            PlayerPrefs.SetFloat("save_y", 3);
                //        }
                //        break;
                //    case 4:
                //        {
                //            PlayerPrefs.SetFloat("save_x", 2);
                //            PlayerPrefs.SetFloat("save_y", 3);
                //        }
                //        break;
                //    case 5:
                //        {
                //            PlayerPrefs.SetFloat("save_x", 2);
                //            PlayerPrefs.SetFloat("save_y", 3);
                //        }
                //        break;
                //    case 6:
                //        {
                //            PlayerPrefs.SetFloat("save_x", 2);
                //            PlayerPrefs.SetFloat("save_y", 3);
                //        }
                //        break;
                //}
                SceneManager.LoadScene(hit.collider.gameObject.GetComponent<LoadScenes>().Which_Scene);
            }
        }

    }
}
