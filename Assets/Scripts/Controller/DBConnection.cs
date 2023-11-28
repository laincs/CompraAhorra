using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

public class DBConnection : Instance<DBConnection>
{
    private string url = "https://redoubled-cases.000webhostapp.com/getItems.php";

    void Start()
    {
        StartCoroutine(GetItems());
    }

    IEnumerator GetItems()
    {
        ItemLoader itemLoader = FindAnyObjectByType<ItemLoader>();
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al obtener datos: " + webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                itemLoader.items = JsonHelper.FromJson<Item>(webRequest.downloadHandler.text);
                itemLoader.BuildArrayMenu();
            }
        }
    }

    public IEnumerator GetUserData(string username)
    {
        string url = "https://redoubled-cases.000webhostapp.com/getUserData.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error en la solicitud: " + www.error);
            }
            else
            {
                // Procesar la respuesta
                string responseText = www.downloadHandler.text;
                Debug.Log("Respuesta del servidor: " + responseText);

                AppManager.instance.userData = JsonUtility.FromJson<User>(responseText);
            }
        }
    }

    public IEnumerator LoginUser(string username, string password)
    {
        string phpURL = "https://redoubled-cases.000webhostapp.com/login.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(phpURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al conectar al servidor: " + www.error);
            }
            else
            {
                Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);

                if (www.downloadHandler.text == "1")
                {
                    Debug.Log("Usuario autenticado correctamente.");
                    AppManager.instance.username = username;
                    AppManager.instance.TriggerAuth();
                    StartCoroutine(GetUserData(username));
                }
                else
                {
                    Debug.Log("Usuario no autenticado.");
                }
            }
        }
    }

    public IEnumerator RegisterUser(string username, string run, string email, string password, string phone)
    {
        string phpURL = "https://redoubled-cases.000webhostapp.com/register.php";

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("run", run);
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("phone", phone);

        using (UnityWebRequest www = UnityWebRequest.Post(phpURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al conectar al servidor: " + www.error);
            }
            else
            {
                Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);
                AppManager.instance.username = username;
                AppManager.instance.TriggerAuth();
                StartCoroutine(GetUserData(username));
            }
        }
    }
}