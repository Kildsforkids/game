using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject eggPrefab;
    [SerializeField]
    private Sprite dedSprite;
    [SerializeField]
    private float underBound;
    [SerializeField]
    private float force;
    [SerializeField]
    private float actionTimer;

    private Rigidbody2D rb;
    private bool isPaused = false;
    private bool isGameOver = false;
    private float timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Action();
        if (transform.position.y < underBound)
        {
            SetGameOver();
        }
    }

    private void Action()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGameOver && !isPaused)
            {
                var collider = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f).collider;
                if (collider == null)
                {
                    transform.position = transform.position + Vector3.up;
                    Instantiate(eggPrefab, transform.position + Vector3.down, Quaternion.identity);
                    timer = actionTimer;
                }
                else if (collider.GetComponent<BlockController>() != null)
                {
                    if (collider.GetComponent<BlockController>().GetBlockTypeString() == "Spike")
                    {
                        transform.position = transform.position + Vector3.up;
                        Instantiate(eggPrefab, transform.position + Vector3.down, Quaternion.identity);
                        timer = actionTimer;
                    }
                }
            }
            else
            {
                if (!isPaused)
                    SceneManager.LoadScene(0);
                else
                    SetPause();
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (timer <= 0f)
            {
                if (!isGameOver && !isPaused)
                {
                    var collider = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f).collider;
                    if (collider == null)
                    {
                        transform.position = transform.position + Vector3.up;
                        Instantiate(eggPrefab, transform.position + Vector3.down, Quaternion.identity);
                        timer = actionTimer;
                    }
                    else if (collider.GetComponent<BlockController>() != null)
                    {
                        if (collider.GetComponent<BlockController>().GetBlockTypeString() == "Spike")
                        {
                            transform.position = transform.position + Vector3.up;
                            Instantiate(eggPrefab, transform.position + Vector3.down, Quaternion.identity);
                            timer = actionTimer;
                        }
                    }
                }
                else
                {
                    if (!isPaused)
                        SceneManager.LoadScene(0);
                    else
                        SetPause();
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
#endif
#if !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                if (!isGameOver && !isPaused)
                {
                    Collider2D collider;
                    if (Physics2D.OverlapPoint(touchPos) != null && Physics2D.OverlapPoint(touchPos).GetComponent<EggController>() != null)
                    {
                        Destroy(Physics2D.OverlapPoint(touchPos).gameObject);
                    }
                    else if ((collider = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f).collider) == null)
                    {
                        transform.position = transform.position + Vector3.up;
                        Instantiate(eggPrefab, transform.position + Vector3.down, Quaternion.identity);
                        timer = actionTimer;
                    }
                    else if (collider.GetComponent<BlockController>() != null)
                    {
                        if (collider.GetComponent<BlockController>().GetBlockTypeString() == "Spike")
                        {
                            transform.position = transform.position + Vector3.up;
                            Instantiate(eggPrefab, transform.position + Vector3.down, Quaternion.identity);
                            timer = actionTimer;
                        }
                    }
                }
                else
                {
                    if (!isPaused)
                        SceneManager.LoadScene(0);
                    else
                        SetPause();
                }
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                if (timer <= 0f)
                {
                    if (!isGameOver && !isPaused)
                    {
                        Collider2D collider;
                        if (Physics2D.OverlapPoint(touchPos) != null && Physics2D.OverlapPoint(touchPos).GetComponent<EggController>() != null)
                        {
                            Destroy(Physics2D.OverlapPoint(touchPos).gameObject);
                        }
                        else if ((collider = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f).collider) == null)
                        {
                            transform.position = transform.position + Vector3.up;
                            Instantiate(eggPrefab, transform.position + Vector3.down, Quaternion.identity);
                            timer = actionTimer;
                        }
                        else if (collider.GetComponent<BlockController>() != null)
                        {
                            if (collider.GetComponent<BlockController>().GetBlockTypeString() == "Spike")
                            {
                                transform.position = transform.position + Vector3.up;
                                Instantiate(eggPrefab, transform.position + Vector3.down, Quaternion.identity);
                                timer = actionTimer;
                            }
                        }
                    }
                    else
                    {
                        if (!isPaused)
                            SceneManager.LoadScene(0);
                        else
                            SetPause();
                    }
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
#endif
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Finish")
        {
            SetWin();
        }
        else if (collision.tag == "Obstacle")
        {
            SetGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if (collider.GetComponent<BlockController>() != null)
        {
            if (collider.GetComponent<BlockController>().GetBlockTypeString() == "Spike")
            {
                SetGameOver();
            }
        }
        if (GetComponent<EdgeCollider2D>().IsTouching(collider))
        {
            SetGameOver(true);
        }
    }

    public void SetPause()
    {
        gameController.Pause();
        isPaused = !isPaused;
    }

    private void SetWin()
    {
        gameController.Stop(true);
        isGameOver = true;
    }

    private void SetGameOver(bool useForce = false)
    {
        GetComponent<SpriteRenderer>().sprite = dedSprite;
        gameController.Stop();
        if (useForce)
            rb.AddForce(Vector2.left * force);
        isGameOver = true;
#if !UNITY_EDITOR
        //Handheld.Vibrate();
#endif
    }
}
