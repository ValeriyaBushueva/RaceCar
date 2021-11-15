using UnityEngine;

public class FollowCursor : MonoBehaviour
{
   private void Start()
    {
        Cursor.visible = false;
    }
    
    private void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }
}
