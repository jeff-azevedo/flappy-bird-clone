using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnRateMin = 2;
    public float spawnRateMax = 4.5f;
    public float spawnRate = 2;

    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
        }
    }

    void SpawnPipe()
    {
        transform.position = transform.position + (Vector3.up * Random.Range(1.2f, -1.2f));
        Instantiate(Pipe, transform.position, transform.rotation);
        
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        timer = 0;
    }
}
