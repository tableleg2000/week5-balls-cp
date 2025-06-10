using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // adjustable value for rotation speed


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

    }
}
