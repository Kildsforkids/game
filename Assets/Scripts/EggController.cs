using UnityEngine;

public class EggController : MonoBehaviour
{
    [SerializeField]
    private float underBound;
    [SerializeField]
    private float lifeTime;

    private float timer;

    private void Start()
    {
        timer = lifeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (transform.position.y < underBound || timer < 0f)
        {
            Destroy(gameObject);
        }
    }
}
