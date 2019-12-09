using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 0, transform.position.z);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
