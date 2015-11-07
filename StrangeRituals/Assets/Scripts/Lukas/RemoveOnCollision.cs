using UnityEngine;
using System.Collections;

public class RemoveOnCollision : MonoBehaviour 
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
