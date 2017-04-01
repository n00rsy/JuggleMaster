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
    bool isatMenu= true;

    Animator a;

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

        grass.transform.position = new Vector3(0, (-height / 2) + 0.75f, 0);
        DontDestroyOnLoad(grass);
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
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Color col = new Color(0.5f, 0.7f, 0.8f,1);
        //col = Color.cyan;
        Debug.Log(col.ToString());
        Initiate.Fade("Game", col, 2);
    }

    public void OnDestroy()
    {
        Debug.Log("START MANAGER DESTROYED");
    }
}
