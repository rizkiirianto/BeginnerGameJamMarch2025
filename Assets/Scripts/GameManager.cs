using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Instantiate(Resources.Load($"Prefabs/Levels/Level {StaticData.level}"));
    }


}
