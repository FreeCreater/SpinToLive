using UnityEngine;


public class AnswersTaker: MonoBehaviour
{
    private Answer _answer;
    private ResultShower _rs;
    private SumsGenerator _sg;

    private void Start()
    {
        
        _rs = FindObjectOfType<ResultShower>();
        _sg = FindObjectOfType<SumsGenerator>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out _answer))
        {
            _rs.ShowResult(_sg.Correct(_answer.Num) ? ResultShower.Result.Great : ResultShower.Result.Wrong);
        }
        Destroy(col.gameObject);
    }
}
