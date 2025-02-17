using UnityEngine;
using Pico.Platform;
using System.Threading.Tasks; // Asegúrate de importar el namespace del SDK de PICO.


public class ChangeApp : MonoBehaviour
{
    [SerializeField] string appID;

    public void boton()
    {
        System.Threading.Tasks.Task task = LaunchAppByPackageNameAsync(appID);
        task.Start();

        //Application.Quit();
        //System.Threading.Tasks.Task task = LaunchAppByPackageNameAsync("");
    }

    public async System.Threading.Tasks.Task LaunchAppByPackageNameAsync(string packageName)
    {
        try
        {
            // Opcional: Puedes definir opciones de lanzamiento si son necesarias.
            ApplicationOptions options = null; // O crea las opciones según lo que necesites.

            // Llamada a la función LaunchApp de manera asíncrona.
            Message<string> result = await ApplicationService.LaunchAppByAppId(packageName, options).Async();

            // Comprueba el resultado.
            if (string.IsNullOrEmpty(result.Data))
            {
                Debug.Log($"La aplicación con el paquete '{packageName}' se lanzó exitosamente.");
                //Application.Quit();

            } else
            {
                Debug.LogWarning($"Error al lanzar la aplicación: {result}");
            }
        } catch (System.Exception ex)
        {
            Debug.LogError($"Ocurrió un error al intentar lanzar la aplicación: {ex.Message}");
        }
    }

    
}
