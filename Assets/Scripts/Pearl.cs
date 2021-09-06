using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D cc;

    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            cc.enabled = false;

            GameController.instance.TotalScore += Score;
            GameController.instance.UpdateScore();

            Destroy(gameObject, 0.25f);
        }                
    }

   
}
