using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour {

    float height = 0;
    float width = 0;
    public GameObject ball, bottomWall, grass, master, juggle, button;
    bool isatMenu= true;

    public AudioClip whoosh;
    public AudioClip[] ballSounds;
    Animator masterAnimator, juggleAnimator, buttonAnimator;

    public List<GameObject> ballList;

    // Use this for initialization
    void Start () {

        float[] d = new float[2];
        d = Util.getScreenDimentions();
        height = d[0];
        width = d[1];

        StartCoroutine("SpawnBalls");


        bottomWall.transform.localScale = new Vector3(width, 0.5F, 0);
        bottomWall.transform.position = new Vector3(0, (-height / 2) -5, 0);

        grass.transform.position = new Vector3(0, (-height / 2) + 0.75f, -2);
        DontDestroyOnLoad(grass);

        masterAnimator = master.GetComponent<Animator>();
        juggleAnimator = juggle.GetComponent<Animator>();
        buttonAnimator = button.GetComponent<Animator>();

        CloudMangager cm = GetComponent<CloudMangager>();
        cm.SpawnFirstCloud();

    }

    void Update() {
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}

    IEnumerator SpawnBalls()
    {
        while (isatMenu)
        {
            yield return new WaitForSeconds(2);
            if (isatMenu)
            {
                float x = Random.Range(-width / 2, width / 2);
                GameObject b = Instantiate(ball, new Vector3(x, (-height / 2) - 1, 0), Quaternion.Euler(0, 0, 0));
                ballList.Add(b);
                int a = Random.Range(0, 5);
                AudioSource.PlayClipAtPoint(ballSounds[a], Vector3.zero);
            }
        }
    }

    public void StartGame()
    {
        StartCoroutine("startGame");
    }

    private IEnumerator startGame()
    {
        Destroy(bottomWall);
        isatMenu = false;

        AudioSource.PlayClipAtPoint(whoosh, Vector3.zero);
        masterAnimator.SetFloat("Speed", -1);
        juggleAnimator.SetFloat("Speed", -1);
        buttonAnimator.SetFloat("FlySpeed", 1);

        foreach(GameObject g in ballList)
        {
            BallStartControl b = g.GetComponent<BallStartControl>();
            b.dieAnimation();

        }

        yield return new WaitForSeconds(2);
        Debug.Log("Starting Game");
        SceneManager.LoadScene("Game");
    }


    
}
