using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //public Transform playerBody;
    Transform camera;

    [SerializeField] float mouseSensitivity = 100f;
    float xRotation = 0f;

    public Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            camera = GetComponentInChildren<Camera>().transform;
        }
        catch { }
        // hides cursor and locks it in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CharacterLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // camera on the x-axis rotates the camera and xRotation is clamped so it won't go over the player on either sides
        //transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        camera.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // camera on the y-axis rotates the player
        rotation = Vector3.up * mouseX;
        //playerBody.Rotate(Vector3.up * mouseX);
        //playerBody.Rotate(rotation);
        gameObject.transform.Rotate(rotation);
    }
}
