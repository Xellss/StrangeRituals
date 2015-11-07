using UnityEngine;
using System.Collections;

public class CameraFollowObject : MonoBehaviour 
{
    public Transform Target;

    private Transform myTransform;

    private float offsetPlayerX;
    private float offsetPlayerY;
    private float offsetPlayerZ;

    void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    void Start()
    {
        offsetPlayerX = myTransform.position.x - Target.position.x;
        offsetPlayerY = myTransform.position.y - Target.position.y;
        offsetPlayerZ = myTransform.position.z - Target.position.z;
    }

    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        myTransform.position = Target.position + new Vector3(offsetPlayerX, offsetPlayerY, offsetPlayerZ);
    }
}
