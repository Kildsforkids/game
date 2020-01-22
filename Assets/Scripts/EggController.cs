using UnityEngine;

public class EggController : MonoBehaviour
{
    [SerializeField]
    private float underBound;
    [SerializeField]
    private GameObject particle;

    private Transform player;

    private bool isStopped = false;

    private void Start()
    {
        player = GameObject.Find("Frogsterr").transform;
    }

    private void Update()
    {
        if (!isStopped)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y < underBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if (collider.GetComponent<BlockController>() != null)
        {
            if (GetComponent<EdgeCollider2D>().IsTouching(collider))
            {
                isStopped = true;
            }
            if (collider.GetComponent<BlockController>().GetBlockTypeString() == "Spike")
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
