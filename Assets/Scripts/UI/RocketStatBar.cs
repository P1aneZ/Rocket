using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketStatBar : MonoBehaviour
{
    public Image healthImage;

    public Image healthDelayImage;

    private void Update()
    {
        if (healthDelayImage.fillAmount > healthImage.fillAmount)
        {
            healthDelayImage.fillAmount-=Time.deltaTime*0.25f;//ºìÑª×·ËæÐ§¹û
        }
    }


    public void OnHealthChange(float persentage)
    {
        healthImage.fillAmount = persentage;
    }

}
