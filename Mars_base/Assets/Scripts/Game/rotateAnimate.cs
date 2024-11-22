using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAnimate : MonoBehaviour
{

    int rotationSpeed = 120;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    void Update()
    {

        // Rotation on y axis
        // be sure to capitalize Rotate or you'll get errors
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
