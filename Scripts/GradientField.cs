using UnityEngine;
using UnityEngine.UI;

public class GradientField : MonoBehaviour
{
    public Gradient gradient;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        
        if (image == null)
        {
            Debug.LogError("No Image component found on GameObject!");
            return;
        }
        
        // show init gradient if one has not been set
        if (gradient == null)
        {
            gradient = new Gradient();
            gradient.colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(Color.red, 0),
                new GradientColorKey(Color.blue, 0.5f),
                new GradientColorKey(Color.green, 1)
            };
        }
        
        ApplyGradient();
    }

    void ApplyGradient()
    {
        if (image == null) return;
        
        // make a gradient texture
        Texture2D texture = new Texture2D(256, 1);
        texture.wrapMode = TextureWrapMode.Clamp;
        for (int i = 0; i < 256; i++)
        {
            texture.SetPixel(i, 0, gradient.Evaluate(i / 255f));
        }
        texture.Apply();
        
        // create a sprite from  texture
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 256, 1), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;
        image.type = Image.Type.Simple;
    }

    void Update()
    {
        
    }
}