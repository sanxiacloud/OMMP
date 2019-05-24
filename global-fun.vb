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

    Dim oChange As New Change
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
'
Function CreateListViewColumns(ByVal ParamArray Args() as Object)
    Dim lv As WinForm.ListView = args(0)
    Dim names() As String = args(1) ' 名称列表
    Dim texts() As String = args(2) ' 文本列表
    Dim wds() As Integer = args(3) ' 宽度列表

    For i As Integer = 0 To names.Length - 1
        Dim c As WinForm.ListViewColumn = lv.Columns.Add()
        c.Text = texts(i)
        c.Name = names(i)
        If wds IsNot Nothing Then
            c.Width = wds(i)
        End If
    Next
End Function

#End Region

#Region 应用系统

' 根据过滤条件绘制应用系统tab组织treeview
Function ReDrawAppTvOrg(ByVal ParamArray Args() as Object)   
    Dim filter As String = Forms("主窗口").Controls("tb_app_org_sch").Text.Trim ' 搜索条件
    Dim tv As WinForm.TreeView = Forms("主窗口").Controls("tv_app_org")
    Dim dt As DataTable = DataTables("Organization")

    Dim drs As List(Of DataRow) = dt.Select("name like '%" & filter & "%' And _IsDeleted = false","code")

    Dim rowCount As Integer = drs.Count
    If rowCount = 0 Then
        MessageBox.Show("未找到相关组织.")
    Else
        tv.StopRedraw()
        tv.Nodes.Clear()

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
        tv.Nodes(0).Expand
        tv.ResumeRedraw()

    End If
End Function
' 重新绘制应用系统tab主listview
Function ReDrawAppLvApp(ByVal ParamArray Args() as Object)
    Dim node As WinForm.TreeNode = Forms("主窗口").Controls("tv_app_org").SelectedNode
    Dim lvApp As WinForm.ListView =  Forms("主窗口").Controls("lv_app_app")
    ' 重新初始化listview
    Dim coln() As String = {"name","organization","status","start_date","sla"} ' name
    Dim colt() As String = {"应用名称", "归属单位", "系统状态", "上线日期", "保障要求" } ' text
    Dim colw() As Integer = {240,150,75,95,95} ' 宽度
    lvApp.MultiSelect = False
    lvApp.StopRedraw() ' 暂停绘制
    lvApp.Columns.Clear() ' 清除原来的列
    lvApp.Rows.Clear() ' 清除原来的行
    lvApp.Images.Clear() ' 清除原来的图片
    lvApp.View = ViewMode.Details ' 显示模式为详细信息
    lvApp.GridLines = True ' 显示网格线
    ' 左边组织treeview上方文本框中的搜索条件
    Dim filter As String = Forms("主窗口").Controls("tb_app_org_sch").Text.Trim

    Functions.Execute("CreateListViewColumns",lvApp,coln,colt,colw)

    Dim count As Integer = 0 ' 应用系统计数
    ' 通过code前缀符合当前选择的组织，以及名称符合当前组织过滤条件，查找出组织id
    For Each  drOrg As DataRow In DataTables("Organization").Select("code like '" & node.Name & "%' And _IsDeleted=false And name like '%" & filter & "%'")
        
        Dim _id As Integer = drOrg("_Identify")
        ' 通过组织id查找出对应应用系统
        For Each drLK As DataRow In DataTables("LnkFunctionalCIToOrganization").Select("_IsDeleted=0 And organization_identify =" & _id)

            Dim drAS As DataRow= DataTables("ApplicationSolution").Find("id=" & drLK("functionalci_identify"))

            IF drAS IsNot Nothing Then
                Dim drCI As DataRow= DataTables("FunctionalCI").Find("_Identify=" & drLK("functionalci_identify"))
                Dim row As WinForm.ListViewRow = lvApp.Rows.Add()
                count = count + 1
                row("name") = drCI("name")
                row("organization") = DataTables("Organization").Find("_Identify = " & drLK("organization_identify"))("name")
                row("status") = Functions.Execute("TranslateCode","应用程序状态",drAS("code_application_status"))
                row("start_date") = drCI("move2production")
                row("sla") = Functions.Execute("TranslateCode","保障要求",drAS("code_sla"))
                row.Tag = drAS
            End IF
        Next
    Next
    Dim tcApp As WinForm.TabControl = Forms("主窗口").Controls("tc_app_app")
    Dim tabApp As WinForm.TabPage = tcApp.TabPages("app") '中间主tabcontrol，单选，用于展示 应用系统四个字以及应用系统数量
    tabApp.Text = "应用系统(" & count & ")"
    lvApp.ResumeRedraw() '恢复绘制
    ' Functions.Execute("RebuildHostList","-1")   
End Function

#End Region

#End Region