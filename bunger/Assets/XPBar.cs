using UnityEngine;
using UnityEngine.UI;
public class XP : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetNeedXP(int XP)
    {
        slider.maxValue = XP;
        slider.value = XP;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetXP(int XP)
    {
        slider.value = XP;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
