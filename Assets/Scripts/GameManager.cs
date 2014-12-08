using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

	public GameObject gameOverPanel;
    public GameObject player;
    private int timer = 0;
    private int zombiesKilled;
    public int nrOfLives;

	public bool gameOver = false;
	public float timeLasted;

    void Start()
    {
        instance = this;
		gameOver = false;
    }

    public void ZombieKilled()
    {
        zombiesKilled++;
    }

    public void GameOver()
    {
		timeLasted = Time.realtimeSinceStartup;
		gameOver = true;
		gameOverPanel.SetActive(true);
		Time.timeScale = 0;
    }

}
