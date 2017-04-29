using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Initiate.Fade("Start", Color.white, 0.7f);
        }
    }

    public void goToGithub()
    {
        Debug.Log("Github button pressed, attempting to open github in browser.");
        Application.OpenURL("https://github.com/n00rsy/JuggleMaster");
    }
}
