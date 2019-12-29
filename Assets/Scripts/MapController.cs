using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab, boundPrefab;
    [SerializeField]
    private float lowerBound, upperBound, offsetX;
    [SerializeField]
    private int length;
    [SerializeField]
    private float timerValue, chance;

    private Transform target;
    private float timer;

    private void Start()
    {
        target = GameObject.Find("Frogsterr").transform;
        CreateBounds(boundPrefab, length);
        timer = timerValue;
    }

    private void Update()
    {
        //SpawnObstacle(blockPrefab);
    }

    private void CreateBounds(GameObject bound, int length)
    {
        for (int i = 0; i < length; i++)
        {
            Instantiate(bound, new Vector2(i + offsetX, upperBound), Quaternion.identity, transform);
            Instantiate(bound, new Vector2(i + offsetX, lowerBound), Quaternion.identity, transform);
        }
    }

    private void SpawnObstacle(GameObject obstacle)
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            if (Random.Range(0f, 1f) < chance)
            {
                GameObject obj = Instantiate(obstacle, new Vector2(target.position.x + 7f, target.position.y), Quaternion.identity, transform);
                obj.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.5f, 1f));
                if (Random.Range(0f, 1f) < 0.3f && chance < 1f)
                {
                    chance += 0.1f;
                }
            }
            timer = timerValue;
        }
    }
}
