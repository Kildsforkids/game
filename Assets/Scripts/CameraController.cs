using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = GameObject.Find("Frogsterr").transform;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
}
