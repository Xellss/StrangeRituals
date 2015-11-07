using UnityEngine;
using System.Collections;

public class CollectItem : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
