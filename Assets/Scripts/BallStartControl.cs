using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallStartControl : MonoBehaviour {

    
    float width, height;
    Rigidbody2D rb;

    void Start () {
        if (SceneManager.GetActiveScene().name=="Start")
        {
            Debug.Log("Destroying Ball Control Script");
            Destroy(GetComponent<BallControl>());
        }

        rb = GetComponent<Rigidbody2D>();
        int x = Random.Range(-2, 2);
        int y = Random.Range(20, 30);

        rb.AddForce(new Vector2(x, y));
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERED");
    }
}
