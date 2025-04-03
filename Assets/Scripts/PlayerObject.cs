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
    public AudioSource mirrorSFX;
    public AudioSource mirrorSwapSFX;
    public AudioSource footstepSFX;
    public AudioSource deadSFX;
    private float footstepInterval = 0.5f; // Adjust the interval as needed
    private float footstepTimer = 0f;
    public GameObject deathCanvas;
    

    private void Update()
    {
        deathCanvas.SetActive(false);
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

            if (isMoving)
            {
                footstepTimer += Time.deltaTime;
                if (footstepTimer >= footstepInterval)
                    {
                        footstepSFX.Play();
                        footstepTimer = 0f; // Reset the timer
                    }
            }
            else
            {
                footstepTimer = footstepInterval; // Prevent sound from playing immediately when stopping
            }

            

            if (mirrorTimer.timeLeft == 0) {
                isDead = true;
            }
        }
        else {
            animatorChar.Play("CharacterDeath");
            animatorShadow.Play("ShadowDeath");
            deadSFX.Play();
            deathCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
            {
                RestartLevel();
                isDead = false;
                mirrorTimer.timeLeft = mirrorTimer.startTime;
                swapWorld = false;
            }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(1); // Reload the scene (GameManager will reload the level)
    }

    public void TryMirrorSwap()
    {
        if (playerCouldTransfer && Input.GetKeyDown(KeyCode.E))
        {
            MirrorSwap();
            mirrorSFX.Play();
            mirrorSwapSFX.Play();
        }
    }

    public void TryMirrorExit()
    {
        if (playerCouldExit && Input.GetKeyDown(KeyCode.E))
        {
            MirrorExit();
            mirrorSFX.Play();
            mirrorSwapSFX.Stop();
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
