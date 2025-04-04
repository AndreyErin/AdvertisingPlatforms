namespace Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override bool Equals(object? obj)
        {
            if(Name == (obj as Location)?.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
