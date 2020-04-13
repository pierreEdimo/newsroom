namespace findaDoctor.QueryClasses
{
    public class DoctorQueryParameter : QueryParameters
    {
        public string city { get; set; }
        public string country { get; set; }
        public string specialisation { get; set; }
        public string name { get; set; }
    }
}