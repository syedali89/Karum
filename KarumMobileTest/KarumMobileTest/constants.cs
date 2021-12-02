using data;

public static class constants
{
    #region Enviroment variables const
    public const string REMOTE = "REMOTE";    
    public const string ANDROID = "A";
    public const string IOS = "I";
    public const string REMOTE_TRUE = "T";
    public const string REMOTE_FALSE = "F";
    #endregion
    #region Folder Names const
    public const string DOCUMENTS_FOLDER = "documents";
    public const string JSON_FOLDER = "jsonfiles";
    public const string APPVERSION_FOLDER = "appVersion";
    #endregion
    #region Device folders paths const 
    public const string MOVILE_DOWNLOAD_PATHFOLDER_ANDROID = "/storage/emulated/0/Download";
    public const string MOVILE_DOWNLOAD_PATHFOLDER_IOS = "TODO";
    #endregion
    #region url const
    public const string EMAILINBOX =
            "https://www.mailinator.com/v4/public/inboxes.jsp?to=codigomovil";
    public const string EMAILPATH =
            "https://www.mailinator.com/v4/public/inboxes.jsp?msgid=";
    #endregion
    #region File name const
    public const string AVISOPRIVACIDAD_DOCUMENT =
        "AVISO DE PRIVACIDAD (22sep2021).pdf";
    #endregion
    #region Karum App const 
    public const string KARUM_PACKAGE_NAME = "com.karum.credits";
    public const string KARUM_ACTIVITY_NAME = "com.karum.credits.ui.SplashActivity";
    #endregion
    #region Generic const
    public const string CLIENTE = "CLIENTE";
    public const string AGOSTO = "Agosto";
    public const string ADD = "Add";
    public const string SUBSTRACT = "Subtract";
    public const string ERROR_RECOVERING_SECURITY_CODE = "Error trying to recover security code";
    #endregion

    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

    public enum DownMenuSelected
    {
        HOME,
        CREDIT,
        PROFILE
    };

    public enum OS
    {
        ANDROID,
        IOS
    };
}
