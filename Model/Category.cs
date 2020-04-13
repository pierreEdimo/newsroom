using System;
using System.Collections.Generic;

namespace findaDoctor.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string name { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
    }
}