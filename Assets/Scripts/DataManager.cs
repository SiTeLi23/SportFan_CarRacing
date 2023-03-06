using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        #region
        if (instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        #endregion
    }

    // Test JSON String
    string json = "{\n   \"accentColor\": \"#FBFBFB\",\n   \"avatar\": \"https://sportzfan.s3.ap-southeast-2.amazonaws.com/game/7ca43eef-ed08-46e9-b196-e839d5a20dd8.png\",\n   \"backgroundColor\": \"#1A1E23\",\n   \"kudos\": \"17415\",\n   \"lifeCount\": 5,\n   \"refreshAmount\": 5,\n   \"refreshTime\": 5,\n   \"sponsorLogo\": \"https://sportzfan.s3.ap-southeast-2.amazonaws.com/sponsor/201ee6e8-5f43-4ca3-8a66-561f64275683.png\",\n   \"sponsorTitle\": \"Zambrero\",\n   \"teamName\": \"AG Nation (Adelaide Giants)\",\n   \"textColor\": \"#CED2D6\",\n   \"title\": \"minigame title 0001\",\n   \"type\": 4,\n   \"userId\": \"f74b8667-8e69-4570-bdda-ef39e7d6502c\"\n}";

    public void DeserialiseParameters(string? _json)
    {
        string inputJson = json;
        if (_json != null)
        {
            inputJson = _json;
        };
       var gameData = JsonUtility.FromJson<GameData>(inputJson);
        Debug.Log(gameData.type);
        // Get Sprites, Convert Colors
       var branding = new GameBranding();
        branding.backgroundColor = hexToColor(gameData.backgroundColor);
        branding.accentColor = hexToColor(gameData.accentColor);
        branding.textColor = hexToColor(gameData.textColor);
        StartCoroutine(GetSpriteFromURL(gameData.avatar, (Sprite x) => {
            branding.avatarSprite = x;
            StartCoroutine(GetSpriteFromURL(gameData.sponsorLogo, (Sprite x) => {
                branding.logoSprite = x;
                //GameObject.Find("LoadingPanel").GetComponent<LoadingScreen>().ShowMenu();
            }));
        }));
    }

    public string GetSceneName()
    {
        return null;
        //return gameMap[gameData.type];
    }

    public IEnumerator GetSpriteFromURL(string url, Action<Sprite> callback)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        Texture2D texture = DownloadHandlerTexture.GetContent(www);
        Sprite webSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        callback(webSprite);
    }

    public Color hexToColor(string hexString)
    {
        Color newCol;
        if (ColorUtility.TryParseHtmlString(hexString, out newCol))
        {
            return newCol;
        }
        else
        {
            return Color.white;
        }
    }
}
