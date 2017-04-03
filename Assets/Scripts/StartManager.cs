using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour {

    float height = 0;
    float width = 0;
    public GameObject ball;
    public GameObject bottomWall;
    public GameObject grass;
    public GameObject master;
    public GameObject juggle;
    public GameObject button;
    bool isatMenu= true;

    Animator masterAnimator, juggleAnimator, buttonAnimator;

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

        grass.transform.position = new Vector3(0, (-height / 2) + 0.75f, -2);
        DontDestroyOnLoad(grass);

        //a = master.GetComponent<Animator>();
        //int moveHash = Animator.StringToHash("JuggleMove");
        //a.Play(moveHash);
        masterAnimator = master.GetComponent<Animator>();
        juggleAnimator = juggle.GetComponent<Animator>();
        buttonAnimator = button.GetComponent<Animator>();
        //buttonAnimator.SetFloat("FlySpeed", 1);
        //buttonAnimator.SetFloat("FlySpeed", 0);
        //buttonAnimator.SetTrigger("FlyIn");

        //a.Play();

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
        StartCoroutine("startGame");
    }

    private IEnumerator startGame()
    {
        Destroy(bottomWall);
        isatMenu = false;

        masterAnimator.SetFloat("Speed", -1);
        juggleAnimator.SetFloat("Speed", -1);
        buttonAnimator.SetFloat("FlySpeed", 1);

        yield return new WaitForSeconds(4);
        Debug.Log("Starting Game");
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Color col = new Color(0.5f, 0.7f, 0.8f, 1);
        //col = Color.cyan;
        Debug.Log(col.ToString());
        //Initiate.Fade("Game", col, 2);
        SceneManager.LoadScene("Game");
    }

    public void OnDestroy()
    {
        //int moveHash = Animator.StringToHash("JuggleMove");
        Debug.Log("START MANAGER DESTROYED");
        //a.Play(moveHash);
        //a.Rebind();
    }
}
