using UnityEngine;

public class spawner3 : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] int heightDifference;
    [SerializeField] Vector2 offset;
    private int lastSCore;

    private void Start()
    {
        lastSCore = GameManagerp.Instance.score;
    }

    private void Update()
    {
        if (GameManagerp.Instance.score - lastSCore > heightDifference)
        {
            lastSCore = GameManagerp.Instance.score;
            Instantiate(platform, new Vector3(Random.Range(-offset.x, offset.x), GameManagerp.Instance.player.transform.position.y + offset.y, 0), Quaternion.identity);
        }
    }
}
