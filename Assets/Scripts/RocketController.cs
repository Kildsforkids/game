using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float upperBound;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.y > upperBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
