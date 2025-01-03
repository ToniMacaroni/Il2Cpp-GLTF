

using GLTF.Schema;
using RedLoader;
using UnityEngine;
using UnityGLTF.Cache;

namespace UnityGLTF.Plugins
{
    public class HdrpTexImport: GLTFImportPlugin
    {
        public override string DisplayName => "MSFT_HDRP_TexImport";
        public override string Description => "Converts textures for use with HDRP.";
        public override GLTFImportPluginContext CreateInstance(GLTFImportContext context)
        {
            return new HDRPTexImportContext();
        }
    }
    
    public class HDRPTexImportContext: GLTFImportPluginContext
    {
        public override void OnAfterImportTexture(GLTFTexture texture, int textureIndex, TextureCacheData texData)
        {
            if (!texData.IsNormal)
                return;

            var tex = texData.Texture;
                
            var pixels = tex.GetPixels();
            for (var i = 0; i < pixels.Length; i++)
            {
                var c = pixels[i];
                pixels[i] = new Color(1, c.g, 1, c.r);
            }
            tex.SetPixels(pixels);
            tex.Apply();
        }
    }
}