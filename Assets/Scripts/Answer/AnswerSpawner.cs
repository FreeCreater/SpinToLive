using UnityEngine;

public class AnswerSpawner : MonoBehaviour
{
    private SumsGenerator _sg;
    [SerializeField] private Answer answerObjPref;
    [SerializeField] private int answerRange = 20;
    [SerializeField] private int maxWrongTimes = 5;
    private int _wrongChance;
    private Answer _answerObj;
    
    void Start()
    {
        _sg = FindObjectOfType<SumsGenerator>();
        _wrongChance = maxWrongTimes;
        InvokeRepeating(nameof(GenerateAnswers),0,2);
    }
    
    void GenerateAnswers()
    {
        _answerObj = Instantiate(answerObjPref, 
            transform.position+new Vector3(Random.Range(-2,3)*0.7f,0,0),
            Quaternion.identity);
        _answerObj.Num = RandomAnswer(out _answerObj.correct);
        _answerObj.transform.SetParent(transform);
    }
    
    public void StopSpawn()
    {
        CancelInvoke(nameof(GenerateAnswers));
        foreach (Answer ans in FindObjectsOfType<Answer>())
        {
            Destroy(ans.gameObject);
        }
    }
    
    int RandomAnswer(out bool correct)
    {
        correct = Random.Range(0, _wrongChance)==0;
        _wrongChance--;
        if (correct)
        {
            _wrongChance = maxWrongTimes;
            return _sg.result;
        }
        return _sg.result + Random.Range(1, answerRange) 
            * (Random.Range(0, 2) == 0 ? -1 : 1);
    }
}
