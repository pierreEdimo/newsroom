using Microsoft.AspNetCore.Mvc;
using newsroom.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class AddFavoriteDTO
    {
        [Required]
        public String OwnerId { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        [Required]
        public int ArticleId { get; set; }
    }
}
