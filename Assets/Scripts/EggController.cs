using UnityEngine;

public class EggController : MonoBehaviour
{
    [SerializeField]
    private float underBound;
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private GameObject particle;

    private float timer;

    private void Start()
    {
        timer = lifeTime;
    }

    private void Update()
    {
        //timer -= Time.deltaTime;
        if (transform.position.y < underBound || timer < 0f)
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
            if (collider.GetComponent<BlockController>().GetBlockTypeString() == "Spike")
            {
                Instantiate(particle, transform.position, Quaternion.identity, null);
                Destroy(gameObject);
            }
        }
    }
}
