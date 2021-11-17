namespace data
{
    public class EnvironmentData
    {
        //ENUMS
        public enum DEVICE
        {
            ANDROID,
            IOS
        }        

        public DEVICE TEST_DEVICE { get; set; }
        public string APP_VERSION { get; set; }

        //DEVICE CONFIGURATION
        public string DEVICE_NAME { get; set; }        
        public string IOS_UDID { get; set; }
        public string PLATAFORM_VERSION { get; set; }
        public string MODEL { get; set; }
        public string MANUFACTURER { get; set; }

        //REMOTE EXECUTION
        public bool REMOTE { get; set; }
        public string CLOUDNAME { get; set; }
        public string SECURITYTOKEN { get; set; }
    }
}