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
    public int numberofBalls = 0;

    public AudioClip[] ballSounds;
    public AudioClip endSound;
    public AudioClip startSound;

    public bool isPlaying;

    Vector3 spawnPoint;

    // Use this for initialization
    void Start () {

        float[] d = new float[2];
        d= Util.getScreenDimentions();
        height = d[0];
        width = d[1];

        bottomWall = GameObject.Find("bottomWall");
        rightWall = GameObject.Find("rightWall");
        leftWall = GameObject.Find("leftWall");

       // BoxCollider2D bottom = (BoxCollider2D)bottomWall.gameObject.AddComponent(typeof(BoxCollider2D));
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

        spawnPoint = new Vector3(0,height/2+1,0);

        Debug.Log("SCREEN HEIGHT:  " +height);

        SetScore();
        SpawnBall();

        AudioSource.PlayClipAtPoint(startSound, Vector3.zero);

        isPlaying = true;
    }
	
	// Update is called once per frame
	void Update () {
     
	}

    public void SetScore()
    {
        Debug.Log("Setting Score...");
        scoreText.text = score.ToString();
        if(score == 30)
        {
            SpawnBall();

        }
    }

    public void PlayRandomSound()
    {
        int a = Random.Range(0, 4);
        AudioSource.PlayClipAtPoint(ballSounds[a], Vector3.zero);
    }

    public void SpawnBall()
    {
        Debug.Log("Spawning new Ball");
        GameObject b = Instantiate(ball, spawnPoint, Quaternion.EulerAngles(0, 0, 0));
        b.name = "Ball" + numberofBalls;
        numberofBalls++;
        if (numberofBalls ==2)
        {
            Debug.Log("fuck yes mother bitches");
            //GameObject b1 = GameObject.Find("Ball");
            //GameObject b2 = GameObject.Find("Ball(Clone)");
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");
            Physics2D.IgnoreCollision(balls[0].GetComponent<Collider2D>(), balls[1].GetComponent<Collider2D>());
            
            //Physics2D.IgnoreCollision(b1.GetComponent<Collider2D>(), b2.GetComponent<Collider2D>());
        }
    }

    public void EndGame()
    {
        if (!isPlaying)
        {
            AudioSource.PlayClipAtPoint(endSound, Vector3.zero);
        }
        isPlaying = false;
    }

}
