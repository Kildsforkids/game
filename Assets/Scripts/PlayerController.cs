using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float reloadTimerValue;
    [SerializeField]
    private float horizontalBounds;
    [SerializeField]
    private int health;

    private float reloadTimer;

    private void Start()
    {
        reloadTimer = reloadTimerValue;
    }

    private void Update()
    {
        reloadTimer -= Time.deltaTime;
        if (Input.GetAxisRaw("Vertical") > 0 && reloadTimer < 0)
        {
            Instantiate(rocket, transform.position + Vector3.up, Quaternion.identity, null);
            reloadTimer = reloadTimerValue;
        }
        //if (transform.position.x < horizontalBounds && transform.position.x > -horizontalBounds)
        //{
        transform.Translate(Input.GetAxisRaw("Horizontal") * Vector3.right * speed * Time.deltaTime);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 10;
    }
}
