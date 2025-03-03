using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private float spawnModule;
    [SerializeField] private GameObject paltform;
    [SerializeField] private float spawnOffset;

    private void FixedUpdate()
    {
        float rand = Random.Range(0, spawnModule);

        if (rand > 199)
        {
            Instantiate(paltform, new Vector3 (Random.Range(transform.position.x - spawnOffset, transform.position.x + spawnOffset), 0, 0), Quaternion.identity, this.gameObject.transform);
        }
    }
}
