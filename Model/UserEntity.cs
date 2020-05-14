using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace findaDoctor.Model
{
    public class UserEntity: IdentityUser
    {
        public string firstName { get; set;  }
        public string lastName { get; set;  }
        public string location { get; set;  }
        public string city { get; set;  }
        public string country { get; set;  }
        public string poBox { get; set;  }
        public virtual List<FavoriteDoctor> FavoriteDoctors { get; set; }
        public virtual List<FavoriteArticle> FavoriteArticles { get; set;  }
        
    }
}
