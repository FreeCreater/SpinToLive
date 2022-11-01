using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    private TextMeshProUGUI _resultText;
    private Vector2 _startPos;

    void Start()
    {
        _resultText = GetComponentInChildren<TextMeshProUGUI>();
        _startPos = transform.position;
        _resultText.color = _resultText.color - new Color(0, 0, 0, 0.4f);
        _resultText.gameObject.SetActive(true);
        Destroy(gameObject, lifeTime);
    }
    
    void Update()
    {
        _resultText.color = _resultText.color-new Color(0, 0, 0, Time.deltaTime/2f);
        transform.Translate(0, 5 * Time.deltaTime, 0);
    }
}
