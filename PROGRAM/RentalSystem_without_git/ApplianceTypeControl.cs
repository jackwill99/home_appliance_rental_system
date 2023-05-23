using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem
{
    class ApplianceTypeControl
    {
        private String _type, _id;

        public String type
        {
            get { return _type; }
            set { _type = value; }
        }

        public String id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
