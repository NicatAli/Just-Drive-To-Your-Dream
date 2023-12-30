using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnter : MonoBehaviour
{
    public GameObject carCollider; // Arabaya binme mesafesini temsil eden Box Collider
    public KeyCode interactionKey = KeyCode.F; // Arabaya binme tuşu
    public GameObject carCamera; // Araba içindeki kamera
    public GameObject outsideCarCamera; // Araba dışındaki kamera
    public GameObject player; // Oyuncu karakteri
    public Transform exitPoint; // Arabadan çıkış noktası

    private bool isInsideCar = false; // Arabanın içinde olup olmadığını belirten flag
    private CharacterController characterController;
    private MeshRenderer playerMeshRenderer;
    private Collider playerCollider;

    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        playerMeshRenderer = player.GetComponent<MeshRenderer>();
        playerCollider = player.GetComponent<Collider>();
    }

    void Update()
    {
        bool canEnterCar = carCollider.GetComponent<Collider>().bounds.Contains(player.transform.position);

        if (canEnterCar && Input.GetKeyDown(interactionKey))
        {
            if (!isInsideCar)
                EnterCar();
            else
                ExitCar();
        }
    }

    void EnterCar()
    {
        isInsideCar = true;

        // Kamera geçişleri
        carCamera.SetActive(true);
        outsideCarCamera.SetActive(false);

        // Oyuncunun karakter controller, mesh renderer ve collider'ını kapat
        characterController.enabled = false;
        playerMeshRenderer.enabled = false;
        playerCollider.enabled = false;

        // Araba kontrol scriptini aktif et
        GetComponent<CarController>().enabled = true;

        // Oyuncuyu aracın içine yerleştir
        player.transform.parent = transform;
        player.transform.localPosition = Vector3.zero;
    }

    void ExitCar()
    {
        isInsideCar = false;

        // Kamera geçişleri
        carCamera.SetActive(false);
        outsideCarCamera.SetActive(true);

        // Oyuncunun karakter controller, mesh renderer ve collider'ını aç
        characterController.enabled = true;
        playerMeshRenderer.enabled = true;
        playerCollider.enabled = true;

        // Araba kontrol scriptini devre dışı bırak
        GetComponent<CarController>().enabled = false;

        // Oyuncuyu aracın dışına yerleştir
        player.transform.position = exitPoint.position;
        player.transform.parent = null;
    }
}

