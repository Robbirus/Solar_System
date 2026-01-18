using UnityEngine;
using UnityEngine.UI;

public class SunUIController : MonoBehaviour
{
    [SerializeField] private Renderer sunRenderer;

    [Header("UI Sliders")]
    [SerializeField] private Slider cellDensitySlider;
    [SerializeField] private Slider solarFlaresSlider;
    [SerializeField] private Slider cellSpeedSlider;
    [SerializeField] private Slider baseColorSlider;
    [SerializeField] private Slider cellColorSlider;

    [Header("HDR Colors")]
    [SerializeField] private Color baseColorA = new Color(2f, 0.5f, 0f); // HDR orange
    [SerializeField] private Color baseColorB = new Color(5f, 2f, 0f);   // HDR jaune intense
    [SerializeField] private Color cellColorA = new Color(1f, 0f, 0f);   // HDR rouge
    [SerializeField] private Color cellColorB = new Color(0f, 1f, 1f);   // HDR cyan

    private Material runtimeMat;

    private void Awake()
    {
        runtimeMat = sunRenderer.material;
    }

    private void Start()
    {
        // float sliders
        cellDensitySlider.onValueChanged.AddListener(SetCellDensity);
        solarFlaresSlider.onValueChanged.AddListener(SetSolarFlares);
        cellSpeedSlider.onValueChanged.AddListener(SetCellSpeed);

        // HDR color sliders
        baseColorSlider.onValueChanged.AddListener(SetBaseColor);
        cellColorSlider.onValueChanged.AddListener(SetCellColor);

        // Initialize update
        SetBaseColor(baseColorSlider.value);
        SetCellColor(cellColorSlider.value);
    }

    public void SetCellDensity(float value)
    {
        runtimeMat.SetFloat("_CellDensity", value);
    }

    public void SetSolarFlares(float value)
    {
        runtimeMat.SetFloat("_SolarFlares", value);
    }

    public void SetCellSpeed(float value)
    {
        runtimeMat.SetFloat("_CellSpeed", value);
    }

    // HDR Color Interpolation
    public void SetBaseColor(float t)
    {
        Color color = Color.Lerp(baseColorA, baseColorB, t);
        runtimeMat.SetColor("_BaseColor", color);
    }

    public void SetCellColor(float t)
    {
        Color color = Color.Lerp(cellColorA, cellColorB, t);
        runtimeMat.SetColor("_CellColor", color);
    }
}
