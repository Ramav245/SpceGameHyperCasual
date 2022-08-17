using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;

    private Vector3 _offset;

    private Vector3 _position;
    
    private void Start()
    {
        _position = transform.position;
        _offset = target.position - _position;
    }

    private void LateUpdate()
    {
        _position.z = (target.position - _offset).z;
        transform.position = _position;
    }
}
