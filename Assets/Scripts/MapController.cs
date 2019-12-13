using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform[] blocks;
    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private float timerValue;
    [SerializeField]
    private float chance;

    private float timer;

    private void Start()
    {
        timer = timerValue;
    }

    private void Update()
    {
        //if (target.position.x > blocks[1].position.x)
        //{
        //    Transform tmp = blocks[0];
        //    tmp.position = blocks[2].position + Vector3.right * 0.7f;
        //    blocks[0] = blocks[1];
        //    blocks[1] = blocks[2];
        //    blocks[2] = tmp;
        //    if (Random.Range(0f, 1f) > 0.7)
        //        Instantiate(blockPrefab, new Vector2(target.position.x + 5f, target.position.y + Random.Range(-1, 1)), Quaternion.identity, transform);
        //}
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            //if (Random.Range(0f, 1f) < 0.5f)
            //{
            //    GameObject obj = Instantiate(blockPrefab, new Vector2(target.position.x + 5f, Random.Range(0f, 4f)), Quaternion.identity, transform);
            //    obj.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.5f, 1f));
            //}
            if (Random.Range(0f, 1f) < chance)
            {
                GameObject obj = Instantiate(blockPrefab, new Vector2(target.position.x + 5f, target.position.y), Quaternion.identity, transform);
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
