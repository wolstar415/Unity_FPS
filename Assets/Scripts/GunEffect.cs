using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffect : MonoBehaviour
{
    public GameObject fireEffect;


    public void TurnOnFireEffect()
    {
        fireEffect.SetActive(true);
    }
    public void TurnOFFFireEffect()
    {
        fireEffect.SetActive(false);
    }
}
