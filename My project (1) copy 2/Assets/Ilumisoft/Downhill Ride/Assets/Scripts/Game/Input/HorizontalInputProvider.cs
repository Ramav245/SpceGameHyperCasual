using UnityEngine;

public class HorizontalInputProvider : IHorizontalInputProvider
{
    public float GetHorizontalInput()
    {
        //Mouse/Touch Input
        if (Input.GetKey(KeyCode.Mouse0))
        {
            var mousePosition = Input.mousePosition;
            
            var screenCenter = new Vector2(Screen.width,Screen.height)/2.0f;
            
            return (mousePosition.x > screenCenter.x) ? 1.0f : -1.0f;
        }
        //Keyboard Input
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
}