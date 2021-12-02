namespace data
{
    using static constants;
    public class EnvData
    {
        public OS TEST_DEVICE { get; set; }
        public string APP_VERSION { get; set; }

        #region DEVICE CONFIGURATION ATRIBUTES
        public string DEVICE_NAME { get; set; }        
        public string IOS_UDID { get; set; }
        public string PLATAFORM_VERSION { get; set; }
        public string MODEL { get; set; }
        public string MANUFACTURER { get; set; }
        public string RESOLUTION { get; set; }
        #endregion

        #region REMOTE EXECUTION ATRIBUTES
        public bool REMOTE { get; set; }
        public string CLOUDNAME { get; set; }
        public string SECURITYTOKEN { get; set; }
        #endregion
    }
}