using System;

namespace AppVerse.Jewel.Entities
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ImagePathAttribute  : Attribute
    {
        public ImagePathAttribute(string imageName)
        {
            ImageDescription = imageName;
        }
        //
        // Summary:
        //     Gets the description stored in this attribute.
        //
        // Returns:
        //     The description stored in this attribute.
        public string ImageDescription { get; }
    }
}