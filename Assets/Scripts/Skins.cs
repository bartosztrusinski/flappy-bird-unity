using System.Linq;
using UnityEngine;

public class Skins : MonoBehaviour
{
  private int currentSkinIndex;
  private int[] unlockedSkinIndices;
  private readonly int[] skinCosts = { 0, 100, 100, 100, 400, 400, 999, 999, 999 };
  private int buyingSkinIndex = -1;

  public Shop shop;
  public GameObject[] selectedButtons;
  public GameObject[] selectButtons;
  public GameObject unlockPrompt;
  public GameObject noCoinsPrompt;

  void Start()
  {
    currentSkinIndex = PlayerPrefs.GetInt("CurrentSkinIndex", 0);
    unlockedSkinIndices = PlayerPrefs.GetString("UnlockedSkinIndices", "0")
      .Split(',')
      .Select(int.Parse)
      .ToArray();

    UpdateButtons();
  }

  private void UpdateButtons()
  {
    for (int skinIndex = 0; skinIndex < selectedButtons.Length; skinIndex++)
    {
      selectedButtons[skinIndex].SetActive(skinIndex == currentSkinIndex);
      selectButtons[skinIndex].SetActive(IsSkinUnlocked(skinIndex));
    }
  }

  public void SetCurrentSkin(int index)
  {
    currentSkinIndex = index;
    PlayerPrefs.SetInt("CurrentSkinIndex", currentSkinIndex);
    UpdateButtons();
  }

  public void UnlockSkin()
  {
    if (buyingSkinIndex == -1) return;

    unlockedSkinIndices = unlockedSkinIndices.Append(buyingSkinIndex).ToArray();
    PlayerPrefs.SetString("UnlockedSkinIndices", string.Join(",", unlockedSkinIndices));
    shop.UseCoins(skinCosts[buyingSkinIndex]);
    buyingSkinIndex = -1;
    UpdateButtons();
  }

  public void PromptUnlockSkin(int index)
  {
    buyingSkinIndex = index;

    if (shop.GetCoins() < skinCosts[index])
    {
      noCoinsPrompt.SetActive(true);
    }
    else
    {
      unlockPrompt.SetActive(true);
    }

  }

  public bool IsSkinUnlocked(int index)
  {
    return unlockedSkinIndices.Contains(index);
  }
}
