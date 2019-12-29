using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField]
    private float leftBound;

    private enum BlockType { Block, Spike }
    [SerializeField]
    private BlockType blockType;

    private void Update()
    {
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    public string GetBlockTypeString()
    {
        return blockType.ToString();
    }
}
