using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float boost;

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        speed += Time.deltaTime * boost;
    }
}
