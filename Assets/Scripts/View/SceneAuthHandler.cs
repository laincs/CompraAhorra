using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;

public class SceneAuthHandler : MonoBehaviour
{
    [Header("Login Ref")]
    public TMP_InputField login_username;
    public TMP_InputField login_password;

    [Header("Register Ref")]
    public TMP_InputField register_username;
    public TMP_InputField register_email;
    public TMP_InputField register_rut;
    public TMP_InputField register_cellphone;
    public TMP_InputField register_password;


    public void TryLogin(){
        AppManager.instance.GoLoadingScene();
        if (login_username.text != "" && login_password.text != ""){
            DBConnection.instance.StartCoroutine(DBConnection.instance.LoginUser(login_username.text, ComputeSHA256Hash(login_password.text)));
        }

    }

    public void TryRegister(){
        AppManager.instance.GoLoadingScene();
        if (register_username.text != "" && register_email.text != "" && register_rut.text != "" && register_cellphone.text != "" && register_password.text != "" ){
            DBConnection.instance.StartCoroutine(DBConnection.instance.RegisterUser(register_username.text, register_rut.text, register_email.text, ComputeSHA256Hash(register_password.text), register_cellphone.text));
        }
    }

    public string ComputeSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convierte la cadena de entrada a bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Calcula el hash SHA-256
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            // Convierte los primeros 10 bytes del hash a una cadena hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Math.Min(10, hashBytes.Length); i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
