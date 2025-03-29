using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float dropDistance = 3f; // Seberapa jauh tembok turun
    public float dropSpeed = 2f; // Kecepatan turun
    private bool shouldDrop = false;

    void Update()
    {
        if (shouldDrop)
        {
            // Hitung posisi target sejajar dengan lantai
            float targetY = Mathf.Max(transform.position.y - dropDistance, 0); // Pastikan tidak turun di bawah y=0
            
            // Gerakkan tembok ke bawah sampai mencapai targetY
            transform.position = new Vector3(
                transform.position.x,
                Mathf.MoveTowards(transform.position.y, targetY, dropSpeed * Time.deltaTime),
                transform.position.z
            );

            // Hentikan pergerakan jika sudah sejajar lantai
            if (transform.position.y <= targetY)
            {
                shouldDrop = false;
            }
        }
    }

    public void DropObstacle()
    {
        shouldDrop = true;
    }
}
