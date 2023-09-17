using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public bool isPaused;

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;
    private PlayerItems playerItens;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;


    private Vector2 _direction;

    private int handlingObj;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting { get => _isCutting; set => _isCutting = value; }

    public bool isDigging { get => _isDigging; set => _isDigging = value; }
    public bool isWatering { get => _isWatering; set => _isWatering = value; }
    public int HandlingObj { get => handlingObj; set => handlingObj = value; }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItens = GetComponent<PlayerItems>();
        initialSpeed = speed;
    }

    private void Update()
    {
        if (!isPaused)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                HandlingObj = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                HandlingObj = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                HandlingObj = 2;
            }

            OnInput();

            OnRun();

            OnRolling();

            OnCutting();

            OnDig();

            OnWatering();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Teste");
        }
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
    }
    #region Movement

    void OnCutting()
    {
        if(HandlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCutting = true;
                speed = 0f;

            }
            if (Input.GetMouseButtonUp(0))
            {
                isCutting = false;
                speed = initialSpeed;
            }
        }
        else
        {
            isCutting=false;
        }
    }
    
    void OnDig()
    {
        if(HandlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDigging = true;
                speed = 0f;

            }
            if (Input.GetMouseButtonUp(0))
            {
                isDigging = false;
                speed = initialSpeed;
            }
        }
        else
        {
            isDigging= false;
        }
    }

    void OnWatering()
    {
        if (HandlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItens.CurrentWater > 0)
            {
                isWatering = true;
                speed = 0f;

            }
            if (Input.GetMouseButtonUp(0) || playerItens.CurrentWater < 0)
            {
                isWatering = false;
                speed = initialSpeed;
            }
            if (isWatering)
            {
                playerItens.CurrentWater -= 0.01f;
            }
        }
        else
        {
            isWatering = false;
        }
    }

    void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;

        }
    }
    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRolling = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRolling = false;
        }
    }

    #endregion
}
