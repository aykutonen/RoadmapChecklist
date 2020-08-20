using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.Roadmap
{
    public interface IRoadmapService
    {
        void Add(Entity.Roadmap roadmap);
        void Update(Entity.Roadmap roadmap);
        void Delete(int roadmap);

    }
}
