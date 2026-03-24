using UnityEngine;

public class ObjectSpin : MonoBehaviour
{
    [Header("Rotation Toggles")]
    public bool rotateX = false;
    public bool rotateY = true;
    public bool rotateZ = false;

    [Header("Rotation Speeds")]
    public float speedX = 50f;
    public float speedY = 100f;
    public float speedZ = 50f;

    void Update()
    {
        float x = rotateX ? speedX * Time.deltaTime : 0f;
        float y = rotateY ? speedY * Time.deltaTime : 0f;
        float z = rotateZ ? speedZ * Time.deltaTime : 0f;

        transform.Rotate(x, y, z);
    }
}