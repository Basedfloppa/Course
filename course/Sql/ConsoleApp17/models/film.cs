namespace film.models
{
    internal class film
    {
        public int film_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime release_year { get; set; }
        public int language_id { get; set; }
        public int rental_duration { get; set; }
        public int rental_rate { get; set; }
        public TimeOnly lenght { get; set; }
        public int replacment_cost { get; set; }
        public int rating { get; set; }
        public DateTime last_update { get; set; }
        public string special_features { get; set; }
        public string fulltext { get; set; }
    }
}
