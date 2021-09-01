using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEx : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool isDoubleJump;

    private Rigidbody2D rigid;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //pega o componente rigidbody2d do objeto que possui este script anexado
        rigid = GetComponent<Rigidbody2D>();
        //same as above
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move() {
        //eixo x = input, apenas o eixo x pois so queremos nos mover p frente e para tras
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //pega o valor do input 'horizontal': -1, 0 ou 1
        //multiplica pela velocidade
        transform.position += movement * Time.deltaTime * Speed;

        //nao esta apertando botao de andar
        if(Input.GetAxis("Horizontal") == 0f)
            animator.SetBool("run", false); //entao animacao run eh false 
        
        //esta apertando botao de andar para direita
        if(Input.GetAxis("Horizontal") > 0f){
            animator.SetBool("run", true); //entao animacao run eh true
            transform.eulerAngles = new Vector3(0f, 0f, 0f); //deixar objeto nao rotacionado (olhando p direita)
        }

        //esta apertando botao de andar para direita
        if(Input.GetAxis("Horizontal") < 0f){
            animator.SetBool("run", true); //entao animacao run eh true
            transform.eulerAngles = new Vector3(0f, 180f, 0f); //rotacionar objeto 180o (olhando p esquerda)
        }
    }

    void Jump() {
        if(Input.GetButtonDown("Jump")) {            
            if(isJumping) {
                if(isDoubleJump) {
                    //funcao pronta que da o impulso do pulo 
                    rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    isDoubleJump = false;
                    animator.SetBool("doublejump", true);               
                }
            } else {
                //funcao pronta que da o impulso do pulo 
                rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                isDoubleJump = true;
                animator.SetBool("jump", true);
            }
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
