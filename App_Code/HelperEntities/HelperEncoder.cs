﻿using System; 
using System.Text; 

/// <summary>
/// Descripción breve de HelperEncoder
/// </summary>
public static class HelperEncoder
{
    public static string Base64Encode(string textToEndode)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(textToEndode);
        return Convert.ToBase64String(plainTextBytes);
    } 
    public static string Base64Decode(string base64EncodedData)
    {
        try
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        catch (Exception)
        {
            return null;
        }
    } 
}