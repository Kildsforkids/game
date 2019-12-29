using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float boost;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        speed += Time.deltaTime * boost;
    }
}
