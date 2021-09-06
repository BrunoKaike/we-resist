using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    //private SpriteRenderer sr;
    //private CircleCollider2D cc;

    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        //cc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            StartCollectEffect();

            GameController.instance.TotalScore += Score;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f);
 
        }
    }

    
    private void StartCollectEffect()
    {
        StartCoroutine("CollectEffect");
    }

    private IEnumerator CollectEffect()
    {
        float time = 0;

        while(time < 1)
        {
            time += Time.deltaTime/2.0f;
            Vector3 target = new Vector3(0, 0, 0);
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, target, time);
            
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

   
}
