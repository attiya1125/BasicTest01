using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;

    public Transform rocket;
    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel >= 10)
        {
            _rb2d.AddForce(Vector2.up * SPEED);
            fuel -= FUELPERSHOOT;
        }
        else
        {

        }
    }
    private void Update()
    {
        float rocketPositon = rocket.position.y;
        currentScoreTxt.text = $"{rocketPositon.ToString("N2")} M";

        if (PlayerPrefs.HasKey("HighScore"))
        {
            float bestScore = PlayerPrefs.GetFloat("HIghScore");
            if (bestScore < rocketPositon)
            {
                PlayerPrefs.SetFloat("HighScore", rocketPositon);
                HighScoreTxt.text = rocketPositon.ToString("N2");
            }
            else
            {
                HighScoreTxt.text = bestScore.ToString("N2");
            }
        }
        else
        {

        }
    }
}
