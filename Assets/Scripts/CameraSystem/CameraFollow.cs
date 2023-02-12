using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 offset;
    private float updateCameraOffsetY = 0.1f;
    private float updateCameraOffsetZ = 0.3f;
    private void OnEnable() => GameEventsSystem.OnSetCameraOffSet += UpdateOffSet;

    private void OnDisable() => GameEventsSystem.OnSetCameraOffSet -= UpdateOffSet;

    void Start()
    {
       
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }

    private void UpdateOffSet(int value)
    {
        offset = new Vector3(offset.x, offset.y + value * updateCameraOffsetY, offset.z - value * updateCameraOffsetZ);
    }
    
}
