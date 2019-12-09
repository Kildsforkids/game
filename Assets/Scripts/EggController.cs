using UnityEngine;

public class EggController : MonoBehaviour
{
    [SerializeField]
    private float underBound;

    private void Update()
    {
        if (transform.position.y < -underBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Obstacle(Clone)")
            GetComponent<EggMove>().enabled = false;
    }
}
