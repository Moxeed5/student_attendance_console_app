using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    internal class School
    {
        public List<ClassRoom> ClassRoomList { get; set; }

        public School()
        {
            ClassRoomList = new List<ClassRoom>();
        }
    }
}
