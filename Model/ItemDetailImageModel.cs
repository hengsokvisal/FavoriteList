using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU
{
    public class ItemDetailImageModel
    {
        public string image { get; set; }
        public static ObservableCollection<ItemDetailImageModel> getImage()
        {
            var Image = new ObservableCollection<ItemDetailImageModel>();

            for (int i = 1; i < 8; i++)
            {
                Image.Add(new ItemDetailImageModel { image = "Assets/ItemImage/p" + i + ".jpg" });
            }

            return Image;
        }
    }
}
