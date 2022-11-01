
using TMPro;
using UnityEngine;

public class ResultShower : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI resultTextPref;
    private Points _p;
    
    private SumsGenerator _sg;
    
    public enum Result
    {
        Missed,
        Great,
        Wrong
    }

    void Start()
    {
        _p = FindObjectOfType<Points>();
        _sg = FindObjectOfType<SumsGenerator>();
    }

    public void ShowResult(Result result)
    {
        
        switch (result)
        {
            case Result.Great:
                SpawnResult("Great", Color.green);
                _p.score++;
                AudioManager.AudioManager.Instance.Play("Great");
                break;
            case Result.Wrong:
                SpawnResult("Wrong", Color.red);
                _p.RevomeHp();
                AudioManager.AudioManager.Instance.Play("Wrong");
                break;
            case Result.Missed:
                SpawnResult("Missed", new Color(255, 80, 0));
                AudioManager.AudioManager.Instance.Play("Missed");
                _p.RevomeHp();
                break;
        }
    }

    void SpawnResult(string text, Color color)
    {
        TextMeshProUGUI resultText = Instantiate(resultTextPref, transform);
        resultText.SetText(text);
        resultText.color = color;
        resultText.gameObject.SetActive(true);
        
        _sg.GenerateSum();
    }
}
