using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{
    private Rigidbody2D caixa;
    void Start()
    {

        caixa = GetComponent<Rigidbody2D>();
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.C))
        {
            caixa.mass = 1;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || !Input.GetKey(KeyCode.C))
        {
            caixa.mass = 1000;
        }
    }
}
