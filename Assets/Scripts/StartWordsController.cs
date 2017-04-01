using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWordsController : MonoBehaviour {

    Vector3 target;

	// Use this for initialization
	void Start () {

        target = new Vector3(0, transform.position.y, transform.position.z);

        if (gameObject.name == "Juggle")
        {
            AnimateText(1);
        }

        if (gameObject.name == "Master")
        {
            AnimateText(-1);
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    }

    void AnimateText(int a)
    {
        while (transform.position.x != 0)
        {
            //transform.position = Vector3.MoveTowards(transform.position,target , 0.1f);
        }
    }
}
