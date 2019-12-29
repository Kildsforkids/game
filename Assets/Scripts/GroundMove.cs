using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float boost;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
<<<<<<< HEAD
        speed += Time.deltaTime * boost;
=======
        speed += Time.deltaTime * 0.5f;
>>>>>>> dev
    }
}
