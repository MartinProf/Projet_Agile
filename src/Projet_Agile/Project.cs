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
            if (codeProject > 900)
            {
                this.telework = true;
            }
            else
                this.telework = false;
        }

        public int idProject
        {
            get;
        }
        public int codeProject
        {
            get;
        }

        public bool telework
        {
            get;
        }
       
    }
}
