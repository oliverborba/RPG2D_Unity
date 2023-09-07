using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{

    [SerializeField] private int percentage; //porcetangem de chance de percar peixe a cada tentativa
    [SerializeField] private GameObject fishPrefab;


    private PlayerItems player;
    private PlayerAnim playerAnim;

    private bool detectingPlayer;


    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerItems>();
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }
    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);
        if(randomValue <= percentage) 
        {
            Instantiate(fishPrefab, player.transform.position + new Vector3(Random.Range(-2.5f, -1f), 0f, 0f), Quaternion.identity);
            //conseguiu pescar um peixe
            Debug.Log("pescou!");
        }
        else
        {
            //falhou
            Debug.Log("Não pescou!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
