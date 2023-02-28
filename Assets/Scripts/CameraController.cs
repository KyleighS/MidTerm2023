using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public float panBorder = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 20f;

    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        //clamp movement on left, right, up, down
        //same way a zoom
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }

        if (!canMove)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

        }        
        
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        }        
        
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        }        
        
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}