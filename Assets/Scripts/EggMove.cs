using UnityEngine;

public class EggMove : MonoBehaviour
{
    [SerializeField]
    private float gravity;

    //private void Update()
    //{
    //    transform.Translate(Vector2.down * Time.deltaTime * gravity);
    //}

    private void LateUpdate()
    {
        transform.position = new Vector2(transform.parent.position.x, transform.position.y);
    }
}
