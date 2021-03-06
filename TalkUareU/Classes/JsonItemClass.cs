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
        public string punch_id;

        //public string ip_in;
        //public string ip_out;

        public JsonItem(string USER_ID, string LOCATION, string ROLE_ID, string NAME = null, string DNAME = null, string CHECKIN = null, string CHECKOUT = null, string LUNCHIN = null, string LUNCHOUT = null, string STATUS = null, string BTNEVENT = null, string PUNCH_ID = null)
        {
            user_id = USER_ID;
            location_id = LOCATION;
            role_id = ROLE_ID;
            Name = NAME;
            DName = DNAME;
            check_in = CHECKIN;
            check_out = CHECKOUT;
            Lunch_in = LUNCHIN;
            Lunch_out = LUNCHOUT;
            Status = STATUS;
            btnevent = BTNEVENT;
            punch_id = PUNCH_ID;
        }

        public string getTimeString()
        {
            string res = "in: " + check_in;
            if (Lunch_out != null) res += ", lunch: " + Lunch_out;
            if (Lunch_in != null) res += ", return: " + Lunch_in;
            if (check_out != null) res += ", out: " + check_out;
            return res;
        }
    }
}
