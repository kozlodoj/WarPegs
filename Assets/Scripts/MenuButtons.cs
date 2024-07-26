using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject storeButton;
    [SerializeField]
    private GameObject cardsButton;
    [SerializeField]
    private GameObject playImage;
    [SerializeField]
    private GameObject storeImage;
    [SerializeField]
    private GameObject cardsImage;

    public void PlayMenu()
    {
        ActivateButtons();
        playButton.SetActive(false);
        DeactivateImages();
        playImage.SetActive(true);
    }
    public void CardsMenu()
    {
        ActivateButtons();
        cardsButton.SetActive(false);
        DeactivateImages();
        cardsImage.SetActive(true);
    }
    public void StoreMenu()
    {
        ActivateButtons();
        storeButton.SetActive(false);
        DeactivateImages();
        storeImage.SetActive(true);

    }
    private void ActivateButtons()
    {
        playButton.SetActive(true);
        cardsButton.SetActive(true);
        storeButton.SetActive(true);
    }
    private void DeactivateImages()
    {
        cardsImage.SetActive(false);
        playImage.SetActive(false);
        storeImage.SetActive(false);
    }
}
