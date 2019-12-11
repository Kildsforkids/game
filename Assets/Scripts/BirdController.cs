using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject prefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = transform.position + Vector3.up;
            Instantiate(prefab, transform.position + Vector3.down, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.Stop();
        enabled = false;
    }
}
