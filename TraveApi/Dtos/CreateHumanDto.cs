﻿namespace TraveApi.Dtos
{
    public class CreateHumanDto
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public double Travelprice { get; set; }
        public DateTime Data { get; set; }
        public string Age { get; set; }
        public int GroupId { get; set; }
        public string TravelData { get; set; }
    }
}
