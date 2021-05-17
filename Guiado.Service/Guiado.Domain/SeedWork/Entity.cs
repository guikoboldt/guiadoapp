namespace Guiado.Domain.SeedWork
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public Entity(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
