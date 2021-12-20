using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CharacterGenerator: MonoBehaviour
{
    public CharacterComponents components;
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer hairRenderer;
    public bool updateCharacter = false;
    public UnityEvent renderEvent;

    private int currentBodyIndex = 0;
    private int currentHairIndex = 0;

    void Start()
    {
    }


    void Update()
    {
        if (!updateCharacter)
        {
            if (currentBodyIndex < components.bodyImages.Length)
            {
                if (currentHairIndex < components.hairImages.Length)
                {
                    UpdateSprite(hairRenderer, components.hairImages, ref currentHairIndex);
                    return;
                }
                if (currentBodyIndex != components.bodyImages.Length - 1)
                {
                    UpdateSprite(bodyRenderer, components.bodyImages, ref currentBodyIndex);
                }
            }
        }
    }

    public void startUpdatingSprites()
    {
        updateCharacter = false;
    }

    private void UpdateSprite(SpriteRenderer renderer, Sprite[] images, ref int index)
    {
        renderer.sprite = images[index];
        index++;
        updateCharacter = true;
        renderEvent.Invoke();
    }
}
