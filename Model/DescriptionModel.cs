using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU
{
    public class DescriptionModel
    {
        public string ItemDescription { get; set; }
        public string Material { get; set; }
        public string Specification { get; set; }
        public string Handling { get; set; }
       

        public static ObservableCollection<DescriptionModel> GetDescriptionModels()
        {
            var Description = new ObservableCollection<DescriptionModel>();
            Description.Add(new DescriptionModel
            {
                ItemDescription = "It is a skirt using cotton material with a sense of tension. It is reasonable with a sense of coming off with a length setting not too long. It is an outstanding compatibility item with earth tops and outerwear. (XS, XXL size will be sold only at online store)",
                Material = "Surface: 100% cotton, lining: 100% polyester",
                Specification = "Waist: back rubber included (not adjustable), lined",
                Handling = "Please note that this product will transfer color to other things due to moist condition due to sweat, rain etc, or friction. Please avoid combinations with light colors " +
                "(sofa, shoes, bags, car seat etc). Because it fades, please avoid washing with other things (especially white, light color). Please use a detergent that does not contain fluorescent whitening " +
                "agent for production / light color. Please avoid immersion in water for a long time. After washing please prepare the shape promptly and please shade. Please avoid using the dryer after washing." +
                " When ironing, please use a cloth." + "Please note that this product will transfer color to other things due to moist condition due to sweat,rain etc,or friction.Please avoid " +
                "combinations with light colors(sofa, shoes, bags, car seat etc).Because it fades,please avoid washing with other things(especially white, light color).Please use a detergent that does " +
                "not contain fluorescent whitening agent for production / light color.Please avoid immersion in water for a long time.After washing please prepare the shape promptly and please shade.Please " +
                "avoid using the dryer after washing. When ironing, please use a cloth.Please note that this product will transfer color to other things due to moist condition due to sweat, rain etc, or friction. Please avoid combinations with light colors " +
                "(sofa, shoes, bags, car seat etc). Because it fades, please avoid washing with other things (especially white, light color). Please use a detergent that does not contain fluorescent whitening " +
                "agent for production / light color. Please avoid immersion in water for a long time. After washing please prepare the shape promptly and please shade. Please avoid using the dryer after washing." +
                " When ironing, please use a cloth." + "Please note that this product will transfer color to other things due to moist condition due to sweat,rain etc,or friction.Please avoid " +
                "combinations with light colors(sofa, shoes, bags, car seat etc).Because it fades,please avoid washing with other things(especially white, light color).Please use a detergent that does " +
                "not contain fluorescent whitening agent for production / light color.Please avoid immersion in water for a long time.After washing please prepare the shape promptly and please shade.Please " +
                "avoid using the dryer after washing. When ironing, please use a cloth."
            });
         
            return Description;
        }
    }
}
