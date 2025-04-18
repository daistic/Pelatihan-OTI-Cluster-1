using UnityEngine;

public class spawner2 : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private Vector2 offset;
    [SerializeField] private int spawnDistance;
    private int lastScore;

    private void Start()
    {
        lastScore = GameManager.Instance.score;
    }

    private void Update()
    {
       
    }
}
