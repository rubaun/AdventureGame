using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionaPersonagem : MonoBehaviour
{
    public GameObject Mask;
    private SpriteRenderer maskSprite;
    private Rigidbody2D maskRb;
    private CapsuleCollider2D maskCollider;
    public GameObject FrogNinja;
    private SpriteRenderer frogSprite;
    private Rigidbody2D frogRb;
    private CapsuleCollider2D frogCollider;
    public GameObject Pink;
    private SpriteRenderer pinkSprite;
    private Rigidbody2D pinkRb;
    private CapsuleCollider2D pinkCollider;
    public GameObject VirtualGuy;
    private SpriteRenderer virtualSprite;
    private Rigidbody2D virtualRb;
    private CapsuleCollider2D virtualCollider;

    void Start() 
    {
        maskSprite = Mask.GetComponent<SpriteRenderer>();
        frogSprite = FrogNinja.GetComponent<SpriteRenderer>();
        pinkSprite = Pink.GetComponent<SpriteRenderer>();
        virtualSprite = VirtualGuy.GetComponent<SpriteRenderer>();
        maskRb = Mask.GetComponent<Rigidbody2D>();
        frogRb = FrogNinja.GetComponent<Rigidbody2D>();
        pinkRb = Pink.GetComponent<Rigidbody2D>();
        virtualRb = VirtualGuy.GetComponent<Rigidbody2D>();
        maskCollider = Mask.GetComponent<CapsuleCollider2D>();
        frogCollider = FrogNinja.GetComponent<CapsuleCollider2D>();
        pinkCollider = Pink.GetComponent<CapsuleCollider2D>();
        virtualCollider = VirtualGuy.GetComponent<CapsuleCollider2D>();
    }

    public void SelecionaMouseOver(string nome)
    {
        if(nome == "Mask")
        {
            maskSprite.color = Color.white;
            frogSprite.color = Color.grey;
            pinkSprite.color = Color.grey;
            virtualSprite.color = Color.grey;
        }

        if(nome == "FrogNinja")
        {
            frogSprite.color = Color.white;
            maskSprite.color = Color.grey;
            pinkSprite.color = Color.grey;
            virtualSprite.color = Color.grey;
        }

        if(nome == "Pink")
        {
            pinkSprite.color = Color.white;
            frogSprite.color = Color.grey;
            maskSprite.color = Color.grey;
            virtualSprite.color = Color.grey;
        }

        if(nome == "Virtual")
        {
            virtualSprite.color = Color.white;
            frogSprite.color = Color.grey;
            pinkSprite.color = Color.grey;
            maskSprite.color = Color.grey;
        }
    }

    public void SelecionaMouseDown(string nome)
    {
        if(nome == "Mask")
        {
            frogRb.simulated = false;
            pinkRb.simulated = false;
            virtualRb.simulated = false;
            frogCollider.enabled = false;
            pinkCollider.enabled = false;
            virtualCollider.enabled = false;
        }

        if(nome == "FrogNinja")
        {
            maskRb.simulated = false;
            pinkRb.simulated = false;
            virtualRb.simulated = false;
            maskCollider.enabled = false;
            pinkCollider.enabled = false;
            virtualCollider.enabled = false;
        }

        if(nome == "Pink")
        {
            frogRb.simulated = false;
            maskRb.simulated = false;
            virtualRb.simulated = false;
            frogCollider.enabled = false;
            maskCollider.enabled = false;
            virtualCollider.enabled = false;
        }

        if(nome == "Virtual")
        {
            frogRb.simulated = false;
            pinkRb.simulated = false;
            maskRb.simulated = false;
            frogCollider.enabled = false;
            pinkCollider.enabled = false;
            maskCollider.enabled = false;
        }
    }

    public void SelecionaMouseExit()
    {
        maskSprite.color = Color.white;
        frogSprite.color = Color.white;
        pinkSprite.color = Color.white;
        virtualSprite.color = Color.white;
    }
}
