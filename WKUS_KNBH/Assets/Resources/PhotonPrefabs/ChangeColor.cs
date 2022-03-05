using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private GameObject capsule;

    private Renderer capsuleRenderer;

    private Color newCapsuleColor;
    private float randomChannelOne, randomChannelTwo, randomChannelThree;

    // Start is called before the first frame update
    void Start()
    {
        capsuleRenderer = capsule.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(changecapsuleColor);
    }

  private void changecapsuleColor()
    {
        randomChannelOne = Random.Range(0f, 1f);
        randomChannelTwo = Random.Range(0f, 1f);
        randomChannelThree = Random.Range(0f, 1f);

        newCapsuleColor = new Color(randomChannelOne, randomChannelTwo, randomChannelThree, 1f);
        capsuleRenderer.material.SetColor("_Color", newCapsuleColor);
    }
}
