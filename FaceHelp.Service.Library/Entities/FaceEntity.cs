using System;
using System.Collections.Generic;
using System.Text;

namespace FaceHelp.Service.Library.Entities
{
    public class FaceEntity
    {
        public bbox Bbox { get; set; }
        public List<Emotion> Emotions { get; set; }

        public int Person { get; set; }
    }
    
    // The box that the face is in on the photo
    public class bbox
    {
        public int Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
    }

    public class Emotion
    {
        public double Confidence { get; set; }
        public string Lable { get; set; }
    }
}
