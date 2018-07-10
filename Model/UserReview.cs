using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU
{
    public class UserReview
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserRating { get; set; }
        public string UserReviewMessage { get; set; }

        public string UserWearingFeeling { get; set; }
        public string UserGender { get; set; }
        public string UserResidence { get; set; }
        public string UserAge { get; set; }

        public string UserPurchaseSize { get; set; }
        public string UserHeight { get; set; }
        public string UserWeight { get; set; }
        public int UserFootSize { get; set; }

        public static ObservableCollection<UserReview> getUserReview()
        {
            var userReview = new ObservableCollection<UserReview>();

            userReview.Add(new UserReview
            {
                Id = 1,
                Username = "Hana",
                UserRating = "Assets/star.png",
                UserReviewMessage = "I bought a yellow ᴍ size, but I feel a little relaxed with elasticity, I thought that it was good with one size small. It looks high and it is a very feminine silhouette as a float (endurance?).",

                UserWearingFeeling = "Slightly small",
                UserGender = "Female",
                UserResidence = "Seoul",
                UserAge = "Twenty",

                UserPurchaseSize = "M",
                UserHeight = "156 ~ 160",
                UserWeight = "41 ~ 45",
                UserFootSize = 23  
            });
            userReview.Add(new UserReview
            {
                Id = 2,
                Username = "Visal",
                UserRating = "Assets/star.png",
                UserReviewMessage = "I bought a yellow ᴍ size, but I feel a little relaxed with elasticity, I thought that it was good with one size small. It looks high and it is a very feminine silhouette as a float (endurance?).",

                UserWearingFeeling = "Slightly small",
                UserGender = "Female",
                UserResidence = "Seoul",
                UserAge = "Twenty",

                UserPurchaseSize = "M",
                UserHeight = "156 ~ 160",
                UserWeight = "41 ~ 45",
                UserFootSize = 23
            });
            userReview.Add(new UserReview
            {
                Id = 3,
                Username = "Visal",
                UserRating = "Assets/star.png",
                UserReviewMessage = "I bought a yellow ᴍ size, but I feel a little relaxed with elasticity, I thought that it was good with one size small. It looks high and it is a very feminine silhouette as a float (endurance?).",

                UserWearingFeeling = "Slightly small",
                UserGender = "Female",
                UserResidence = "Seoul",
                UserAge = "Twenty",

                UserPurchaseSize = "M",
                UserHeight = "156 ~ 160",
                UserWeight = "41 ~ 45",
                UserFootSize = 23
            });
            userReview.Add(new UserReview
            {
                Id = 4,
                Username = "Hana",
                UserRating = "Assets/star.png",
                UserReviewMessage = "I bought a yellow ᴍ size, but I feel a little relaxed with elasticity, I thought that it was good with one size small. It looks high and it is a very feminine silhouette as a float (endurance?).",

                UserWearingFeeling = "Slightly small",
                UserGender = "Female",
                UserResidence = "Seoul",
                UserAge = "Twenty",

                UserPurchaseSize = "M",
                UserHeight = "156 ~ 160",
                UserWeight = "41 ~ 45",
                UserFootSize = 23
            });
            userReview.Add(new UserReview
            {
                Id = 5,
                Username = "Hana",
                UserRating = "Assets/star.png",
                UserReviewMessage = "I bought a yellow ᴍ size, but I feel a little relaxed with elasticity, I thought that it was good with one size small. It looks high and it is a very feminine silhouette as a float (endurance?).",

                UserWearingFeeling = "Slightly small",
                UserGender = "Female",
                UserResidence = "Seoul",
                UserAge = "Twenty",

                UserPurchaseSize = "M",
                UserHeight = "156 ~ 160",
                UserWeight = "41 ~ 45",
                UserFootSize = 23
            });

            userReview.Add(new UserReview
            {
                Id = 6,
                Username = "Hana",
                UserRating = "Assets/star.png",
                UserReviewMessage = "I bought a yellow ᴍ size, but I feel a little relaxed with elasticity, I thought that it was good with one size small. It looks high and it is a very feminine silhouette as a float (endurance?).",

                UserWearingFeeling = "Slightly small",
                UserGender = "Female",
                UserResidence = "Seoul",
                UserAge = "Twenty",

                UserPurchaseSize = "M",
                UserHeight = "156 ~ 160",
                UserWeight = "41 ~ 45",
                UserFootSize = 23
            });
            userReview.Add(new UserReview
            {
                Id = 7,
                Username = "Hana",
                UserRating = "Assets/star.png",
                UserReviewMessage = "I bought a yellow ᴍ size, but I feel a little relaxed with elasticity, I thought that it was good with one size small. It looks high and it is a very feminine silhouette as a float (endurance?).",

                UserWearingFeeling = "Slightly small",
                UserGender = "Female",
                UserResidence = "Seoul",
                UserAge = "Twenty",

                UserPurchaseSize = "M",
                UserHeight = "156 ~ 160",
                UserWeight = "41 ~ 45",
                UserFootSize = 23
            });
            userReview.Add(new UserReview
            {
                Id = 8,
                Username = "Hana",
                UserRating = "Assets/star.png",
                UserReviewMessage = "I bought a yellow ᴍ size, but I feel a little relaxed with elasticity, I thought that it was good with one size small. It looks high and it is a very feminine silhouette as a float (endurance?).",

                UserWearingFeeling = "Slightly small",
                UserGender = "Female",
                UserResidence = "Seoul",
                UserAge = "Twenty",

                UserPurchaseSize = "M",
                UserHeight = "156 ~ 160",
                UserWeight = "41 ~ 45",
                UserFootSize = 23
            });
            return userReview;
        }







        
            
    }


}
