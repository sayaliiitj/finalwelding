using UnityEngine;

public class GrabColorChange : MonoBehaviour
{
    public Light directionalLight; // Assign your Directional Light here
    public string targetObjectName = "uploads_files_674670_mask";
    public Color startColor = new Color32(0xE7, 0xEE, 0xBA, 0xFF); // #E7EEBA
    public Color endColor = new Color32(0x00, 0xFF, 0x2E, 0xFF);   // #00FF2E
    public float colorChangeDuration = 1.5f;

    private bool isGrabbed = false;
    private float timer = 0f;

    void Update()
    {
        if (isGrabbed && timer < colorChangeDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / colorChangeDuration);
            directionalLight.color = Color.Lerp(startColor, endColor, t);
        }
    }

    // Simulated grab event — replace with your grab logic
    public void SimulateGrab(GameObject grabbedObj)
    {
        if (grabbedObj.name == targetObjectName)
        {
            isGrabbed = true;
            timer = 0f; // Reset for smooth transition
        }
    }

    // Example trigger event — call SimulateGrab when something enters
    void OnTriggerEnter(Collider other)
    {
        SimulateGrab(other.gameObject);
    }
}
