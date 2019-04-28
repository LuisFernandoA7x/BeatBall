using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //Componente a detectar automaticamente para el movimiento.
        anim = GetComponent<Animator>(); //Componente a detectar automaticamente para la animacion.
    }

    //Upate is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); //Valor absoluto, entre la distancia, valor positivo.
        anim.SetBool("Grounded", grounded); //Si esta tocando el suelo..

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            jump = true;
        }
    }

    /*Con el FixedUpdate ya no tendriamos que multiplicar la velocidad*/
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Movimiento horizontal
        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(Vector2.right * speed * moveHorizontal);

        /*Se regulan las velocidades para no sobrepasar la velocidad maxima*/
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        /*Se verifica el sentido en que va, para cambiar la animacion, hacia donde
         esta viendo la bola*/
        if (moveHorizontal > 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (moveHorizontal < -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        Debug.Log(rb2d.velocity.x);
    }
}
