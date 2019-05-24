'项目属性

项目事件

AfterOpenProject

For Each dt As DataTable In DataTables
    dt.GlobalHandler.DataColChanged = True
    dt.GlobalHandler.DataRowAdded = True
Next

basemainform.minimizebox = False
basemainform.MaximizeBox = False
TableCaptionVisible = False
Forms("应用管理").Open()

' Forms("OpenQQ 登录").Open()
'隐藏标题
If User.Type = UserTypeEnum.Developer
    TableCaptionVisible = True
    basemainform.minimizebox = True
    basemainform.MaximizeBox = True
End If

'If QQClient.Ready Then
'    MessageBox.show("QQClient已经启动,请先关闭","提示",MessageBoxButtons.OK,MessageBoxIcon.Information)
'    Return
'End If
'QQClient.ServerIP = "10.19.213.100" 'e.Form.Controls("txtIP").Value  '指定服务器IP地址
'QQClient.ServerPort = "52177" 'e.Form.Controls("txtPort").Value  '指定服务器端口

' 为便于调试分析,希望开发者和管理员也能使用内置身份登录OpenQQ,可以将客户端的登录代码要调整为
'If user.Type = UserTypeEnum.User Then '如果是普通用户
'    QQClient.UserName =""
'    QQClient.Password = ""
'Else '如果是开发者或管理员
'    Dim pwd As String
'    If InputPassWord(pwd,"提示","请输入" & User.Name & "的密码:") Then
'        QQClient.UserName = User.Name
'        QQClient.Password = pwd
'    Else
'        Return
'    End If
'End If

'If QQClient.Start() = True '如果登录成功
'    Dim msg As String =  "恭喜,OpenQQ登录成功!"
'    If QQClient.ServerMessage > "" Then '如果服务器返回了欢迎信息
'        msg = msg & QQClient.ServerMessage
'    End If
'    ConfigBar.Items("OpenQQ").SmallImage = GetImage("online.ico")
'    popMessage(msg,"提示",PopiconEnum.Infomation,5)
'Else '如果登录失败,显示服务器返回错误信息
    'e.Form.Controls("btnChat").Enabled = False
'    PopMessage("QQClient登录失败,原因:" & vbcrlf & QQClient.ServerMessage,"提示",PopiconEnum.Error,5)
'End If

LoadUserSetting

For Each t As Table In Tables
    t.Visible = True
    t.AllowEdit = True
    For Each c As Col In t.Cols
        c.Visible = True
        c.AllowEdit = True
    Next
Next

Tables("visualAuthorization").Visible = (User.Type <> UserTypeEnum.User )
If User.Type = UserTypeEnum.User Then
    For Each dr As DataRow In DataTables("visualAuthorization").Select("username = '" & User.Name & "'" )
        If dr.IsNull("column_name") Then
            Tables(dr("table_name")).Visible = Not dr("visiable")
            Tables(dr("table_name")).AllowEdit = Not dr("visiable")
        Else
            Tables(dr("table_name")).Cols(dr("column_name")).Visible = Not dr("visiable")
            Tables(dr("table_name")).Cols(dr("column_name")).AllowEdit = Not dr("editable")
        End If
    Next
End If
'===================QQ releated================
Disconnected

ConfigBar.Items("OpenQQ").SmallImage = GetImage("offline.ico")

Client_ReceivedMessage

Dim dr As DataRow = DataTables("messages").AddNew
dr("sender") = iif(e.UserName > "",e.UserName,"服务器")
dr("ts_msg") = Date.Now()
dr("contents") = e.Message
'==============================================
DataColChanged

Dim TableName As String = e.DataTable.Name '表名称
Dim RowIdentify As Integer = 1 '数据行主键
Dim ColName As String = e.DataCol.Name '列名称
Dim ColDataType As String = e.DataCol.DataType.Name '列的数据类型:e.DataCol.DataType.Name
Dim _OldValue As String = e.OldValue '旧值
Dim _NewValue As String = e.NewValue '新值
Dim UsersName As String = User.Name '操作用户名称

If Not e.DataTable.Name.StartsWith("Change")  And e.DataTable.Name <> "Logs"  Then
    Try
        RowIdentify = e.DataRow("_Identify") 
    Catch ex As Exception
        RowIdentify = e.DataRow("id") 
    End Try

    Functions.Execute("ChangeOpSetAtt",TableName, RowIdentify, ColName, ColDataType, _OldValue, _NewValue, UsersName )
End If

DataRowAdded

Dim RowIdentify As Integer
If Not e.DataTable.Name.StartsWith("Change")  And e.DataTable.Name <> "Logs"  Then
    Try
        RowIdentify = e.DataRow("_Identify") 
    Catch ex As Exception
        RowIdentify = e.DataRow("id") 
    End Try
    Functions.Execute("ChangeOpCreate",e.DataTable.Name,RowIdentify,User.Name)
End If


