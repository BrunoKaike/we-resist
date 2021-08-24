using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float StartPosition;
    private float Length;

    public GameObject Camera;
    public float ParallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    void FixedUpdate()
    {
        float Temp = (Camera.transform.position.x * (1 - ParallaxEffect));
        float Dist = (Camera.transform.position.x * ParallaxEffect);

        transform.position = new Vector3(StartPosition + Dist, transform.position.y, transform.position.z);

        if(Temp > StartPosition + Length)
            StartPosition += Length;
        else if(Temp < StartPosition - Length)
            StartPosition -= Length;
    }
}
