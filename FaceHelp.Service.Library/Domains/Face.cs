using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Algorithmia;
using FaceHelp.Service.Library.Entities;

namespace FaceHelp.Service.Library.Domains
{
    public class Face
    { 

        public Face Anylize(string imgPath)
        {
            //Analize the face with the Algoriuthma API
            FaceEntity faceEntity = new FaceEntity();

            var input = "{" + "  \"image\": \"" + imgPath + "\"," + "  \"numResults\": 7" + "}";
            var client = new Client("simafd3ZGca0t3jUV8FvJelbN881");
            var algorithm = client.algo("deeplearning/EmotionRecognitionCNNMBP/1.0.1");
            algorithm.setOptions(timeout: 300);
            var response = algorithm.pipeJson<object>(input);
            return JsonSerializer.Deserialize<Face>(response.result.ToString(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
        }
    }
}