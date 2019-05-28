'''内部函数

#Region 操作审计
'创建行
Function ChangeOpCreate(ByVal ParamArray Args() as Object)
    Dim TableName As String = Args(0)
    Dim RowIdentify As Integer = Args(1)
    Dim UsersName As String = Args(2)

    Dim drChange As DataRow = DataTables("Change").AddNew
    drChange("date") = Date.Now
    drChange("user_name") = UsersName 
    drChange("code_origin") = 0 '代码表:来源-(0)界面交互
    drChange.save

    Dim drChangeOp As DataRow = DataTables("ChangeOp").AddNew
    drChangeOp("change_identify") = drChange("_Identify")
    drChangeOp("objclass") = TableName
    drChangeOp("objkey") = RowIdentify
    drChangeOp("optype") = "ChangeOpCreate"
    drChangeOp.save

    Dim drChangeOpCreate As DataRow = DataTables("ChangeOpCreate").AddNew  
    drChangeOpCreate("id") = drChangeOp("_Identify")
    drChangeOpCreate.save

End Function

'修改字段
Function ChangeOpSetAtt(ByVak ParamArray  Args() as Object)
    Dim TableName As String = Args(0) '表名称
    Dim RowIdentify As Integer = Args(1) '数据行主键
    Dim ColName As String = Args(2) '列名称
    Dim ColDataType As String = Args(3) '列的数据类型:e.DataCol.DataType.Name
    Dim _OldValue As String = Args(4) '旧值
    Dim _NewValue As String = Args(5) '新值
    Dim UsersName As String = Args(6) '操作用户名称

    Dim drChange As DataRow = DataTables("Change").AddNew
    drChange("date") = Date.Now
    drChange("user_name") = UsersName 
    drChange("code_origin") = 0 '代码表:来源-(0)界面交互
    drChange.save

    Dim drChangeOp As DataRow = DataTables("ChangeOp").AddNew
    drChangeOp("change_identify") = drChange("_Identify")
    drChangeOp("objclass") = TableName
    drChangeOp("objkey") = RowIdentify
    drChangeOp("optype") = "ChangeOpSetAtt"
    drChangeOp.save

    Dim drChangeOpSetAtt As DataRow = DataTables("ChangeOpSetAtt").AddNew  
    drChangeOpSetAtt("id") = drChangeOp("_Identify") 
    drChangeOpSetAtt("attcode") = ColName 
    drChangeOpSetAtt.save

    Dim drChangeOpSetAttScalar As DataRow = DataTables("ChangeOpSetAttScalar").AddNew  
    drChangeOpSetAttScalar("id") = drChangeOp("_Identify") 
    drChangeOpSetAttScalar("oldvalue") = _OldValue
    drChangeOpSetAttScalar("newvalue") = _NewValue
    drChangeOpSetAttScalar.save
End Function
#End Region

#Region 数据库操作

#Region 通用工具
' 翻译编码到文字
Function TranslateCode(ByVal ParamArray Args() as Object)
    Dim _type As String = args(0) 'code类型
    Dim _code As Integer = args(1) 'code码

    Dim dt As DataTable = DataTables("Code")
    Dim dr As DataRow = dt.Find("t='" & _type & "' And v=" & _code )
    If dr Is Nothing
        return "参数错误"
    Else
        return dr("label")
    End If
End Function

#End Region

#End Region

#Region 控件绘制

#Region 通用工具
'初始化listview，绘制表头
Function InitListView(ByVal ParamArray Args() as Object)
    Dim lv As WinForm.ListView = args(0)
    Dim names() As String = args(1) ' 名称列表
    Dim texts() As String = args(2) ' 文本列表
    Dim wds() As Integer = args(3) ' 宽度列表

    lv.StopRedraw()
    lv.MultiSelect = False    
    lv.Columns.Clear() ' 清除原来的列
    lv.Rows.Clear() ' 清除原来的行
    lv.Images.Clear() ' 清除原来的图片
    lv.View = ViewMode.Details ' 显示模式为详细信息
    lv.GridLines = True ' 显示网格线

    For i As Integer = 0 To names.Length - 1
        Dim c As WinForm.ListViewColumn = lv.Columns.Add()
        c.Text = texts(i)
        c.Name = names(i)
        If wds IsNot Nothing Then
            c.Width = wds(i)
        End If
    Next
    lv.ResumeRedraw()
End Function
'清理listview，删除所有行
Function ClearListView(ByVal ParamArray Args() as Object)
    Dim lv As WinForm.ListView = args(0)】
    lv.StopRedraw()
    lv.Rows.Clear() ' 清除原来的行
    lv.ResumeRedraw()
End Function

#End Region

#Region 应用系统

#Region 组织treeview
' 根据过滤条件绘制应用系统tab组织treeview
Function ReDrawAppTvOrg(ByVal ParamArray Args() as Object)   
    Dim filter As String = Forms("主窗口").Controls("tb_app_org_sch").Text.Trim ' 搜索条件
    Dim tv As WinForm.TreeView = Forms("主窗口").Controls("tv_app_org")
    Dim dt As DataTable = DataTables("Organization")

    Dim drs As List(Of DataRow) = dt.Select("name like '%" & filter & "%' And _IsDeleted = false","code")
    Dim rowCount As Integer = drs.Count

    Functions.Execute("ClearAppTvOrg")
    If rowCount <> 0 Then       
        tv.StopRedraw()
        '添加根节点
        Dim drAnc As DataRow = dt.Find("code='" & drs(0)("code").SubString(0, 2) & "'") '祖先节点行        
        Dim rnode As WinForm.TreeNode = tv.Nodes.Add(drAnc("code"), drAnc("name")) '根节点
        rnode.Tag = drAnc("_Identify")

        For i As Integer = 0 to rowCount - 1
            Dim len As Integer = 5
            Dim dr As DataRow = drs(i)
            Dim pnode As WinForm.TreeNode = rnode '当前父节点，初始为根节点
            Do While len <= dr("code").Length '循环遍历全部2+3n长度的前序code，这些都是一个节点的祖先路径节点
                drAnc = dt.Find("code='" & dr("code").SubString(0, len) & "'")
                IF Not pnode.Nodes.Contains(drAnc("code")) Then
                    pnode = pnode.Nodes.Add(drAnc("code"), drAnc("name"))
                    pnode.Tag = drAnc("_Identify")
                Else 
                    pnode = pnode.Nodes(drAnc("code"))
                End If
                len = len + 3
            Loop 
        Next
        '所有节点统计子节点数并显示到text中
        For Each node As WinForm.TreeNode In tv.AllNodes
            Dim ncount As Integer = node.AllNodes.Count
            If ncount > 0
                node.Text = node.Text & "(" & ncount & ")"
            End If
        Next
        IF filter <> "" Then
            tv.ExpandAll()
        End IF 
        tv.Nodes(0).Expand()

        tv.ResumeRedraw()
    End If

    Forms("主窗口").Controls("tb_app_org_sch").Enabled = True
    Forms("主窗口").Controls("bt_app_org_sch").Enabled = True
    Forms("主窗口").Controls("bt_app_org_add").Enabled = True    
    Forms("主窗口").Controls("bt_app_org_rfh").Enabled = True
End Function
' 初始化时需要先让所有相关按钮、文本框不可用
Function ClearAppTvOrg(ByVal ParamArray Args() as Object)
    Dim tv As WinForm.TreeView = Forms("主窗口").Controls("tv_app_org")
    tv.StopRedraw()
    tv.Nodes.Clear()
    tv.ResumeRedraw()

    Forms("主窗口").Controls("tb_app_org_sch").Enabled = False
    Forms("主窗口").Controls("bt_app_org_sch").Enabled = False
    Forms("主窗口").Controls("bt_app_org_add").Enabled = False
    Forms("主窗口").Controls("bt_app_org_mod").Enabled = False
    Forms("主窗口").Controls("bt_app_org_rfh").Enabled = False

    Functions.Execute("ClearAppLvApp")
End Function

#End Region 组织treeview

#Region 应用系统listview
' 重新绘制应用系统tab主listview
Function ReDrawAppLvApp(ByVal ParamArray Args() as Object)
    Dim node As WinForm.TreeNode = Forms("主窗口").Controls("tv_app_org").SelectedNode
    Dim lvApp As WinForm.ListView =  Forms("主窗口").Controls("lv_app_app")    

    Functions.Execute("ClearAppLvApp")

    lvApp.StopRedraw() ' 暂停绘制

    Dim count As Integer = 0 ' 应用系统计数

    ' 通过遍历当前treeview，获取所有org，treenode的tag中记录了org的Identify
    Dim stack1 As New Stack(Of WinForm.TreeNode)
    Dim stack2 As New Stack(Of WinForm.TreeNode)
    Dim tnCur As WinForm.TreeNode
    ' 后根DFS
    stack1.Push(node)
    Do While stack1.Count > 0
        tnCur = stack1.Pop()
        stack2.Push(tnCur)
        For Each tnCld As WinForm.TreeNode In tnCur.Nodes
            stack1.Push(tnCld)
        Next
    Loop  
    For Each node In stack2
        Dim _id As String = node.Tag ' tag中存放的组织表的identify
        ' 通过组织identify查找出对应应用系统
        For Each drLK As DataRow In DataTables("LnkFunctionalCIToOrganization").Select("_IsDeleted=0 And organization_identify =" & _id)

            'Dim drAS As DataRow= DataTables("ApplicationSolution").Find("id=" & drLK("functionalci_identify"))
            Dim drCI As DataRow= DataTables("FunctionalCI").Find("_Identify=" & drLK("functionalci_identify"))
            IF drCI("finalclass") = "ApplicationSolution" Then
            'IF drAS IsNot Nothing Then
                'Dim drCI As DataRow= DataTables("FunctionalCI").Find("_Identify=" & drLK("functionalci_identify"))
                Dim drAS As DataRow= DataTables("ApplicationSolution").Find("id=" & drLK("functionalci_identify"))
                Dim row As WinForm.ListViewRow = lvApp.Rows.Add()
                count = count + 1
                row("name") = drCI("name")
                row("organization") = DataTables("Organization").Find("_Identify=" & drLK("organization_identify"))("name")
                row("status") = Functions.Execute("TranslateCode","应用程序状态",drAS("code_application_status"))
                row("start_date") = drCI("move2production")
                row("sla") = Functions.Execute("TranslateCode","保障要求",drAS("code_sla"))
                row.Tag = drCI ' todo 什么用？
            End IF
        Next
    Next
    Dim tcApp As WinForm.TabControl = Forms("主窗口").Controls("tc_app_app")
    Dim tabApp As WinForm.TabPage = tcApp.TabPages("app") '中间主tabcontrol，单选，用于展示 应用系统四个字以及应用系统数量
    tabApp.Text = "应用系统(" & count & ")"
    lvApp.ResumeRedraw() '恢复绘制

    Forms("主窗口").Controls("bt_app_app_add").Enabled = True    
End Function

Function ClearAppLvApp(ByVal ParamArray Args() as Object)
    Dim lvApp As WinForm.ListView =  Forms("主窗口").Controls("lv_app_app")
    lvApp.StopRedraw()
    lvApp.Rows.Clear() ' 清除原来的行
    lvApp.ResumeRedraw()

    Forms("主窗口").Controls("bt_app_app_add").Enabled = False
    Forms("主窗口").Controls("bt_app_app_del").Enabled = False

    Functions.Execute("ClearAppLvHost")
    ' todo others
End Function
#End Region

#Region  dev tab中的host listview
' 重新绘制dev tab中host listview
Function ReDrawAppLvHost(ByVal ParamArray Args() as Object)
    Dim appId As String = args(0)
    Dim lvHost As WinForm.ListView = Forms("主窗口").Controls("lv_app_dev_host")
    Dim pmSelected As Boolean = Forms("主窗口").Controls("cb_app_dev_host_pm").Checked
    Dim vmSelected As Boolean = Forms("主窗口").Controls("cb_app_dev_host_vm").Checked
    
    Functions.Execute("ClearAppLvHost")

    lvHost.StopRedraw() ' 暂停绘制
    
    Dim count As Integer = 0   
    For Each drLK As DataRow In DataTables("LnkApplicationSolutionToFunctionalCI").Select("_IsDeleted=0 And applicationsolution_identify=" & appId)
        Dim drCI As DataRow= DataTables("FunctionalCI").Find("_Identify=" & drLK("functionalci_identify"))
        IF drCI("finalclass") = "VirtualMachine" And vmSelected Then
            Dim row As WinForm.ListViewRow = lvHost.Rows.Add()
            Dim drVM As DataRow = DataTables("VirtualMachine").Find("id=" & drLK("functionalci_identify"))
            Dim drIP As DataRow = DataTables("IPAddressv4").Find("id=" & drVM ("managementip_identify"))
            count = count + 1
            row("type") = "虚拟机"
            row("name") = drCI("name")
            row("ip") = drIP("ip")
            row("start_date") = drCI("move2production")
            row("description") = drCI("description")
            row.Tag = drCI ' todo 什么用？
        End IF
        IF drCI("finalclass") = "Server" And pmSelected Then
            ' todo添加物理机 
            Dim row As WinForm.ListViewRow = lvHost.Rows.Add()
            row("type") = "物理机"           
            row.Tag = drCI
        End IF
    Next

    Dim tcDev As WinForm.TabControl = Forms("主窗口").Controls("tc_app_dev")
    Dim tabHost As WinForm.TabPage = tcDev.TabPages("host") '中间主tabcontrol，单选，用于展示 应用系统四个字以及应用系统数量
    tabHost.Text = "主机(" & count & ")"
    lvHost.ResumeRedraw() '恢复绘制

    Forms("主窗口").Controls("bt_app_host_add").Enabled = True
    Forms("主窗口").Controls("cb_app_dev_host_pm").Enabled = True
    Forms("主窗口").Controls("cb_app_dev_host_vm").Enabled = True

End Function

Function ClearAppLvHost(ByVal ParamArray Args() as Object)
    Dim lvHost As WinForm.ListView = Forms("主窗口").Controls("lv_app_dev_host")
    lvHost.StopRedraw()
    lvHost.Rows.Clear() ' 清除原来的行
    lvHost.ResumeRedraw()

    ' 同时disable所有相关按钮
    Forms("主窗口").Controls("bt_app_host_add").Enabled = False
    Forms("主窗口").Controls("bt_app_host_del").Enabled = False
    Forms("主窗口").Controls("cb_app_dev_host_pm").Enabled = False
    Forms("主窗口").Controls("cb_app_dev_host_vm").Enabled = False
End Function

#End Region

#End Region

#End Region