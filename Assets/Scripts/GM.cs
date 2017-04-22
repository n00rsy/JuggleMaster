using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public GameObject bottomWall, rightWall, leftWall, ball,menu;

    public float height = 0;
    public float width = 0;

    public Text scoreText;
    public Text finalScoreText;
    public Text highScoreText;
    public Text newBall;

    public int score = 0;
    public int numberofBalls = 0;

    public AudioClip[] ballSounds;
    public AudioClip startSound, whoosh,endSound;
    

    public bool isPlaying;

    public List<GameObject> ballList;

    Vector3 spawnPoint;

    Animator menuAnimator;

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

        menuAnimator = menu.GetComponent<Animator>();

        isPlaying = true;
        //StartCoroutine("SpawnBallText");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");

        }

    }

    public void SetScore()
    {
        Debug.Log("Setting Score...");
        scoreText.text = score.ToString();
        if(score == 30)
        {
            //SpawnBall();
            StartCoroutine("SpawnBallText");

        }
    }

    public void PlayRandomSound()
    {
        int a = Random.Range(0, 5);
        AudioSource.PlayClipAtPoint(ballSounds[a], Vector3.zero);
    }

IEnumerator SpawnBallText()
    {
        string a = "NEW BALL IN ";
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Flashing Text "+i);
            newBall.text = a + (3-i);
            newBall.color = new Color(1, 1, 1, 1);//white
            yield return new WaitForSeconds(1);
            newBall.color = new Color(0, 0, 0, 0);//transparent
        }
        newBall.color = new Color(0, 0, 0, 0);//transparent
        SpawnBall();
    }

    public void SpawnBall()
    {
        Debug.Log("Spawning new Ball");
        GameObject b = Instantiate(ball, spawnPoint, Quaternion.Euler(0, 0, 0));
        AudioSource.PlayClipAtPoint(startSound, Vector3.zero);
        b.name = "Ball" + numberofBalls;
        ballList.Add(b);
        numberofBalls++;
        if (numberofBalls ==2)
        {
            
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");
            Physics2D.IgnoreCollision(balls[0].GetComponent<Collider2D>(), balls[1].GetComponent<Collider2D>());
            
            //Physics2D.IgnoreCollision(b1.GetComponent<Collider2D>(), b2.GetComponent<Collider2D>());
        }
    }

    public void EndGame()
    {
        if (isPlaying)
        {
            finalScoreText.text = ("SCORE: " + score);

            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            highScoreText.text = ("HIGHSCORE: " + PlayerPrefs.GetInt("HighScore"));

            Debug.Log("Playing end game sound");
            AudioSource.PlayClipAtPoint(endSound, Vector3.zero);
            AudioSource.PlayClipAtPoint(whoosh, Vector3.zero);
            menuAnimator.SetFloat("FlySpeed", 1);
        }
        isPlaying = false;
    }

    public void RestartGame()
    {
       
        StartCoroutine("Restart");
        
    }
    IEnumerator Restart()
    {
        menuAnimator.SetFloat("FlySpeed", -1);
        AudioSource.PlayClipAtPoint(whoosh, Vector3.zero);
        foreach (GameObject g in ballList)
        {
            BallControl b = g.GetComponent<BallControl>();
            if (b != null)
            {
                b.dieAnimation();
            }

        }

        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("Game");
    }
}
