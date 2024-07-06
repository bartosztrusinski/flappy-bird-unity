using UnityEngine;

public class Coin : MonoBehaviour
{
  private int random;
  private Vector3 position;

  public AudioSource coinSound;

  private void OnTriggerEnter(Collider other)
  {
    gameObject.SetActive(false);
    coinSound.Play();
  }

  void Update()
  {
    transform.Rotate(Vector3.forward, 100.0F * Time.deltaTime);
  }

  private void Start()
  {
    random = Random.Range(1, 8);
    position = transform.position;

    if (random < 4)
    {
      gameObject.SetActive(false);
    }

    switch (random)
    {
      case 4:
        position.z += 3;
        break;
      case 5:
        position.z -= 3;
        break;
      case 6:
        position.z = position.y + 1;
        break;
      case 7:
        position.z = position.y - 1;
        break;
    }
  }
}

