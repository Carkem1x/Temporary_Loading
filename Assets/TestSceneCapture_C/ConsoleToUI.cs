using UnityEngine;
using TMPro;

public class ConsoleToUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI consoleText; // Asigna un TextMeshProUGUI desde el Inspector
    [SerializeField] private int maxLines = 50; // Máximo de líneas que se mostrarán en la UI

    private string errorBuffer = "";

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Filtrar solo los errores y excepciones
        if (type == LogType.Error || type == LogType.Exception)
        {
            string errorEntry = $"[ERROR] {logString}\n{stackTrace}\n";

            // Añade el mensaje al buffer
            errorBuffer += errorEntry;

            // Divide en líneas y corta el excedente
            string[] lines = errorBuffer.Split('\n');
            if (lines.Length > maxLines)
            {
                errorBuffer = string.Join("\n", lines, lines.Length - maxLines, maxLines);
            }

            // Actualiza el texto de la UI
            consoleText.text = errorBuffer;
        }
    }
}
