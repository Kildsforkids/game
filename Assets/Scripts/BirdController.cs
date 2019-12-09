using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private int maxEggs;

    private Rigidbody2D rb;
    private BoxCollider2D col;
    private bool isJump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            isJump = false;
            if (transform.childCount < maxEggs)
            {
                Vector3 pos = transform.position;
                transform.position += (Vector3)(Vector2.up * jumpForce);
                Instantiate(prefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
