using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkUareU
{
    public class JsonItem
    {
        

        public string user_id;
        public string location_id;
        public string role_id;
       
        public string Name;
        public string DName;

        public string check_in;
        public string check_out;
        public string Lunch_out;
        public string Lunch_in;

        public string Status;

        public string btnevent;

        //public string ip_in;
        //public string ip_out;

        public JsonItem(string ID, string LOCATION, string ROLE_ID, string NAME, string DNAME, string CHECKIN = null, string CHECKOUT = null, string LUNCHIN = null, string LUNCHOUT = null, string STATUS = null,  string BTNEVENT = null)
        {
            user_id = ID;
            location_id = LOCATION;
            role_id = ROLE_ID;
            Name = NAME;
            DName = DNAME;            
            check_in = CHECKIN;
            check_out = CHECKOUT;
            Lunch_in = LUNCHIN;
            Lunch_out = LUNCHOUT;
            btnevent = BTNEVENT;            
            Status = STATUS;
        }        
    }
}
