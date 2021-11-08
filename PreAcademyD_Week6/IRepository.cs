using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreAcademyD_Week6
{
    public interface IRepository
    {
        public bool Add();
        public bool Delete();
        public bool GetAll();
        public bool Update();

    }
}
