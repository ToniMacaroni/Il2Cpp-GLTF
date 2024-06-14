using UnityEngine;

namespace UnityGLTF;

public class SonsUberMap : MetalRoughMap
{
    public SonsUberMap(int maxLod) : base("Sons/Uber", maxLod)
    { }

    public SonsUberMap(string shader, int maxLod) : base(shader, maxLod)
    { }

    public override Texture BaseColorTexture
    {
        get => _material.GetTexture("_BaseColorMap");
        set => _material.SetTexture("_BaseColorMap", value);
    }

    public override Texture NormalTexture
    {
        get => _material.GetTexture("_NormalMap");
        set => _material.SetTexture("_NormalMap", value);
    }
}