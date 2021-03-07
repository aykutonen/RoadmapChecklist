using System;

public class Roadmap
{
    public virtual Guid Id { get; protected set; }
    public virtual Guid UserId { get; protected set; }

    private List<RoadmapItem> RoadmapItems = new List<RoadmapItem();

    public static Roadmap Create(User user)
    {
        if (customer == null)
            throw new ArgumentNullException("user");

        Roadmap roadmap = new Roadmap();
        roadmap.Id = Guid.NewGuid();
        roadmap.RoadmapId = user.Id;

        DomainEvents.Raise<RoadmapCreated>(new RoadmapCreated() { Roadmap = roadmap });

        return roadmap;
    }

    public virtual void Add(RoadmapItem roadmapItem)
    {
        if (roadmapItem == null)
            throw new ArgumentNullException();

        DomainEvents.Raise<ItemAddedRoadmap>(new ItemAddedRoadmap() { RoadmapItem = roadmapItem });

        this.RoadmapItems.Add(roadmapItem);
    }
}
