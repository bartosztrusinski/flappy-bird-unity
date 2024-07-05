using UnityEngine;

public class Shop : MonoBehaviour
{
  public GameObject[] skinTiers;
  public GameObject nextButton;
  public GameObject previousButton;

  private int currentTier = 0;

  void Start()
  {
    skinTiers[currentTier].SetActive(true);
    previousButton.SetActive(false);
  }

  public void ShowNextTier()
  {
    skinTiers[currentTier].SetActive(false);

    currentTier++;
    skinTiers[currentTier].SetActive(true);

    if (IsLastTier())
    {
      nextButton.SetActive(false);
    }

    previousButton.SetActive(true);
  }

  public void ShowPreviousTier()
  {
    skinTiers[currentTier].SetActive(false);

    currentTier--;
    skinTiers[currentTier].SetActive(true);

    if (IsFirstTier())
    {
      previousButton.SetActive(false);
    }

    nextButton.SetActive(true);
  }

  public bool IsLastTier()
  {
    return currentTier == skinTiers.Length - 1;
  }

  public bool IsFirstTier()
  {
    return currentTier == 0;
  }
}
