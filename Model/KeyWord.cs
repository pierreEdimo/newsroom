using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class KeyWord
    {
      
        public int Id { get; set;  }
        public String UserId { get; set;  }
        public String Word { get; set;  }
    }
}
