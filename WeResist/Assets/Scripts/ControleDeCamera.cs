using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeCamera : MonoBehaviour
{
    public Transform target;
    public int altura;
    public float smoothspeed = 1f;
    void Start()
    {
       
    }

    void Update()
    {
        Vector3 startposition = new Vector3(target.position.x,target.position.y + altura ,-10);
        Vector3 smoothposition = Vector3.Lerp(transform.position, startposition, smoothspeed);
        transform.position = smoothposition;
    }
}
