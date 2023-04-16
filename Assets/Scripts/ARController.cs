using UnityEngine;

public class ARController : MonoBehaviour
{
   
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject _buttonChangeColor;

    private Camera _arCamera;
    private Transform _cameraTransform;
    void Start()
    {
        _arCamera = Camera.main;
        _cameraTransform = _arCamera.transform;
    }

    
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _enemyLayer))
        {
            _buttonChangeColor.SetActive(true);
        }
        else
        {
            _buttonChangeColor.SetActive(false);
        }
    }
}
