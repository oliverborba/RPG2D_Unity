using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotSFX;

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount;
    [SerializeField] private float waterAmount;

    [SerializeField] private bool detecting;
    private bool isPlayer; //Verdadeiro quando player enconsta no item

    private int initialDigAmaunt;
    private float currentWater;

    private bool dugHole;
    private bool plantedCarrot;

    PlayerItems playerItems;


    private void Start()
    {
        playerItems = FindAnyObjectByType<PlayerItems>();
        initialDigAmaunt = digAmount;
    }

    private void Update()
    {
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }
            if (currentWater >= waterAmount && !plantedCarrot)
            {
                audioSource.PlayOneShot(holeSFX);
                spriteRenderer.sprite = carrot;

                plantedCarrot = true;                
            }
            if (Input.GetKeyDown(KeyCode.E) && plantedCarrot && isPlayer  )
            {
                audioSource.PlayOneShot(carrotSFX);
                spriteRenderer.sprite = hole;
                playerItems.Carrots++;
                currentWater = 0;
            }
        }       
    }

    public void OnHit()
    {

        digAmount--;

        if(digAmount <= initialDigAmaunt / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
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
        if (collision.CompareTag("Water"))
        {
            detecting = true;
        }
        if (collision.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            detecting = false;
        }
        if (collision.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}
