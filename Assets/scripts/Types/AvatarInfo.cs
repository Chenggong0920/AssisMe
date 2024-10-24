using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AvatarInfo
{
    public String avatarName;
    public String description;
    public Sprite icon;
    public Sprite loggedInImage;
    public Sprite chatIcon;
    public AudioClip voice;
}
