using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform target;

    void Update () {
        transform.position = new Vector3(target.position.x, transform.position.y, -15);
    }

}
