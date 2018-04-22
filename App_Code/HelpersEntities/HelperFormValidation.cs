using System; 

/// <summary>
/// Descripción breve de HelperFormValidation
/// </summary>
public static class HelperFormValidation
{
    public static bool IsValidFormData(ModelContacto datosContacto)
    {
        try
        {
            if (datosContacto != null)
            {
                if (string.IsNullOrEmpty(datosContacto.Email))
                {
                    return false;
                }
                else if (string.IsNullOrEmpty(datosContacto.NombreCompleto))
                {
                    return false;
                }
                else if (string.IsNullOrEmpty(datosContacto.Asunto))
                {
                    return false;
                }
                else if (string.IsNullOrEmpty(datosContacto.Mensaje))
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }

    }
}