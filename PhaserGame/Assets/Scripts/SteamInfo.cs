using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Steamworks;
using UnityEngine.UI;

public class SteamInfo : MonoBehaviour
{
    public Image avatarImage;
    public TextMeshProUGUI profile;

    // Start is called before the first frame update
    void Start()
    {
        profile.text = SteamFriends.GetPersonaName();
        StartCoroutine(_FetchAvatar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int avatarInt;
    uint width, height;
    Texture2D downloadedAvatar;
    Rect rect = new Rect(0, 0, 184, 184);
    Vector2 pivot = new Vector2(0.5f, 0.5f);
    IEnumerator _FetchAvatar()
    {
        avatarInt = SteamFriends.GetLargeFriendAvatar(SteamUser.GetSteamID());

        while(avatarInt == -1)
        {
            yield return null;
        }

        if(avatarInt > 0)
        {
            SteamUtils.GetImageSize(avatarInt, out width, out height);

            if(width > 0 && height > 0)
            {
                byte[] avatarStream = new byte[4 * (int)width * (int)height];
                SteamUtils.GetImageRGBA(avatarInt, avatarStream, 4 * (int)width * (int)height);
                downloadedAvatar = new Texture2D((int)width, (int)height, TextureFormat.RGBA32, false);
                downloadedAvatar.LoadRawTextureData(avatarStream);
                downloadedAvatar.Apply();
                avatarImage.sprite = Sprite.Create(downloadedAvatar, rect, pivot);
            }
        }
    }
}
