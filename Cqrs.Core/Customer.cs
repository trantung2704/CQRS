namespace Cqrs.Core
{
    public class Customer
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, Location: {2}", Id, Name, Location);
        }
    }
}