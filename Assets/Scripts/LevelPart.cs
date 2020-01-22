using UnityEngine;

public class LevelPart : MonoBehaviour
{
    [SerializeField]
    private float maxDistance;

    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Frogsterr").transform;
    }

    private void Update()
    {
        if (transform.Find("EndPosition").position.x + maxDistance < player.position.x)
        {
            Destroy(gameObject);
        }
    }
}
