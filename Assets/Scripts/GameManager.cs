using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public static int playerCount = 0;

    public GameObject spawnZone;
    // Start is called before the first frame update

    private void Update()
    {
        if (playerCount == 0)
        {
            spawnPlayer();
        }
    }

    void spawnPlayer()
    {
        Vector2 center = spawnZone.transform.position;
        Vector2 size = spawnZone.GetComponent<Renderer>().bounds.size;

        Vector2 pos = center + new Vector2(
            Random.Range(-size.x / 2, size.x / 2),
            0
            );
        Instantiate(playerPrefab, pos, Quaternion.identity);
        playerCount++;
    }
}
