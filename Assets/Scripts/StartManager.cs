using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour {

    float height = 0;
    float width = 0;
    public GameObject ball;
    public GameObject bottomWall;
    bool isatMenu= true;

    // Use this for initialization
    void Start () {

        float[] d = new float[2];
        d = Util.getScreenDimentions();
        height = d[0];
        width = d[1];

        StartCoroutine("SpawnBalls");

        BoxCollider2D bottom = (BoxCollider2D)bottomWall.gameObject.AddComponent(typeof(BoxCollider2D));
        bottomWall.transform.localScale = new Vector3(width, 0.5F, 0);
        bottomWall.transform.position = new Vector3(0, (-height / 2) -5, 0);


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnBalls()
    {
        while (isatMenu)
        {
            yield return new WaitForSeconds(2);
            float x = Random.Range(-width / 2, width / 2);
            Instantiate(ball, new Vector3(x, (-height / 2) - 1, 0), Quaternion.EulerAngles(0, 0, 0));
        }
    }

    public void StartGame()
    {
        Debug.Log("Starting Game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
