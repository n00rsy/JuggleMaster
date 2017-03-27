using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public GameObject bottomWall;
    public GameObject rightWall;
    public GameObject leftWall;
    public GameObject ball;
    public float height = 0;
    public float width = 0;

    public Text scoreText; 

    public int score = 0;

    public AudioClip[] ballSounds;

    // Use this for initialization
    void Start () {

        float[] d = new float[2];
        d= Util.getScreenDimentions();
        height = d[0];
        width = d[1];

        bottomWall = GameObject.Find("bottomWall");
        rightWall = GameObject.Find("rightWall");
        leftWall = GameObject.Find("leftWall");

        BoxCollider2D bottom = (BoxCollider2D)bottomWall.gameObject.AddComponent(typeof(BoxCollider2D));
        BoxCollider2D right = (BoxCollider2D)rightWall.gameObject.AddComponent(typeof(BoxCollider2D));
        BoxCollider2D left = (BoxCollider2D)leftWall.gameObject.AddComponent(typeof(BoxCollider2D));

        bottomWall.transform.localScale = new Vector3(width, 0.5F, 0);
        rightWall.transform.localScale = new Vector3(0.5F, height, 0);
        leftWall.transform.localScale = new Vector3(0.5F, height, 0);

        bottomWall.transform.position = new Vector3(0, (-height / 2) - 0.23F, 0);
        rightWall.transform.position = new Vector3((width / 2) + 0.23F, 0, 0);
        leftWall.transform.position = new Vector3((-width / 2) - 0.23F, 0, 0);

        rightWall.transform.localScale = new Vector3(0.5F, height*10, 0);
        leftWall.transform.localScale = new Vector3(0.5F, height * 10, 0);

        Instantiate(ball, new Vector3(0, 0, 0), Quaternion.EulerAngles(0, 0, 0));

        SetScore();


    }
	
	// Update is called once per frame
	void Update () {
     
	}

    public void SetScore()
    {
        Debug.Log("Setting Score...");
        scoreText.text = score.ToString();
    }

    public void PlayRandomSound()
    {
        int a = Random.Range(0, 4);
        AudioSource.PlayClipAtPoint(ballSounds[a], Vector3.zero);
    }

}
