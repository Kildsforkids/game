using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform[] blocks;
    [SerializeField]
    private GameObject blockPrefab;

    private void Update()
    {
        if (target.position.x > blocks[1].position.x)
        {
            Transform tmp = blocks[0];
            tmp.position = blocks[2].position + Vector3.right * 0.7f;
            blocks[0] = blocks[1];
            blocks[1] = blocks[2];
            blocks[2] = tmp;
            if (Random.Range(0f, 1f) > 0.7)
                Instantiate(blockPrefab, new Vector2(target.position.x + 5f, target.position.y), Quaternion.identity, transform);
        }
    }
}
