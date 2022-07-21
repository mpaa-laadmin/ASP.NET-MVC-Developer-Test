namespace MVC_WebApp_MPA.Models
{
    public class State
    {
        public string? Name { get; set; }
        public string? Abbreviation { get; set; }
        public string? Capital { get; set; }
        public string? MostPopulousCity { get; set; }
        public long? Population { get; set; }
        public long? SquareMiles { get; set; }
        public string? TimeZone1 { get; set; }
        public string?  TimeZone2 { get; set; }
        public string? Dst { get; set; }
        public bool? IsDst
        {
            get { return !string.IsNullOrEmpty(Dst) && Dst.ToUpper() == "YES" ? true : false ; }
        }

    }
}
