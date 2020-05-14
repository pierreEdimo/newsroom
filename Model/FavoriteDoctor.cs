using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace findaDoctor.Model
{
    public class FavoriteDoctor
    {
        public int Id { get; set;  }
        public string userId { get; set; }
        public int doctorId { get; set;  }
        [JsonIgnore]
        public virtual Doctor Doctor { get; set;  }
        [JsonIgnore]
        public virtual UserEntity UserPatient { get; set;  }
    }
}
