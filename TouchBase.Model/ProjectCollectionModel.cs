using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchBase.Model
{
    public class ProjectCollectionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProjectModel> Projects { get; set; }
    }
}
