using UnityEngine;
public class RandomEnemyRotation : MonoBehaviour
{
    public float rotationSpeed;
    void Start()
    {
        if (Random.Range(1, 3) == 1)
        {
            rotationSpeed *= -1;
        }
    }
    void Update()
    {
        transform.Rotate(transform.forward, rotationSpeed * Time.deltaTime);
    }
}