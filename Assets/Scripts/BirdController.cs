using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject prefab;

    private Rigidbody2D rb;
    private bool isGameOver = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGameOver)
            {
                if (Physics2D.Raycast(transform.position + Vector3.up / 2, Vector2.up, 0.5f).collider == null)
                {
                    transform.position = transform.position + Vector3.up;
                    Instantiate(prefab, transform.position + Vector3.down, Quaternion.identity);
                }
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                if (!isGameOver)
                {
                    if (Physics2D.OverlapPoint(touchPos) != null && Physics2D.OverlapPoint(touchPos).GetComponent<EggController>() != null)
                    {
                        Destroy(Physics2D.OverlapPoint(touchPos).gameObject);
                    }
                    else if (Physics2D.Raycast(transform.position + Vector3.up / 2, Vector2.up, 0.5f).collider == null)
                    {
                        transform.position = transform.position + Vector3.up;
                        Instantiate(prefab, transform.position + Vector3.down, Quaternion.identity);
                    }
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<EdgeCollider2D>().IsTouching(collision.collider))
        {
            gameController.Stop();
            rb.AddForce(Vector2.left * 200);
            isGameOver = true;
        }
    }
}
