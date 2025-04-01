using UnityEngine;

public class MouseInteract2D : MonoBehaviour
{

    [SerializeField] private GoldGenerator goldGenerator;

    void Update()
    {
        SendRay();
    }
    private void SendRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit == true && hit.transform.tag == "Interactable")
            {
                goldGenerator.CookieClick();
            }
        }
    }
}