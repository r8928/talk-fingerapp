using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkUareU
{
    class rowItem
    {
        public string check_in;
        public string check_out;

        public string user_id;
        public string location_id;
        public string role_id;
        public string btnevent;

        public string ip_in;
        public string ip_out;

        // public string Name;
        // public string DName;
        // public string Lunch_out;
        // public string Lunch_in;
        public string Status;


        public rowItem(string ID, string LOCATION, string ROLE_ID, string STATUS = null, string CHECKIN = null, string BTNEVENT = null, string CHECKOUT = null)
        {
            user_id = ID;
            location_id = LOCATION;
            Status = STATUS;
            check_in = CHECKIN;

            role_id = ROLE_ID;
            btnevent = BTNEVENT;
            check_out = CHECKOUT;
        }
    }
}
