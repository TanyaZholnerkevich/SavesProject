using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    private float _distance = 10.0f;
    private float _height = 5.0f;
    private float _heightDamping = 2.0f;
    private float _rotationDamping = 3.0f;
    private void LateUpdate()
    {
        if (!target)
        {
            return;
        }

        float _wantedRotationAngle = target.eulerAngles.y;
        float _wantedHeight = target.position.y + _height;

        float _currentRotationAngle = transform.eulerAngles.y;
        float _currentHeight = transform.position.y;
        
        _currentRotationAngle = Mathf.LerpAngle(_currentRotationAngle, _wantedRotationAngle, _rotationDamping * Time.deltaTime);
        
        _currentHeight = Mathf.Lerp(_currentHeight, _wantedHeight, _heightDamping * Time.deltaTime);
        
        Quaternion currentRotation = Quaternion.Euler(0, _currentRotationAngle, 0);
        
        var _pos = transform.position;
        _pos = target.position - currentRotation * Vector3.forward * _distance;
        _pos.y = _currentHeight;
        transform.position = _pos;
        
        transform.LookAt(target);
    }
}
