using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class newUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void Sound()
    {
       
    }
    public void exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }
}
