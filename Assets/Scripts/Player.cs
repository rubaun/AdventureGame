using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveH;
    public int velocidade;
    public int forcaPulo;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public bool isJumping = false;
    public bool animDoubleJump = false;
    public bool hitPlayer = false;
    public int doubleJumping = 0;
    public int vida = 100;
    public int vidas = 3;
    public bool comVida = true;
    public string tipo;
    public Vector3 startPosition;
    private bool start;
    
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        start = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        tipo = gameObject.name;
    }

    private void FixedUpdate() 
    {
        //Andar
        moveH = Input.GetAxis("Horizontal"); // -1 a 1
        
        transform.position += new Vector3(moveH * velocidade * Time.deltaTime, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Fase1" && start)
        {
            startPosition = GameObject.FindWithTag("Start").transform.position;
            transform.position = startPosition;
            start = false;
        }
        //Animação Andar
        if(Input.GetKey(KeyCode.D) && moveH > 0)
        {
            sprite.flipX = false;
            anim.SetLayerWeight(1,1);
            anim.SetLayerWeight(6,0);
        }
        
        if(Input.GetKey(KeyCode.A) && moveH < 0)
        {
            sprite.flipX = true;
            anim.SetLayerWeight(1,1);
            anim.SetLayerWeight(6,0);
        }
        
        if(moveH == 0)
        {
            anim.SetLayerWeight(1,0);
        }
        
        //Pular
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(transform.up * forcaPulo,ForceMode2D.Impulse);
            isJumping = true;
            doubleJumping++;
            anim.SetLayerWeight(2,1);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && isJumping)
        {
            doubleJumping++;
        }
        
        //Pulo Duplo
        if(Input.GetKeyDown(KeyCode.Space) && isJumping && doubleJumping == 2)
        {
            rb.AddForce(transform.up * forcaPulo,ForceMode2D.Impulse);
            animDoubleJump = true;
            anim.SetLayerWeight(2,0);
        }

        //Animação Pulo duplo
        if(rb.velocity.y > 0 && animDoubleJump)
        {
            anim.SetLayerWeight(3,1);
        } 

        //Animação Descida
        if(rb.velocity.y < -2)
        {
            anim.SetLayerWeight(4,1);
            anim.SetLayerWeight(2,0);
            anim.SetLayerWeight(3,0);
        }

        //Reset Animação
        if(rb.velocity.y == 0)
        {
            anim.SetLayerWeight(4,0);
        }  

        if(hitPlayer)
        {
            anim.SetLayerWeight(6,1);
            LevaDano(10);
            hitPlayer = false;
        }   
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Chão"))
        {
            isJumping = false;
            doubleJumping = 0;
            animDoubleJump = false;
            anim.SetLayerWeight(2,0);
            anim.SetLayerWeight(4,0);
            anim.SetLayerWeight(1,0);
            anim.SetLayerWeight(3,0);
            anim.SetLayerWeight(5,0);
            anim.SetLayerWeight(6,0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Spike"))
        {
            hitPlayer = true;
        }

        if(other.gameObject.CompareTag("Melão"))
        {
            vida += 10;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Morte"))
        {
            Destroy(this.gameObject);
            PerdeVida();
        }
    }

    private void LevaDano(int dano)
    {
        vida -= dano;
        if(vida <= 0)
        {
            PerdeVida();
        }
    }

    private void PerdeVida()
    {
        if(vidas > 0)
        {
            vidas--;
            vida = 100;
        }
        else if(vidas <= 0)
        {
            comVida = false;
        }
    }

    private void OnMouseOver() 
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 0);
    }

    private void OnMouseExit() 
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 0);
    }

    private void OnMouseDown() 
    {
        
    }

    public bool VerificaSePlayerVivo()
    {
        return comVida;
    }

    public int VidasDoPlayer()
    {
        return vidas;
    }

    public void AtualizaVidas(int vidas)
    {
        this.vidas = vidas;
    }
}
