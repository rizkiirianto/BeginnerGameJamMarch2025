using UnityEngine;

public class TembokCrusher : MonoBehaviour
{
    public float xThresholdUp;
    public float xThresholdDown;
    //public float speed;
    public float speedUp;
    public float speedDown;
    private float currentSpeed;
    // Update is called once per frame
    private bool isGoingUp;
    private void Update()
    {
        currentSpeed = isGoingUp ? speedUp : speedDown;
        transform.Translate((isGoingUp? Vector3.up:Vector3.down) * currentSpeed * Time.deltaTime);
        if (transform.position.y > xThresholdUp) {
            isGoingUp = false;
        }
        if (transform.position.y < xThresholdDown) {
            isGoingUp = true;
        }
    }
}
