using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{

    [Header("Amounts")]
    [SerializeField] private int totalWood;
    [SerializeField] private int carrots;
    [SerializeField] private float currentWater;
    [SerializeField] private int fishes;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    public int Carrots { get => carrots; set => carrots = value; }
    public float CurrentWater { get => currentWater; set => currentWater = value; }


    [Header("Limits")]
    [SerializeField] private float woodLimit = 5f;
    [SerializeField] private float carrotLimit = 10f;
    [SerializeField]private float waterLimit = 50f;
    [SerializeField] private float fishesLimit = 3f;      

    public float WaterLimit1 { get => waterLimit; set => waterLimit = value; }
    public float CarrotLimit { get => carrotLimit; set => carrotLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }
    public int Fishes { get => fishes; set => fishes = value; }
    public float FishesLimit { get => fishesLimit; set => fishesLimit = value; }

    public void WaterLimit(float water)
    {
        if(currentWater < WaterLimit1)
        {
            currentWater += water;
        }
    }
}
