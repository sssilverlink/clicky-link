using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Sprite fullHeart, heart3, heart2, heart1, emptyHeart;

    Image heartImage;

    Player player;


    private void Awake()
    {
        heartImage = GetComponent<Image>();
        player = GetComponent<Player>();
    }

    public void setHeartStatus(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                heartImage.sprite = emptyHeart; 
                break;
            case HeartStatus.Quarter:
                heartImage.sprite = heart1;
                break;
            case HeartStatus.Half:
                heartImage.sprite = heart2;
                break;
            case HeartStatus.ThreeQuarter: 
                heartImage.sprite = heart3;
                break;
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
    }

}

public enum HeartStatus
{
    Empty = 0,
    Quarter = 1,
    Half = 2,
    ThreeQuarter = 3,
    Full = 4,
}