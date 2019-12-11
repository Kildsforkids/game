using UnityEngine;

public class GameController : MonoBehaviour
{
    public void Stop()
    {
        GetComponent<MapController>().enabled = false;
        GetComponent<GroundMove>().enabled = false;
    }
}
