using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    private float _rotationSpeed = 50f;
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
        _rotationSpeed = 0f;
    }
    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}