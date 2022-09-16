using Resco.ImageManager;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace iNTrack
{
    [DebuggerNonUserCode]
    internal class imgManager
    {
        private static ImageManager _imageManager;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ImageManager ImageManager
        {
            get
            {
                if (object.ReferenceEquals(imgManager._imageManager, null))
                {
                    imgManager._imageManager = new ImageManager(typeof(imgManager));
                }
                return imgManager._imageManager;
            }
        }

        internal imgManager()
        {
        }

        internal static Bitmap GetImage(string name)
        {
            return imgManager.ImageManager.GetImage(name);
        }

        internal static void Unload()
        {
            if (!object.ReferenceEquals(imgManager._imageManager, null))
            {
                imgManager._imageManager.Collect(true);
                imgManager._imageManager.Dispose();
            }
            imgManager._imageManager = null;
        }
    }
}