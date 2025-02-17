using UnityEngine;
using Pico.Platform;
using System.Threading.Tasks; // Aseg�rate de importar el namespace del SDK de PICO.
using Unity.XR.PXR;


public class ChangeApp : MonoBehaviour
{
    [SerializeField] string appID;

    void Awake() {
        PXR_Platform.InitializeSDK();
    }

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
            ApplicationOptions options = null; // O crea las opciones seg�n lo que necesites.

            // Llamada a la funci�n LaunchApp de manera as�ncrona.
            Message<string> result = await ApplicationService.LaunchApp(packageName, options).Async();

            // Comprueba el resultado.
            if (string.IsNullOrEmpty(result.Data))
            {
                Debug.LogError($"La aplicaci�n con el paquete '{packageName}' se lanz� exitosamente.");
                //Application.Quit();

            } else
            {
                Debug.LogError($"Error al lanzar la aplicaci�n: {result}");
            }
        } catch (System.Exception ex)
        {
            Debug.LogError($"Ocurri� un error al intentar lanzar la aplicaci�n: {ex.Message}");
        }
    }

    
}
