using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Vector2 coinPosition = _spawnPoints[i].transform.position;
            Coin coin = Instantiate(_coin, coinPosition, Quaternion.identity);
            coin.CoinDestroying += DestroyCoin;
        }
    }

    private void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
        coin.CoinDestroying -= DestroyCoin;
    }
}
