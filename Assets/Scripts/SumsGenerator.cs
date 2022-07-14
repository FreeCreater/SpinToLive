using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SumsGenerator : MonoBehaviour
{
    private TextMeshProUGUI _sumText;
    [SerializeField] private string operands = "+-*/";
    [SerializeField] private int maxPl = 101;
    [SerializeField] private int maxMull = 11;
    public int result;

    public bool Correct(int num)
    {
        return num == result;
    }
    void Start()
    {
        _sumText = GetComponentInChildren<TextMeshProUGUI>();
        GenerateSum();
    }
    public void GenerateSum()
    {
        int first = 0, second = 0;
        char operand;
        operand = operands[Random.Range(0, operands.Length)];
        switch (operand)
        {
            case '+':
                first = Random.Range(0, maxPl);
                second = Random.Range(0, maxPl);
                result = first + second;
                break;
            case '-':
                first = Random.Range(2, maxPl);
                second = Random.Range(0, first);
                result = first - second;
                break;
            case '*':
                first = Random.Range(1, maxMull);
                second = Random.Range(0, maxMull);
                result = first * second;
                break;
            case '/':
                second = Random.Range(1, maxMull);
                result = Random.Range(1, maxMull);
                first = second * result;
                break;
            default:
                print("Need case for "+operand);
                break;
        }
        _sumText.SetText($"{first} {operand} {second}");
    }
    
}
