using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Transform map;
    [SerializeField]
    private GameObject score;
    [SerializeField]
    private GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void Stop()
    {
        map.GetComponent<MapController>().enabled = false;
        map.GetComponent<GroundMove>().enabled = false;
        score.GetComponent<ScoreController>().enabled = false;
        Camera.main.GetComponent<CameraController>().enabled = false;
        Camera.main.GetComponent<AudioSource>().Stop();
        gameOverPanel.SetActive(true);
    }
}
