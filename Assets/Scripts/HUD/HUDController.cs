using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image bucketUI;

    public List<Image> toolsUI = new List<Image>();

    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItems playerItens;
    private Player player;

    private void Awake()
    {
        playerItens = FindObjectOfType<PlayerItems>();
        player = playerItens.GetComponent<Player>();
    }


    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItens.CurrentWater / playerItens.WaterLimit1;
        woodUIBar.fillAmount = playerItens.TotalWood / playerItens.WoodLimit;
        carrotUIBar.fillAmount = playerItens.Carrots / playerItens.CarrotLimit;

        //toolsUI[player.HandlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.HandlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
