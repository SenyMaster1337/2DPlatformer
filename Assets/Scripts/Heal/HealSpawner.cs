using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [SerializeField] private Healer _heal;
    [SerializeField] private SpawnPointHeal[] _spawnPoints;

    private void Start()
    {
        SpawnHeals();
    }

    private void SpawnHeals()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Vector2 coinPosition = _spawnPoints[i].transform.position;
            Instantiate(_heal, coinPosition, Quaternion.identity);
        }
    }
}
