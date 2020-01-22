﻿using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject frog;
    [SerializeField]
    private Transform map, background;
    [SerializeField]
    private GameObject score;
    [SerializeField]
    private GameObject gameOverPanel, winPanel, progressBar, pausePanel, pauseBtn;

    [SerializeField]
    private Transform start, finish;

    private Transform target;

    private bool isPaused;

    private void Start()
    {
        target = GameObject.Find("Frogsterr").transform;
        isPaused = false;
    }

    private void Update()
    {
        progressBar.GetComponent<Slider>().value = scale(start.position.x, finish.position.x, 0, 1, target.position.x);
    }

    public void Pause()
    {
        if (!isPaused)
        {
            Debug.Log("PAUSE");
            map.GetComponent<MapController>().enabled = false;
            map.GetComponent<GroundMove>().enabled = false;
            background.GetComponent<GroundMove>().enabled = false;
            score.GetComponent<ScoreController>().enabled = false;
            Camera.main.GetComponent<CameraController>().enabled = false;
            frog.GetComponent<Move>().enabled = false;
            //frog.GetComponent<Rigidbody2D>().isKinematic = true;
            //Physics.autoSimulation = false;
            Time.timeScale = 0;
            frog.GetComponent<FrogController>().enabled = false;
            Camera.main.GetComponent<AudioSource>().Stop();
            pausePanel.SetActive(true);
            pauseBtn.SetActive(false);
            isPaused = true;
        }
        else
        {
            Debug.Log("UNPAUSE");
            map.GetComponent<MapController>().enabled = true;
            map.GetComponent<GroundMove>().enabled = true;
            background.GetComponent<GroundMove>().enabled = true;
            score.GetComponent<ScoreController>().enabled = true;
            Camera.main.GetComponent<CameraController>().enabled = true;
            frog.GetComponent<Move>().enabled = true;
            //frog.GetComponent<Rigidbody2D>().isKinematic = false;
            //Physics.autoSimulation = true;
            Time.timeScale = 1;
            frog.GetComponent<FrogController>().enabled = true;
            Camera.main.GetComponent<AudioSource>().Play();
            pausePanel.SetActive(false);
            pauseBtn.SetActive(true);
            isPaused = false;
        }
    }

    public void Stop(bool isWin = false)
    {
        map.GetComponent<MapController>().enabled = false;
        map.GetComponent<GroundMove>().enabled = false;
        background.GetComponent<GroundMove>().enabled = false;
        score.GetComponent<ScoreController>().enabled = false;
        Camera.main.GetComponent<CameraController>().enabled = false;
        Camera.main.GetComponent<AudioSource>().Stop();
        if (isWin)
        {
            winPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(true);
        }
    }

    public float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = OldMax - OldMin;
        float NewRange = NewMax - NewMin;
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return NewValue;
    }
}
