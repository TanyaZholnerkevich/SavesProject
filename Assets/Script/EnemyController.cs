using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody _rb;
    private float _speed = 10f;

    private void OnEnable()
    {
        PlayerController.OnGameOver += PlayerControllerOnOnGameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnGameOver -= PlayerControllerOnOnGameOver;
    }

    private void PlayerControllerOnOnGameOver()
    {
        _speed = 0;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _rb.velocity = new Vector3(1, 0, 0) * _speed;
    }
    private void OnCollisionEnter(Collision other)
    {
        _speed *= -1;
    }
}
