using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Agile
{
    class Project
    {
        public Project(int idProject, int codeProject)
        {
            this.idProject = idProject;
            this.codeProject = codeProject;
        }

        public int idProject
        {
            get;
            set;
        }
        public int codeProject
        {
            get;
            set;
        }
       
    }
}
