using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private RawImage[] _healthImages;
    private int _maxHealth;
    private int _healthCount;
    public int score=0;
    
    private GameOverHandeler _gameOverHandeler;
    
    void Start()
    {
        _healthImages = GetComponentsInChildren<RawImage>();
        _maxHealth = _healthImages.Length;
        _healthCount = _maxHealth;
        _gameOverHandeler = FindObjectOfType<GameOverHandeler>();
    }

    public void RevomeHp()
    {
        if (_healthCount == 0)
        {
            _gameOverHandeler.GameOver(score);
            return;
        }
        _healthCount--;
        _healthImages[_healthCount].color = new Color(1, 1, 1, 0.2f);
    }
    
}
