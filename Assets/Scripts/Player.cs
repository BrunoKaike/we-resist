using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed;
    public float jumpforce;

    private bool isJumping;
    private bool isDoubleJump;

    private Rigidbody2D Rigi;
    private Animator animator;
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
        animator = GetComponent<Animator>();

        isJumping = false;
        isDoubleJump = false;
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
        
        //nao esta apertando botao de andar
        if(Input.GetAxis("Horizontal") == 0f)
            animator.SetBool("run", false); //entao animacao run eh false 
        
        //esta apertando botao de andar para direita
        if(Input.GetAxis("Horizontal") > 0f) {
            animator.SetBool("run", true); //entao animacao run eh true
            transform.eulerAngles = new Vector3(0f, 0f, 0f); //deixar objeto nao rotacionado (olhando p direita)
        }

        //esta apertando botao de andar para direita
        if(Input.GetAxis("Horizontal") < 0f){
            animator.SetBool("run", true); //entao animacao run eh true
            transform.eulerAngles = new Vector3(0f, 180f, 0f); //rotacionar objeto 180o (olhando p esquerda)
        }
    }

    void jump()
    {
        if(Input.GetButtonDown("Jump")) {            
            if(isJumping) {
                if(isDoubleJump) {
                    //funcao pronta que da o impulso do pulo 
                    Rigi.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
                    isDoubleJump = false;
                    animator.SetBool("doublejump", true);               
                }
            } else {
                //funcao pronta que da o impulso do pulo
                Rigi.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
                isDoubleJump = true;
                animator.SetBool("jump", true);
            }
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

        // ----- metodos padroes da unit reescritos
    //detecta se gameObject (player) tocou em algo (necessario RigidBody e Colisores)
    void OnCollisionEnter2D(Collision2D collision)
    {
        //8 eh o nosso layer 'Ground' do objeto Ground
        if(collision.gameObject.layer == 8) {
            isJumping = false;
            animator.SetBool("jump", false);
            animator.SetBool("doublejump", false);
        }

    }

    //detecta se gameObject (player) para de tocar algo (necessario RigidBody e Colisores)
    void OnCollisionExit2D(Collision2D collision)
    {
        //8 eh o nosso layer 'Ground' do objeto Ground
        if(collision.gameObject.layer == 8) {
            isJumping = true;
        }
    }

}
