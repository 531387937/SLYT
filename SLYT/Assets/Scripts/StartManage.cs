using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartManage : MonoBehaviour {
    private AsyncOperation mAsyncOperation;
    public Transform tr;
    public bool begin=false;
   public GameObject ga;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)&&!begin)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //camare2D.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                this.GetComponent<AudioSource>().Play();
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
                ga = hit.collider.gameObject;
                StartCoroutine(scenload(hit.collider.gameObject.GetComponent<LoadScenes>().Which_Scene));
                
            }
        }
        if(begin)
        {
            ga.transform.position = Vector3.MoveTowards(ga.transform.position, tr.position, 5*Time.deltaTime);
        }
        if(ga.transform.position==tr.position&&begin)
        {
            mAsyncOperation.allowSceneActivation = true;
        }
    }
    IEnumerator scenload(int x)
    {      
        mAsyncOperation=SceneManager.LoadSceneAsync(x);
        mAsyncOperation.allowSceneActivation = false;
        
        yield return new WaitForSeconds(0.5f);
        begin = true;
        yield return mAsyncOperation;
    }
}
