using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float parallaxEffect;

    private float length, startpos;
    private Transform cam;

    private void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    private void Update()
    {
        var distance = cam.position.x * parallaxEffect;

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
