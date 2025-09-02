using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.CoinDiscovered += DestroyCoin;
    }

    private void OnDisable()
    {
        _player.CoinDiscovered -= DestroyCoin;
    }

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Vector2 coinPosition = _spawnPoints[i].transform.position;
            Instantiate(_coin, coinPosition, Quaternion.identity);
        }
    }

    private void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}
