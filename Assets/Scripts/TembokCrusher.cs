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
    public AudioSource hammerSFX;

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

        if (transform.position.y < 2.5f && transform.position.y > 0.0f ) {
            hammerSFX.Play();
        }

        if (transform.position.y > -2.3f && transform.position.y < 0.0f) {
            hammerSFX.Play();
        }

        if (transform.position.y > 6.3f && transform.position.y < 6.5f) {
            hammerSFX.Play();
        }

        if (transform.position.y > 5.90f && transform.position.y < 5.96f) {
            hammerSFX.Play();
        }
    }
}
