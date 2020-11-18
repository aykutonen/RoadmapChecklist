namespace Entity
{
    public class RoadmapCopy
    {
        public int SourceId { get; set; }
        public int TargetId { get; set; }


        // Relations
        public virtual Roadmap SourceRoudmap { get; set; }
        public virtual Roadmap TargetRoadmap { get; set; }
    }
}
