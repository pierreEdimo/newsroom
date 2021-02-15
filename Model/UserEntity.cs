using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace newsroom.Model
{
    public class UserEntity : IdentityUser
    {
        public List<Comment> Comments; 
    }
}
