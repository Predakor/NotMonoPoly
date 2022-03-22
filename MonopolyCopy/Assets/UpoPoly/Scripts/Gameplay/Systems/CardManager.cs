using TMPro;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] GameObject buyCard;
    [SerializeField] GameObject detailsCard;

    [SerializeField] TextMeshProUGUI tileName;
    [SerializeField] TextMeshProUGUI tileOwner;
    [SerializeField] TextMeshProUGUI tileBasePrice;
    [SerializeField] TextMeshProUGUI tileUpgrades;
    [SerializeField] TextMeshProUGUI tileValue;


    public void ShowBuyCard(Tile tile) => ShowCard(buyCard, tile);
    public void ShowDetailsCard(Tile tile) => ShowCard(detailsCard, tile);
    public void HideBuyCard() => buyCard.SetActive(false);
    public void HideDetailsCard() => detailsCard.SetActive(false);

    void ShowCard(GameObject card, Tile tile)
    {
        card.SetActive(true);
        UpdateStats(tile);
    }

    void UpdateStats(Tile tile)
    {
        string owner = "none";

        if (tile.Owner != null)
            owner = tile.Owner.name;

        string name = tile.Name;
        string basePrice = tile.BasePrice.ToString();
        string upgrades = tile.Upgrades.ToString();
        string value = tile.Value.ToString();

        tileName.SetText(name);
        tileOwner.SetText($"Owner: {owner}");
        tileBasePrice.SetText($"Base Price: {basePrice}");
        tileUpgrades.SetText($"All Houses: {upgrades}");
        tileValue.SetText($"Total Value: {value}");
    }

}