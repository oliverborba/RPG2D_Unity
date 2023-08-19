using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [SerializeField] private int digAmount;
    private int initialDigAmaunt;

    private void Start()
    {
        initialDigAmaunt = digAmount;
    }

    public void OnHit()
    {

        digAmount--;

        if(digAmount <= initialDigAmaunt / 2)
        {
            spriteRenderer.sprite = hole;
        }

        //if (digAmount <= 0)
        //{
        //    //Plantar cenoura
        //    spriteRenderer.sprite = carrot;

        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            //Debug.Log("bateu");
            OnHit();
        }
    }
}
