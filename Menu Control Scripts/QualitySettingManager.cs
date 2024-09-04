
//never used in project
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySettingsManager : MonoBehaviour
{
    public void SetQualityLow()
    {
        QualitySettings.SetQualityLevel(0);  // Low quality preset
        ApplyLowSettings();
    }

    public void SetQualityMedium()
    {
        QualitySettings.SetQualityLevel(2);  // Medium quality preset
        ApplyMediumSettings();
    }

    public void SetQualityHigh()
    {
        QualitySettings.SetQualityLevel(5);  // High quality preset
        ApplyHighSettings();
    }

    void ApplyLowSettings()
    {
        // Example settings for Low Quality
        QualitySettings.globalTextureMipmapLimit = 2;  // Low texture quality
        QualitySettings.shadowCascades = 0;      // No shadow cascades
        QualitySettings.shadowDistance = 50f;    // Reduced shadow distance
        // Disable other effects like Anti-Aliasing, etc.
    }

    void ApplyMediumSettings()
    {
        // Example settings for Medium Quality
        QualitySettings.globalTextureMipmapLimit = 1;  // Medium texture quality
        QualitySettings.shadowCascades = 2;      // Two shadow cascades
        QualitySettings.shadowDistance = 100f;   // Moderate shadow distance
        // Enable moderate effects, etc.
    }

    void ApplyHighSettings()
    {
        // Example settings for High Quality
        QualitySettings.globalTextureMipmapLimit = 0;  // High texture quality
        QualitySettings.shadowCascades = 4;      // Four shadow cascades
        QualitySettings.shadowDistance = 200f;   // Far shadow distance
        // Enable high-end effects like Anti-Aliasing, etc.
    }
}
