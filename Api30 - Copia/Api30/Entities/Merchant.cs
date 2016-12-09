namespace Api30.Entities
{
    public class Merchant
    {
        public Merchant(string id, string key)
        {
            _id = id;
            _key = key;
        }

        private string _key;

        public string Key
        {
            get { return _key; }
            //set { _key = value; }
        }

        private string _id;

        public string Id
        {
            get { return _id; }
            //set { _id = value; }
        }
    }
}