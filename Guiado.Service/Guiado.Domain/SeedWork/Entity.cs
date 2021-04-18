namespace Guiado.Domain.SeedWork
{
    public class Entity
    {
        public int ID { get; protected set; }
        public string Name { get; protected set; }

        public Entity(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
