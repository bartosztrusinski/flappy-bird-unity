using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
  public GameObject[] birds;
  private int currentBirdIndex;

  void Start()
  {
    currentBirdIndex = PlayerPrefs.GetInt("CurrentSkinIndex", 0);
    birds[currentBirdIndex].SetActive(true);
  }

}
