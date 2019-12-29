using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float offset;

    private Transform target;

    private void Start()
    {
        target = GameObject.Find("Frogsterr").transform;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + offset, transform.position.y, transform.position.z);
    }
}
