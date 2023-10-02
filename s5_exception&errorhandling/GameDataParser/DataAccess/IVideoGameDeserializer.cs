public interface IVideoGameDeserializer
{
    List<VideoGame> DesirializeFrom(string fileName, string fileContent);
}