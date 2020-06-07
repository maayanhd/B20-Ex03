using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public class License
    {

        private eLicenseType? m_ELicenseType;



        public enum eLicenseType
        {
            A,
            A1,
            Aa,
            B
        }

        public static bool TryParse(string i_LicenseType,out License o_License)
        {
            bool isValid = false;
            o_License = null;
            foreach (string type in Enum.GetNames(typeof(eLicenseType)))
            {
                isValid = i_LicenseType.Equals(type);
                if (isValid == true)
                {
                    o_License= new License();
                    o_License.m_ELicenseType = (eLicenseType)(Enum.Parse(typeof(eLicenseType), i_LicenseType));
                    break;
                }
            }

            return isValid;
        }

        public eLicenseType? LicenseType
        {
            get
            {
                return m_ELicenseType;
            }

            set
            {
                m_ELicenseType = value;
            }

        }
        public override string ToString()
        {
            return  m_ELicenseType.ToString();
        }
    }
}
