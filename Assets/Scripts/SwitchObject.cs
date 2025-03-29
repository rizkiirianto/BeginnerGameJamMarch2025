using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class SwitchObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject redWall; // Make sure this is assigned in the Inspector
    public float moveDistance = 5f;
    public float moveSpeed = 2f;
    private bool hasEntered;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&hasEntered)
        {
            StartCoroutine(ScaleOverTime(1f,0.5f)); 
        }
    }
    public virtual void PlayerEntered()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bumped");
        hasEntered=true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Leave");
        hasEntered=false;
    }
    private IEnumerator ScaleOverTime(float duration, float scale) {
        var startScale = redWall.transform.localScale;
        var endScale = new Vector3(transform.localScale.x,0,transform.localScale.z);
        var elapsed = 0f;
        Vector3 targetPosition = new Vector3(redWall.transform.position.x, 0, redWall.transform.position.z);

        while (elapsed < duration&&redWall.transform.position.y < targetPosition.y) {
            Debug.Log("Starting Coroutine: MoveWallDown");
            var t = elapsed / duration;
            redWall.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            redWall.transform.position = Vector3.MoveTowards(redWall.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            Debug.Log("Wall Position: " + redWall.transform.position);
            elapsed += Time.deltaTime;
            yield return null;
        }
        redWall.transform.localScale = endScale;
        }
        //redWall.transform.position= targetPosition;
}

