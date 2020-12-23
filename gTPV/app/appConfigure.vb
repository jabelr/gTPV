Namespace My
    Module appConfigure
        'Clases de la aplicacion
        Public m_app As gDevelop.Lite.m_app                                    'Clase de valores locales de la aplicacion

        'Public m_db_app As gDevelop.Lite.m_database

        Public m_db_mysql As MySql.Data.MySqlClient.MySqlConnection = Nothing


        Public m_db As gDevelop.Lite.m_database                              'Clase de base de datos
        Public m_db_temp As gDevelop.Lite.m_database                     'Clase de base de datos temporal

        Public m_msg As gDevelop.Lite.m_msg                                    'Clase para el control de errores

        'Contantes de la aplicacion
        Public Const APP_NAME As String = "gTPV"                                                   'Nombre de la aplicacion
        Public Const APP_CODENAME As String = "New world!"                                                       'Nombre enclave de la aplicacion
        Public Const APP_NUMBER As Integer = 7                                                                     'Numero predefinido para operaciones de separacion, calculos

        Public Const APP_DATABASE As String = "gTPV"                                                         'Nombre de la base de datos
        'Public Const APP_DATABASE_CFG As String = "app"
        Public Const APP_DATABASE_TMP As String = "tmp"

        Public N_TICKETSHISTORY As Integer = 1024                       'Nº de Ticket para recordarnos que es cuestión de cerrar la caja actual


        '///#### TEMPORALES GENERALES
        Public Const ID_CONTABLE As Integer = 1


        Public swEgg As Boolean = False                         ' Para cuando activo el huevo de pascua

        Public AppIdUser As Integer = -1                                     'Para controlar los permisos de seguridad

    End Module
End Namespace