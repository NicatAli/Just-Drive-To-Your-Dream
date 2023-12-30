using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; // Oluşturulacak aracın prefabı
    public Transform spawnPoint; // Araçların spawn edileceği konum
    public float spawnInterval = 5f; // Araçların spawn edilme aralığı (saniye)

    void Start()
    {
        // Belirli bir süre aralığında SpawnCars fonksiyonunu çağırmak için InvokeRepeating kullanılır.
        InvokeRepeating("SpawnCars", 0f, spawnInterval);
    }

    void SpawnCars()
    {
        // Yeni bir araç oluşturulur ve spawnPoint konumuna yerleştirilir.
        GameObject newCar = Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
