using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace findaDoctor.DTO
{
    public class DoctorDTO { 
    
        public int Id { get; set; }
        public string name { get; set;  }
        public string category { get; set; }
        public string description { get; set;  }
        public DateTime createdAt { get; set;  }
        public string city { get; set;  }
        public string country { get; set;  }
        public string address { get; set; }
        public int poBox { get; set;  }
        public string email { get; set; }
        public string teleFonNumber { get; set; }
    }
}
