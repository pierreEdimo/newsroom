using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace findaDoctor.Model
{
    public class UserEntity: IdentityUser
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Firstname")]
        public string firstName { get; set;  }
        [Required]
        [MaxLength(50)]
        [DisplayName("Lastname")]
        public string lastName { get; set;  }
        [MaxLength(255)]
        [DisplayName("Current Living address")]
        public string location { get; set;  }
        [MaxLength(255)]
        [DisplayName("Current City")]
        public string city { get; set;  }
        [MaxLength(255)]
        [DisplayName("Current living Country")]
        public string country { get; set;  }
        [MaxLength(50)]
        [DisplayName("Postal Box")]
        public string poBox { get; set;  }
        public virtual List<FavoriteDoctor> FavoriteDoctors { get; set; }
        public virtual List<FavoriteArticle> FavoriteArticles { get; set;  }
        
    }
}
