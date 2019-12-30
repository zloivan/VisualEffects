using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particleSystems;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private RectTransform rootForButtons;

    [SerializeField] private ParticleSystem[] group;
    private Button[] listOfButtons;

    void Start()
    {
        InstantiateButtons();
    }

    private void InstantiateButtons()
    {
        var numberOfParticleSystem = particleSystems.Length;

        if (numberOfParticleSystem != 0)
        {
            listOfButtons = new Button[numberOfParticleSystem];
            for (var i = 0; i < numberOfParticleSystem; i++)
            {
                var ps = particleSystems[i];
                var newButton = Instantiate(buttonPrefab, rootForButtons);
                newButton.GetComponentInChildren<Text>().text = particleSystems[i].gameObject.name;
            
                newButton.onClick.AddListener(() =>
                    {
                        if (ps.isEmitting)
                        {
                            ps.Stop();
                        }
                        else
                        {
                            ps.Play(); 
                        }
                    
                    }
                );
                listOfButtons[i] = newButton; 
            }
        }

        var lengthOfGrou = group.Length;
        if (group != null && lengthOfGrou != 0)
        {
            var groupButton = Instantiate(buttonPrefab, rootForButtons);
            groupButton.GetComponentInChildren<Text>().text = "Group";
            groupButton.onClick.AddListener(() =>
                {
                    for (int i = 0; i < lengthOfGrou; i++)
                    {
                        group[i].Play();
                    }
                }
            );
            
        }
    }
}
