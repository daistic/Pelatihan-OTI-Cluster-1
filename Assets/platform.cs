using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private float platformSpeed;
    //[SerializeField] private float sizeModule;

    private void OnEnable()
    {
        //transform.localScale = new Vector3(Random.Range(1, sizeModule), 0, 0);
    }

    private void Update()
    {
        transform.position -= new Vector3(0, platformSpeed, 0) * Time.deltaTime;
    }
}
