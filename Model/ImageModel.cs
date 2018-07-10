using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU
{
    public class ImageModel
    {
        public string Image { get; set; }
        public int id { get; set; }
        public static ObservableCollection<ImageModel> GetImage()
        {
            var image = new  ObservableCollection<ImageModel>();
            var path = "Assets/";
            var path_ugc = "Assets/UGC/img_";
            var extension = ".jpg";

            /* for (int i = 1; i < 11; i++)
             {
                 if( i % 2 != 0)
                 {
                     image.Add(new ImageModel { Image = path + i + extension, id = i });
                 }
                 else
                 {
                     image.Add(new ImageModel { Image = path_ugc + i + extension, id = i });
                 }

             }
             */

            for (int i = 1; i < 11; i++)
            {
                image.Add(new ImageModel { Image = path + i + extension, id = i });
            }

            return image;
        }
    }
}
