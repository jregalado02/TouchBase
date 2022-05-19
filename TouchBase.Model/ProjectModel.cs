using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TouchBase.Model
{
    public class ProjectModel
    {
        public int ProjectModelId { get; set; }

        public string Name { get; set; }

        public bool IsDone { get; set; }

        public string Description { get; set; }

        public string Approximation { get; set; }

        public int ProjectCollectionModelId { get; set; }

        public ProjectCollectionModel ProjectCollectionModel { get; set; }
    }
}