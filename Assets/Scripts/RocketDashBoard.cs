using UnityEngine;
using UnityEngine.UIElements;

public class RocketDashBoard : MonoBehaviour
{
    private RectTransform fillamount;

    [SerializeField] private float changeFill = 0.1f;
    public void Start()
    {
        fillamount = GetComponent<RectTransform>();
        Application.targetFrameRate = 60;
    }

    public void Update()
    {
        if (fillamount.localScale.y <= 1)
        {
            fillamount.localScale = new Vector3(1.0f, fillamount.localScale.y + 0.001f, 1.0f);
        }
    }
    public void ChangeFuel()
    {
        fillamount.localScale = new Vector3(1.0f, fillamount.localScale.y - changeFill, 1.0f) ;
    }
}