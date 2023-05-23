using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RentalSystem
{
    class ApplianceControl
    {

        public String applianceStorageLocation
        {
            get
            {

                String baseFolder = General.baseFolder;
                String path = Path.GetDirectoryName(baseFolder);
                String applianceDir = Path.Combine(path, "Appliance");
                Random rnd = new Random();
                int fileName = rnd.Next(100000);

                if (!Directory.Exists(applianceDir))
                {
                    Directory.CreateDirectory(applianceDir);
                }
                return Path.Combine(applianceDir, fileName.ToString() + ".jpg");
            }
        }

        private String _id, _name, _photo, _annualCost, _monthlyCost, _model, _dimension, _color, _applianceType, _quentity, _energyConsumption, _powerUsage, _typicalUsage;

        public String photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public String energyConsumption
        {
            get { return _energyConsumption; }
            set { _energyConsumption = value; }
        }

        public String quentity
        {
            get { return _quentity; }
            set { _quentity = value; }
        }

        public String applianceType
        {
            get { return _applianceType; }
            set { _applianceType = value; }
        }

        public String color
        {
            get { return _color; }
            set { _color = value; }
        }

        public String dimension
        {
            get { return _dimension; }
            set { _dimension = value; }
        }

        public String model
        {
            get { return _model; }
            set { _model = value; }
        }

        public String monthlyCost
        {
            get { return _monthlyCost; }
            set { _monthlyCost = value; }
        }

        public String annualCost
        {
            get { return _annualCost; }
            set { _annualCost = value; }
        }

        public String name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String powerUsage
        {
            get { return _powerUsage; }
            set { _powerUsage = value; }
        }

        public String typicalUsage
        {
            get { return _typicalUsage; }
            set { _typicalUsage = value; }
        }



    }
}
