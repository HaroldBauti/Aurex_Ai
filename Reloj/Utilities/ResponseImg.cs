using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurex.Utilities
{
    public class ResponseImg
    {
        public class PartImg
        {
            public string text { get; set; }
        }

        public class ContentImg
        {
            public List<PartImg> parts { get; set; }
        }

        public class GenerationConfig
        {
            public List<string> responseModalities { get; set; }
        }

        public class ImageRequest
        {
            public List<ContentImg> contents { get; set; }
            public GenerationConfig generationConfig { get; set; }
        }
        public class ImagePart
        {
            public string data { get; set; } // <- aquí viene el base64
        }

        public class ImageContent
        {
            public string role { get; set; }
            public List<ImagePart> parts { get; set; }
        }

        public class ImageCandidate
        {
            public ImageContent content { get; set; }
        }

        public class ImageResponse
        {
            public List<ImageCandidate> candidates { get; set; }
        }
    }
}
