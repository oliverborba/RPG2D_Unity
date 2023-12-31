using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }
    public idiom language;


    [Header("Components")]
    public GameObject dialogueObj; // Janela do dialogo
    public Image profileSprite; // sprite do perfil
    public Text speechText; // texto da fala
    public Text actorNameText; // nome do npc

    [Header("Settings")]
    public float typingSpeed; // velocidade da fala

    //Variáveis de controle
    private bool isShowing; // se a janela está visível
    private int index; // index das sentenças
    private string[] sentences;
    private string[] currentActorName;
    private Sprite[] actorSprite;


    private Player player;

    public static DialogueControl instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    // awake é chamado antes de todos os Start() na hierarquia de execução de scripts
    private void Awake()
    {
        instance = this;
    }

    //é chamado ao inicializar
    void Start()
    {
            player = FindObjectOfType<Player>();
    }

    void Update()
    {
                
    }
    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //Pular para próxima frase/fala
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length -1)
            {
                index++;
                profileSprite.sprite = actorSprite[index];
                actorNameText.text = currentActorName[index];
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //Quando terminam os textos
            {
                speechText.text = "";
                actorNameText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                IsShowing = false;

                player.isPaused = false;

            }
        }
    }

    //chamar fala do npc
    public void Speech(string[] txt, string[] actorName, Sprite[] actorProfile) 
    {
        if (!IsShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            currentActorName = actorName;
            actorSprite = actorProfile;
            profileSprite.sprite = actorSprite[index];
            actorNameText.text = currentActorName[index];
            StartCoroutine(TypeSentence());
            IsShowing = true;

            player.isPaused = true;
        }
    }
}
