using UnityEngine;
using UnityEngine.UI;

public class StartBattle : MonoBehaviour
{
    public int startSeconds = 3;
    public Text textComponent;
    private float timeLeft;

    void Start()
    {
        timeLeft = startSeconds;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        textComponent.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            textComponent.text = "FIGHT!!!";
        }
    }
}
