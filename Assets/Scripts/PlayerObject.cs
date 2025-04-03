using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObject : MonoBehaviour
{
    public float speed;
    public Animator animatorChar;
    public Animator animatorShadow;
    public float verticalJump;
    public SpriteRenderer charSpriteRenderer;
    public SpriteRenderer shadowSpriteRenderer;
    public bool isGrounded;
    public bool isGroundedSwap;
    public static bool isMoving;
    public static bool isDead;
    public static bool swapWorld;
    public Transform playerPosition;
    public Transform shadowPosition;
    public bool playerCouldTransfer;
    public bool playerCouldExit;
    public TimerScript mirrorTimer;
    

    private void Update()
    {
        if (!isDead) {
            if (!swapWorld) {
                if (playerPosition.position.y < 0 ) {
                    isDead = true;
                }
                if (shadowPosition.position.y > 0) {
                    isDead = true;
                }
            }

            if (swapWorld) {
                if (playerPosition.position.y > 0 ) {
                    isDead = true;
                }
                if (shadowPosition.position.y < 0) {
                    isDead = true;
                }
            }
            isMoving = false;
            if(Input.GetKey(KeyCode.A)) {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                charSpriteRenderer.flipX = true;
                shadowSpriteRenderer.flipX = true;
                isMoving = true;
            }
            if(Input.GetKey(KeyCode.D)) {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                charSpriteRenderer.flipX = false;
                shadowSpriteRenderer.flipX = false;
                isMoving = true;
            }

            if (mirrorTimer.timeLeft == 0) {
                isDead = true;
            }
        }
        else {
            animatorChar.Play("CharacterDeath");
            animatorShadow.Play("ShadowDeath");
        }

        if (Input.GetKeyDown(KeyCode.R))
            {
                RestartLevel();
                isDead = false;
                mirrorTimer.timeLeft = mirrorTimer.startTime;
                swapWorld = false;
            }
            Debug.Log (isDead);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0); // Reload the scene (GameManager will reload the level)
    }

    public void TryMirrorSwap()
    {
        if (playerCouldTransfer && Input.GetKeyDown(KeyCode.E))
        {
            MirrorSwap();
        }
    }

    public void TryMirrorExit()
    {
        if (playerCouldExit && Input.GetKeyDown(KeyCode.E))
        {
            MirrorExit();
        }
    }


    public void MirrorSwap()
    {
        swapWorld = true; 
        playerPosition.position = new Vector3(playerPosition.position.x, -0.75f, playerPosition.position.z);
        playerPosition.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
        shadowPosition.position = new Vector3(shadowPosition.position.x, 0.75f, shadowPosition.position.z);
        shadowPosition.Rotate(180f,0f,0f,Space.Self);
        mirrorTimer.TimerOn = true;
    }

    public void MirrorExit()
    {
        swapWorld = false; 
        shadowPosition.position = new Vector3(shadowPosition.position.x, -0.75f, shadowPosition.position.z);
        shadowPosition.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
        playerPosition.position = new Vector3(playerPosition.position.x, 0.75f, playerPosition.position.z);
        playerPosition.Rotate(180f,0f,0f,Space.Self);
        mirrorTimer.TimerOn = false;
    }
    
}
