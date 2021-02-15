using Microsoft.AspNetCore.Mvc;
using newsroom.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class AddFavoriteDTO
    {
        public String OwnerId { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public int ArticleId { get; set; }
    }
}
