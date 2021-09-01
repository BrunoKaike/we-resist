using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D cc;

    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
        collected.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            cc.enabled = false;
            collected.SetActive(true);

            GameControllerEx.instance.TotalScore += Score;
            GameControllerEx.instance.UpdateScore();

            Destroy(gameObject, 0.25f);
        }                
    }
}
