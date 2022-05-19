using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchBase.Model
{
    public class ProjectCollectionModel
    {
        public int ProjectCollectionModelId { get; set;}

        public string CompanyName { get; set;}

        public List<ProjectModel> ProjectModels { get; set;}
    }
}
 