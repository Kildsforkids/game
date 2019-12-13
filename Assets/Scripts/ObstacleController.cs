using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lowerBound;

    private void Start()
    {
        speed = Random.Range(2f, 10f);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
