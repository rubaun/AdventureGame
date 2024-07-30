using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerSeleciona : MonoBehaviour
{
    public int velocidade;
    private Animator anim;
    private SpriteRenderer sprite;
    public string tipo;
    public bool seleciona = false;
    public SelecionaPersonagem select;
    public TextMeshProUGUI nomePerso;
    
    
    void Start()
    {
        select = GameObject.Find("Seleciona Personagem").GetComponent<SelecionaPersonagem>();
        nomePerso = GameObject.Find("Nome").GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        tipo = gameObject.name;
        nomePerso.text = "";
    }

    void Update()
    {
        if(seleciona)
        {
            nomePerso.text = tipo;
            transform.position += new Vector3(1 * velocidade * Time.deltaTime, 0, 0);
            sprite.flipX = false;
            anim.SetLayerWeight(1,1);
            anim.SetLayerWeight(6,0);
        }
        else
        {
            anim.SetLayerWeight(1,0);
        }
    }

    private void OnMouseOver() 
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 0);
        select.SelecionaMouseOver(tipo);
        nomePerso.text = tipo;
    }

    private void OnMouseExit() 
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 0);
        select.SelecionaMouseExit();
        nomePerso.text = "";
    }

    private void OnMouseDown() 
    {
        seleciona = true;
        select.SelecionaMouseDown(tipo);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("SaidaPersonagem"))
        {
            SceneManager.LoadScene("Fase1");
        }
    }

}
