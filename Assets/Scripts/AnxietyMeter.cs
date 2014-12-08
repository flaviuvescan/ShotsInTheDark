using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnxietyMeter : MonoBehaviour {

    public static AnxietyMeter instance; 
    public Image image1;
    public Image image2;
    float timeLeft = 5.0f;

    private float initialTime;

    void Awake()
    {
        instance = this;

        initialTime = timeLeft;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        image1.fillAmount = timeLeft / initialTime;
        image2.fillAmount = timeLeft / initialTime;

        if (timeLeft < 0 & !GameManager.instance.gameOver)
        {
            GameManager.instance.GameOver();
        }
    }

    public void AddToTimer(float amount)
    {
        float newValue = timeLeft + amount;
        timeLeft = Mathf.Clamp(newValue, 0f, initialTime);
    }
}
