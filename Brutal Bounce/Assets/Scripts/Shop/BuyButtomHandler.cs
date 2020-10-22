using UnityEngine;

public class BuyButtomHandler : MonoBehaviour
{
    [SerializeField] ItemList itemList;
    [SerializeField] GameObject buttomPrefab;

    void Start()
    {
        foreach (GameObject item in itemList.items)
        {
            GameObject currentButton = Instantiate(buttomPrefab, transform);
            ItemButton button = currentButton.GetComponent<ItemButton>();
            IItem convertedItem = item.GetComponent<IItem>();
            button.previewImage.sprite = convertedItem.ShopImage;
            button.priceText.text = convertedItem.Price.ToString();
        }
    }

}