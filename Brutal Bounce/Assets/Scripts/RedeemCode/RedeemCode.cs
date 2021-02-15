using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Networking;
using UnityEngine.UI;


public class RedeemCode : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;

    [SerializeField] GameObject errorText;
    [SerializeField] GameObject rewardPanel;

    [SerializeField] ShopGetter shopGetter;
    [SerializeField] InventoryHandler inventoryHandler;
    [SerializeField] Image itemImageToShow;

    Sprite currentItemToShow = null;

    private bool nextReward = false;

    void Start()
    {
        errorText.SetActive(false);
        rewardPanel.SetActive(false);
    }

    public void SubmitCode()
    {
        errorText.SetActive(false);
        var request = new RedeemCouponRequest { CouponCode = inputField.text };
        PlayFabClientAPI.RedeemCoupon(request, RedeemCouponSuccess, RedeemCouponError);
    }

    private void RedeemCouponSuccess(RedeemCouponResult result)
    {
        Debug.Log("code");
        inputField.text = "";
        StartCoroutine(ShowRewardsCoroutine(result.GrantedItems));

    }

    private IEnumerator ShowRewardsCoroutine(List<ItemInstance> items)
    {
        Debug.Log("Code redeemed " + items.Count);
        foreach (ItemInstance item in items)
        {
            ItemPackage itemPackage = new ItemPackage();
            ItemUsefulTools.ItemType itemType = ItemUsefulTools.GetItemType(item.ItemClass);
            itemPackage.PackageSetup(shopGetter.GetCatalogItemFromID(item.ItemId), itemType, false);

            if (!inventoryHandler.ItemInInventory(itemPackage))
            {
                rewardPanel.SetActive(true);
                CatalogItem catalogItem = shopGetter.GetCatalogItemFromID(item.ItemId);

                StartCoroutine(DownloadImage(catalogItem.ItemImageUrl));
                yield return new WaitWhile(() => currentItemToShow == null);

                itemImageToShow.sprite = currentItemToShow;

                yield return new WaitUntil(() => nextReward == true);
                nextReward = false;
                currentItemToShow = null;
            }
        }
        rewardPanel.SetActive(false);
        LoadManager.Instance.ChangeSceneWithLoading("ShopScene");
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            currentItemToShow = sprite;
        }
    }

    private void RedeemCouponError(PlayFabError error)
    {
        errorText.SetActive(true);
    }

    public void RewardPanelClicked()
    {
        nextReward = true;
    }
}
