using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour {

    Rigidbody2D rb;
    int maxSpeed = 9;

    GM gm;
    public GameObject _gm;
    public GameObject b;

    public bool shrinking = false;
    float targetScale = 0;
    float shrinkSpeed = 8;

    void Start () {

        if (SceneManager.GetActiveScene().name == "Game")
        {
            Destroy(GetComponent<BallStartControl>());
        }

        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector2(5, 5));
        _gm = GameObject.Find("GameManager");
        b = GameObject.Find("bottomWall");
        if (SceneManager.GetActiveScene().name == "Game")
        {
            gm = _gm.GetComponent<GM>();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        //Debug.Log(rb.velocity);
        if (Input.touchCount > 0)
        {
            //Debug.Log("Touched at:  " + Input.GetTouch(0).position);

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                Vector3 pos = Camera.main.ScreenToWorldPoint(t.position);
                //Debug.Log("Touched at:  " + pos);

                if (t.phase == TouchPhase.Began&& gm.isPlaying) {

                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                    if (hit.collider.name == gameObject.name)
                    {
                        //Debug.Log("Raycast hit " + hit.collider.name);
                        if (hit.collider.name == gameObject.name)
                        {
                            float xForce = pos.x - transform.position.x;
                            xForce = -xForce * 20;
                            //Debug.Log("Force in X Direction:  " + xForce);
                            rb.AddForce(new Vector2(xForce, 28));
                            gm.score++;
                            gm.SetScore();
                            Debug.Log("Score: " + gm.score);
                            gm.PlayRandomSound();
                        }
                    }
                }
          }  
    }
        if (shrinking)
        {
            Debug.Log("shrinking ball");
            transform.localScale -= Vector3.one * Time.deltaTime * shrinkSpeed;
            if (transform.localScale.x < targetScale)
            {
                shrinking = false;
                Destroy(this.gameObject);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("BALL HIT SOMETHING");
        if (coll.gameObject == b)
        {
            gm.EndGame();
        }
        //gm.SpawnBall();
    }

    public void dieAnimation()
    {
        Debug.Log("Die Animation Started");
        shrinking = true;
    }
}
