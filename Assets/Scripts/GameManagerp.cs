using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class GameManagerp : MonoBehaviour
{
    #region singleton
    private static GameManagerp _instance;
    public static GameManagerp Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance) Destroy(gameObject);
        else _instance = this;
        DontDestroyOnLoad(_instance);
    }
    #endregion

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public GameObject player;
    public int score;

    private void Update()
    {
        if (player.transform.position.y > score)
        {
            addScore(1);
        }
    }

    public void addScore (int increment)
    {
        score += increment;
        scoreText.text = score.ToString();
    }
}
