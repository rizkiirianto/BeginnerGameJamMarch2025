using UnityEngine;

public class Bell : SwitchObject
{
    private bool playerHasEntered;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&playerHasEntered)
        {
            StartCoroutine(ScaleOverTimeUnderworld(1f,0.5f)); 
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bumped");
            playerHasEntered=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Leave");
            playerHasEntered=false;
        }
    }
    
    
}
