using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> EnemysTypes;
    [SerializeField]
    List<BoxCollider> SpawnPoints;
    [SerializeField]
    int wave;
    [SerializeField]
    int EnemysPerWave;
    [SerializeField]
    bool isSpawningWave;
    [SerializeField]
    int LASTWAVE = 10;
    [SerializeField]
    float spawnRadiusCircle = 5;
    [SerializeField]
    int waveScaleFactor = 5;
    //private StatMoverScript StatMover;

    [Header("UI")]
    [SerializeField]
    private Text ScoreText;

    public AudioSource newWaveSound;

    [SerializeField]
    private bool IsInMenu = false;

    public bool Enabled;
    public void SetWave(int w)
    {
        wave = w;
    }

    public int GetWave()
    {
        return wave;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!IsInMenu)
        {
        StatMoverScript.Instance.WaveReached = wave;
        ScoreText.text = "Curent Wave: " + wave.ToString();

        }
        //StatMover = FindObjectOfType<StatMoverScript>();
        isSpawningWave = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!Enabled) return;
        if (wave >LASTWAVE)
        {
            SceneManager.LoadScene("Victory");
        }
        if (!isSpawningWave && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            FindObjectOfType<SaveLoadManager>()?.Save();
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        isSpawningWave = true;
        //int EnemyTypeToSpawn = Random.Range(0, EnemysTypes.Count);

        List<int> ListofSpawnPoints = new List<int>();

        for (int i = 0; i < (wave / 2) + 1; i++)
            ListofSpawnPoints.Add(Random.Range(0, SpawnPoints.Count));

        wave++;
        if (!IsInMenu)
        {
        ScoreText.text = "Curent Wave: " + wave.ToString();
        StatMoverScript.Instance.WaveReached = wave;

        }
        //StatMover.WaveReached = wave;
        for (int i = 0; i < EnemysPerWave + (wave * waveScaleFactor);)
        {
            for (int y = 0; y < ListofSpawnPoints.Count; y++)
            {
                i++;
                float radians = Random.Range(0, 360) / Mathf.PI;

                Vector3 randomOffset = new Vector3(Mathf.Sin(radians) * spawnRadiusCircle, 0, Mathf.Cos(radians) * spawnRadiusCircle);
                Instantiate(EnemysTypes[Random.Range(0, EnemysTypes.Count)], SpawnPoints[ListofSpawnPoints[y]].transform.position + randomOffset, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        if (!IsInMenu)
        {

        newWaveSound.Play();

        }
        isSpawningWave = false;
    }

}
