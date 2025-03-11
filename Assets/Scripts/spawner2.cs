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
        if (GameManager.Instance.score-lastScore > spawnDistance)
        {
            lastScore = GameManager.Instance.score;
            Instantiate(platform, new Vector3(Random.Range(-offset.x, offset.x), GameManager.Instance.player.transform.position.y + offset.y, 0), Quaternion.identity);
        }
    }
}
