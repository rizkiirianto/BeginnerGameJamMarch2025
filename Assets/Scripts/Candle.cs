using UnityEngine;

public class Candle : SwitchObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool shadowHasEntered;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&shadowHasEntered)
        {
            StartCoroutine(ScaleOverTimeOverworld(1f,0.5f)); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Shadow"))
        {
            Debug.Log("Bumped");
            shadowHasEntered=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Shadow"))
        {
            Debug.Log("Leave");
            shadowHasEntered=false;
        }
    }
    
}
