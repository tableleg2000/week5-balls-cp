using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXInput = Input.GetAxis("Mouse X");
       
        transform.Rotate(mouseSensitivity * Time.deltaTime * mouseXInput * Vector3.up);
       

    }
}
