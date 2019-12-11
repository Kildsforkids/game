using UnityEngine;

public class EggController : MonoBehaviour
{
    [SerializeField]
    private float underBound;

    private void Update()
    {
        if (transform.position.y < -underBound)
        {
            Destroy(gameObject);
        }
    }
}
