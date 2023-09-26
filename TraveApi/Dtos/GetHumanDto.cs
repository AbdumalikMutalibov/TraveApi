using TraveApi.Entity;

namespace TraveApi.Dtos
{
    public class GetHumanDto
    {
        public GetHumanDto(Human entity)
        {
            Id = entity.Id;
            Fullname = entity.Fullname;
            Travelprice = entity. Travelprice;
            Data = entity. Data;
            Age = entity. Age;
            GroupId = entity. GroupId;
            TravelData = entity. TravelData;
        }

        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public double Travelprice { get; set; }
        public DateTime Data { get; set; }
        public string Age { get; set; }
        public int GroupId { get; set; }
        public string TravelData { get; set; }
    }
}
