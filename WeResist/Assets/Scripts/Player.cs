using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed;
    public float jumpforce;

    private Rigidbody2D Rigi;
    public GameController pause;

    //Para pausar o jogo
    [Header("Painel e Pause")]
    private bool isPaused;
    public GameObject pausepainel;
    public string cena;

    void Start()
    {
        Time.timeScale = 1f;
        Rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isPaused)
        {
            move();
            jump();
        }
        
            

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Painelpause();
        }
    }

    void move()
    {
        Vector3 Andar = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += Andar * Time.deltaTime * speed;
    }
    void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Rigi.AddForce(new Vector2(0f,jumpforce),ForceMode2D.Impulse);
        }
    }
    void Painelpause()
    {
        if (isPaused)
        {

            isPaused = false;
            Time.timeScale = 1f;
            pausepainel.SetActive(false);

        }
        else
        {

            isPaused = true;
            Time.timeScale = 0f;
            pausepainel.SetActive(true);

        }
    }

}
