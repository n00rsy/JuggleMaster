using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallStartControl : MonoBehaviour {

    
    float width, height;
    Rigidbody2D rb;
    GameObject _sm;
    StartManager sm;

    float targetScale = 0;
    float shrinkSpeed = 8;

    bool shrinking = false;

    void Start () {
        if (SceneManager.GetActiveScene().name=="Start")
        {
            Debug.Log("Destroying Ball Control Script");
            Destroy(GetComponent<BallControl>());
        }

        rb = GetComponent<Rigidbody2D>();
        _sm = GameObject.Find("SM");
        sm = _sm.GetComponent<StartManager>();
        
        int x = Random.Range(-2, 2);
        int y = Random.Range(25, 35);

        rb.AddForce(new Vector2(x, y));
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -20)
        {
            sm.ballList.Remove(this.gameObject);
            Destroy(gameObject);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERED");
    }

    public void dieAnimation()
    {
        Debug.Log("Die Animation Started");
        shrinking = true;
    }
}

