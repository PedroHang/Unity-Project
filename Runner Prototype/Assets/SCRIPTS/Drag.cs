using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private bool Dropped;
    public float speed = 4.5f;
    

    void Start()
    {
        speed = -4.5f;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (isBeingHeld == true)
        {

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }

         if (Dropped == true)
        {
            speed = 0f;
        }
    }

    private void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
        Dropped = true;
    }
}