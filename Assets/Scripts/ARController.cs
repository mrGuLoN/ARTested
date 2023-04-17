using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public static ARController Instance = null;
   
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject _buttonChangeColor;

    private ARPlaneManager _arPlaneManager;
    private ARPointCloudManager _arPointCloudManager;
    
    private Camera _arCamera;
    private Transform _cameraTransform;
    
    private void Awake()
    {
    if (Instance == null) 
    {
    	    Instance = this; 
    	} 
    	else if(Instance == this)
    	{ 
    	    Destroy(gameObject);
    	}
    
    }
    private void Start()
    {
        _arPlaneManager = GetComponent<ARPlaneManager>();
        _arPointCloudManager = GetComponent<ARPointCloudManager>();
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

    public void OffTrackVision()
    {
        foreach (var obj in _arPlaneManager.trackables)
        {
            obj.gameObject.SetActive(false);
        }

        foreach (var obj in _arPointCloudManager.trackables)
        {
            obj.gameObject.SetActive(false);
        }

        _arPlaneManager.enabled = false;
        _arPointCloudManager.enabled = false;
    }
}
