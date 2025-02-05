using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the rectangle's movement
    public float boundary = 2f; // Limits movement within a range

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float newZ = Mathf.Clamp(transform.position.z + move, -boundary, boundary);
        
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}
