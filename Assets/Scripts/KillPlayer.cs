using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //override
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Personagem")
        {
            GameController.instance.Life--;
            if(GameController.instance.Life < 0)
            {
                //levelManager.GameOver(); dont work
                //game over improvisado
                GameController.instance.Life = 0;
                StartCoroutine(WaitBeforeGameOver());
            }
            GameController.instance.UpdateLifeText();
            levelManager.RespawnPlayer();
        }
    }

    private IEnumerator WaitBeforeGameOver() {
        yield return new WaitForSeconds(1);
        Debug.Log(">> GameOver!");
        SceneManager.LoadScene(2);
    }
}
