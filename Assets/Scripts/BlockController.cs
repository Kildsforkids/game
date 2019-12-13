using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField]
    private float leftBound;

    private void Update()
    {
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
