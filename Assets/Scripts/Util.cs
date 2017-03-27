using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util  {
   
    public static float[] getScreenDimentions()
    {
        float height;
        float width;
        
        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height;
        Debug.Log("height  " + height);
        Debug.Log("width  " + width);

        float[] r = new float [2];
        r[0] = height;
        r[1] = width;
        return r;
    }
}
