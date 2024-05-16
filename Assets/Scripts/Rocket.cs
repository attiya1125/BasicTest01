using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;

    float rocketPositon;
    float bestScore;

    public RectTransform front;

    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;

    public Transform rocket;
    private void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel >= FUELPERSHOOT)
        {
            _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
            fuel -= FUELPERSHOOT;
            Debug.Log("남은 연료량" + fuel);
        }
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetFloat("BestScore");
            HighScoreTxt.text = $"HIGH : {bestScore.ToString("N2")} M";
        }
    }
    private void Update()
    {
        rocketPositon = rocket.position.y;
        currentScoreTxt.text = $"{rocketPositon.ToString("N2")} M";
        // 현재 점수 갱신 실시간
        if ( rocketPositon > bestScore)
        {
            bestScore = rocketPositon;
            HighScoreTxt.text = $"HIGH : {bestScore.ToString("N2")} M";
        }
        // 게임이 끝나는 조건
        if ( rocketPositon <= 0 && fuel == 0)
        {
            PlayerPrefs.SetFloat("BestScore" , bestScore);
            PlayerPrefs.Save();
        }
    }
    public void UseFuel()
    {
        front.localScale = new Vector3(1f, 0.1f, 1f);
    }
}
