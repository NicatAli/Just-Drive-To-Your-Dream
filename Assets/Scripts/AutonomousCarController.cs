using UnityEngine;

public class AutonomousCarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    void Update()
    {
        // Aracın ileri doğru hareketi
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
}
