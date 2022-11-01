using UnityEngine;

public class RotPlayer : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 80;
    private Touch _control;
    private float _deltaRot;
    
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (Input.touchCount == 0)
        {
            return;
        }
        _control = Input.GetTouch(Input.touchCount-1);
        _deltaRot = rotSpeed * (Camera.main.ScreenToWorldPoint(_control.position).x > 0 ? -1 : 1) * Time.deltaTime;
        transform.Rotate(Vector3.forward, _deltaRot);
    }
}
