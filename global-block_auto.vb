'全局代码 


'Vars
'全局窗口跳转参数,格式为 (窗口名_键名,键值)
Public PARAMS As New Dictionary(Of String,Dictionary(Of String,String))
'全局窗口回调参数code
Public PERFORMS As New Dictionary(Of String,String)



'Change
Class Change
    Private m_Identify As Integer, m_date As Date, m_user_name As String, m_code_origin As Integer  '/// 声明成员变量

    ReadOnly Public Property Identify() As Integer
        Get
            Return m_Identify
        End Get
    End Property

    Public Property UserName() As String
        Get
            Return m_user_name
        End Get
        Set(ByVal strUserName As String)
            m_user_name = strUserName
        End Set
    End Property
End Class