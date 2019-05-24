'''项目属性

    ''项目事件

Public Function AfterOpenProject
    '启用全局表事件,用于添加审计日志
    For Each dt As DataTable In DataTables
        dt.GlobalHandler.DataColChanged = True
        dt.GlobalHandler.DataRowAdded = True
    Next

    '对非开发者隐藏最上方数据表表选择tab
    TableCaptionVisible = False
    If User.Type = UserTypeEnum.Developer
        TableCaptionVisible = True
    End If

    Forms("主窗口").Open()
End Function

    ''全局表事件


Public Function DataColChanged
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
End Function

Public Function DataRowAdded
    Dim RowIdentify As Integer
    If Not e.DataTable.Name.StartsWith("Change")  And e.DataTable.Name <> "Logs"  Then
        Try
            RowIdentify = e.DataRow("_Identify") 
        Catch ex As Exception
            RowIdentify = e.DataRow("id") 
        End Try
        Functions.Execute("ChangeOpCreate",e.DataTable.Name,RowIdentify,User.Name)
    End If
End Function