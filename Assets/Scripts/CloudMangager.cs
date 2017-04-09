using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudMangager : MonoBehaviour {

    public GameObject[] clouds;
    public bool isPlaying = true;
    GM gm;
        
    // Use this for initialization
    void Start () {

        //Scene scene = SceneManager.GetActiveScene;
        if (SceneManager.GetActiveScene().name == "Game")
        {
            GameObject _gm = GameObject.Find("GameManager");
            gm = _gm.GetComponent<GM>();
            IEnumerator coroutine;
            coroutine = CloudSpawn(gm.height, gm.width);
            StartCoroutine(coroutine);
        }

        if(SceneManager.GetActiveScene().name == "Start")
        {
            float[] d = new float[2];
            d = Util.getScreenDimentions();
            //height = d[0];
            //width = d[1];

            IEnumerator coroutine;
            coroutine = CloudSpawn(d[0], d[1]);
            StartCoroutine(coroutine);
        }
        //SpawnFirstCloud();
        //StartCoroutine("CloudSpawn", gm.height, gm.width);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CloudSpawn(float x, float y)
    {
        float yRange1 = y *0.6f;
        float yRange2 = y *0.8f;
        Debug.Log("Y RANGE 1: " + yRange1 + " Y RANGE 2: " + yRange2);
        while (isPlaying)
        {
            Debug.Log("Spawning Cloud");
            float time = Random.Range(25, 35);
            int cloudNumber = Random.Range(0, 4);
            float yPos = Random.Range(-yRange1, yRange2);

            Instantiate(clouds[cloudNumber], new Vector3(-5f, yPos, 1), Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(time);
        }

    }

    public void SpawnFirstCloud()
    {
        Debug.Log("Spawning First Cloud");
        int cloudNumber = Random.Range(0, 4);
        float yPos = 0;

        Instantiate(clouds[cloudNumber], Vector3.zero, Quaternion.Euler(0, 0, 0));
    }
}
