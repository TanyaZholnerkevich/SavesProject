using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    private Rigidbody _rb;
    private int maxCoins = 8;
    
    public float speed = 7f;
    public int health = 0;
    public int coins = 0;
    public int level = 0;
    public Vector3 playerPos;
    
    public static event Action OnGameOver = delegate {  };
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        level = GameStart.currentLevel;
    }

    private void Start()
    {
        LoadSavedData();
    }

    private void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        
        MovePlayer(hor, vert);

        if (health <= 0) OnGameOver();
    }

    private void LoadSavedData()
    {
        if (GameStart.isLoad == true)
        {
            PlayerData data = Saving.LoadPlayerData();
            health = data.health;
            level = data.level;
            coins = data.coins;
            var pos = new Vector3(data.posX, data.posY, data.posZ);
            transform.position = pos;
        }
        else
        {
            health = 100;
            coins = 0;
        }
    }
    public void SavePlayerData()
    {
        playerPos = transform.position;
        Saving.SavePlayerData(this);
    }
    private void MovePlayer(float hor, float vert)
    {
        _rb.velocity = new Vector3(hor, 0, vert) * speed;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            health -= 20;
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            coins++;
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            if (coins == maxCoins)
            {
                var nextLevel = GameStart.currentLevel + 1;
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                return;
            }
        }
    }
}