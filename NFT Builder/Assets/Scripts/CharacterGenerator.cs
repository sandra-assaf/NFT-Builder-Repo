using UnityEngine;
using System.Collections;

public class CharacterGenerator: MonoBehaviour
{
    public CharacterComponents components;
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer hairRenderer;
    public BoxCollider2D coll;
    public bool updateCharacter = false;

    private int currentBodyIndex = 0;
    private int currentHairIndex = 0;
    // Use this for initialization
    void Start()
    {
        bodyRenderer.sprite = components.bodyImages[0];
        hairRenderer.sprite = components.hairImages[0];
    }


    // Update is called once per frame
    void Update()
    {

    }
}
