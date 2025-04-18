using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance) Destroy(gameObject);
        else _instance = this;
        DontDestroyOnLoad(this);
        
    }
    #endregion

    [SerializeField] private TextMeshProUGUI scoreText;
    public int score;

    private void Update()
    {
        
    }

    public void addScore(int increment)
    {
        score += increment;
        scoreText.text = score.ToString();
    }

    public void PlusOne()
    {
        addScore(1);
    }
}
