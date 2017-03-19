using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript2 : MonoBehaviour {
    public Text timerText;

    public const int POINT_RED = 9;
    public const int POINT_YELLOW = 29;

    [SerializeField]
    private int startTimer = 60;

    private Color color;
    //private float startTime;
    private float current_time;
    // Use this for initialization
    void Start () {
        //startTime = Time.time;
        current_time = startTimer;
        color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        float t = Time.time - startTime;
        string minutes = (t / 60).ToString();
        string seconds = (t % 60).ToString();
        timerText.text = minutes + ":" + seconds;
        */

        current_time -= Time.deltaTime;
        int seconds = (int)current_time;
        int msecs = (int)((current_time - seconds) * 100);

        switch (seconds)
        {
            case POINT_YELLOW:
                color = Color.yellow;
                break;

            case POINT_RED:
                color = Color.red;
                break;

            default:
                break;

        }

        if(current_time <= 0)
        {
            Destroy(gameObject);
            timerText.text = "Game Over";
            return;
          //  current_time = startTimer;
           // color = Color.black;
        }
        
        timerText.text = string.Format("{0}:{1}", seconds, msecs);
        timerText.color = color;
    
        
	
	}
}
