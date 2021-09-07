using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    private Player player;
    //private Menu menu;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Recriar o personagem
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        Debug.Log("Respawn Player");

        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        float gravity = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        yield return new WaitForSeconds(1.0f);
        
        player.transform.position = currentCheckpoint.transform.position;
        player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = gravity;
        Instantiate(respawnParticle, player.transform.position, player.transform.rotation);
    }

    //Game over - dont work
    public void GameOver()
    {
        GameController.instance.Life = 3;
        GameController.instance.TotalScore = 0;
        //reiniciar
        //menu.GameOver();
    }
}
