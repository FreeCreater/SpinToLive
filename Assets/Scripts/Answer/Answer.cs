using System;
using TMPro;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private TextMeshProUGUI _ansText;
    
    private ResultShower _rs;

    private int _num;
    public bool correct;
    public int Num
    {
        get => _num;
        set
        {
            _num = value;
            SetAnswerText();
        }
    }

    private void Awake()
    {
        _rs = FindObjectOfType<ResultShower>();
    }
    
    private void SetAnswerText()
    {
        _ansText = GetComponentInChildren<TextMeshProUGUI>();
        _ansText.SetText(_num.ToString());
    }
    
    void Update()
    {
        transform.Translate(0,-speed*Time.deltaTime,0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("MissCollider"))
            if (correct&&FindObjectOfType<SumsGenerator>().Correct(_num))
            {
                _rs.ShowResult(ResultShower.Result.Missed);
            }
        Destroy(gameObject);
    }
}
