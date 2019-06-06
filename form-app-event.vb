' 应用系统相关弹出窗口

#Region main

Function AfterLoad(e)
    ' 初始化3个combolist下拉选项
    e.Form.Controls("cb_sla").ComboList = DataTables("Code").GetComboListString("label", "[t] = '保障要求'", "v")
    e.Form.Controls("cb_risk").ComboList = DataTables("Code").GetComboListString("label", "[t] = '风险评级'", "v")
    e.Form.Controls("cb_stat").ComboList = DataTables("Code").GetComboListString("label", "[t] = '应用程序状态'", "v")
    
    Dim type As String = GetFormParam("应用系统编辑", "type")
    Dim param As String
    IF type = "modify" Then
        e.Form.Text = "修改应用系统"
        ' 应用系统相关属性
        Dim identify As String = GetFormParam("应用系统编辑", "_Identify")
        Dim drCI As DataRow = Datatables("FunctionalCI").Find("_Identify=" & identify)
        Dim drAS As DataRow = Datatables("ApplicationSolution").Find("id=" & identify)
        e.Form.Controls("tb_name").Value = drCI("name")
        e.Form.Controls("cb_sla").SelectedIndex = drAS("code_sla")
        e.Form.Controls("cb_risk").SelectedIndex = drCI("code_risk_rating")
        e.Form.Controls("cb_stat").SelectedIndex = drAS("code_application_status")
        e.Form.Controls("dtp_mtp").Value = drCI("move2production")
        ' 组织相关属性
        Dim orgId As String = GetFormParam("应用系统编辑", "orgId")
        Dim drOrg As DataRow = DataTables("Organization").Find("_Identify=" & orgId)
        e.Form.Controls("db_org").Value = drOrg("name")

        SetFormVariable("应用系统编辑", "type", "modify")
        SetFormVariable("应用系统编辑", "orgId", orgId)
        SetFormVariable("应用系统编辑", "_Identify", identify)
    Else
        e.Form.Text = "新增应用系统"
        e.Form.Controls("cb_sla").SelectedIndex = 0 
        e.Form.Controls("cb_risk").SelectedIndex = 0
        e.Form.Controls("cb_stat").SelectedIndex = 0
        e.Form.Controls("dtp_mtp").Value = Date.Today()
    End If
    ClearFormParams("应用系统编辑")
End Function

#End Region main

#Region db_org 组织选择下拉树

Function TextChanged(e)
    Dim drp As WinForm.DropDownBox = e.sender
    If drp.DroppedDown Then '如果下拉窗口已经打开
        Dim tv As WinForm.TreeView = Forms("主管部门下拉树").Controls("TreeView1")
        Dim filter As String = drp.Text
        Dim dt As DataTable = DataTables("Organization")
        Dim drs As List(Of DataRow) = dt.Select("name like '%" & filter & "%' And _IsDeleted = false","code")
        Dim rowCount As Integer = drs.Count

        tv.StopRedraw()
        tv.Nodes.Clear()
        If rowCount <> 0 Then
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
            IF filter <> "" Then
                tv.ExpandAll()
            End IF 
            tv.Nodes(0).Expand()            
        End If
        tv.ResumeRedraw()
    End If
End Function 

Function KeyPress(e)
    Dim drp As WinForm.DropDownBox = e.Sender
    If drp.DroppedDown = False '如果下拉窗口没有打开
        ' 设置绘制下拉树所需参数
        SetFormParam("主管部门下拉树", "filter", e.Form.Controls("db_org").Text)
        drp.OpenDropDown() '打开下拉窗口
    End If
End Function 

Function Leave(e)
    Dim drp As WinForm.DropDownBox = e.Sender
    If drp.DroppedDown = True '如果下拉窗口打开
        drp.CloseDropDown() '关闭下拉窗口
    End If
    e.Sender.Value = e.Sender.Text
    Dim dr As DataRow = DataTables("Organization").Find("name='" & e.Sender.Value & "'")
    IF dr Is Nothing Then
        SetFormVariable("应用系统编辑", "orgId", "-1")
    Else    
        SetFormVariable("应用系统编辑", "orgId", dr("_Identify"))
    End IF
End Function

Function Click(e)
    Dim drp As WinForm.DropDownBox = e.Sender
    If drp.DroppedDown = True '如果下拉窗口打开
        drp.CloseDropDown() '关闭下拉窗口
    Else
        SetFormParam("主管部门下拉树", "filter", e.Form.Controls("db_org").Text)
        drp.OpenDropDown()
    End If    
End Function

#End Region db_org 组织选择下拉树