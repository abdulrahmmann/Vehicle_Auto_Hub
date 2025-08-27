namespace VehicleAutoHub.Domain;

public class ImagesValueConverter : ValueConverter<List<string>, string>
{
    public ImagesValueConverter() :
        base(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),   // To DB
            v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>() // From DB
        )
    { }
}
