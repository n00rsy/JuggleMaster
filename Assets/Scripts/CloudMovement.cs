using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    float speed;
    Vector3 speedv;

	void Start () {
        speed = Random.Range(0.004f, 0.01f);
        speed = speed / 2;
        speedv = new Vector3(speed, 0, 0);
        float scale = Random.Range(1f, 1.5f);
        transform.localScale = new Vector3(scale, scale, 0);
        
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speedv);
        if (transform.position.x > 5)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed Cloud");
        }
	}
}
