using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private float scoreTimer;

    private Text textComponent;
    private string defaultText;

    private float timer;
    private int score;

    private void Start()
    {
        textComponent = GetComponent<Text>();
        defaultText = textComponent.text;
        score = 0;
        textComponent.text = defaultText + score;
        timer = scoreTimer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            score++;
            textComponent.text = defaultText + score;
            timer = scoreTimer;
        }
    }
}
