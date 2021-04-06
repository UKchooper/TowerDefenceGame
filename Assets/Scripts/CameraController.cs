using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float PanSpeed = 30f;
    public float PanBorderThickness = 10f;
    public float ScrollSpeed = 5f;
    public float MinY = 10f;
    public float MaxY = 80f;

    private bool doMovement = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if(doMovement == false)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - PanBorderThickness)
        {
            transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= PanBorderThickness)
        {
            transform.Translate(Vector3.back * PanSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - PanBorderThickness)
        {
            transform.Translate(Vector3.right * PanSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= PanBorderThickness)
        {
            transform.Translate(Vector3.left * PanSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;

        position.y -= scroll * 500 * ScrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, MinY, MaxY);

        transform.position = position;
    }
}
