using UnityEngine;

public class Candle : SwitchObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    public override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Shadow"))
        {
            Debug.Log("Bumped");
            hasEntered=true;
        }
    }
    public override void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Shadow"))
        {
            Debug.Log("Leave");
            hasEntered=false;
        }
    }
}
