using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeGalleryNamespace;

public class UserImages : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetUserImg()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                DataHolder.sprite = sprite;
            }
        });

    }
}
