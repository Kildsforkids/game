using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float gravity;

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        //transform.Translate(Vector2.down * Time.deltaTime * gravity);
    }
}
