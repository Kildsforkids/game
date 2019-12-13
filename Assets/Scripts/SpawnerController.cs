using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private float timerValue;
    [SerializeField]
    private float horizontalBounds;

    private Transform player;
    private float timer;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        timer = timerValue;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Instantiate(obstacle, new Vector2(player.position.x + Random.Range(-1f, 1f), transform.position.y), Quaternion.identity, null);
            timer = timerValue;
            if (Random.Range(0f, 1f) < 0.3f)
            {
                timerValue -= 0.1f;
                if (timerValue < 0.2f) timerValue = 0.2f;
            }
        }
    }
}
