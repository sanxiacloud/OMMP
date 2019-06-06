#Region 窗口
Function DropDownOpening(e)
    Dim tv As WinForm.TreeView = e.Form.Controls("TreeView1")
    Dim filter As String = GetFormParam("主管部门下拉树", "filter")
    ClearFormParams("主管部门下拉树")
    IF filter Is Nothing Then 
        filter = ""
    End IF 
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
End Function

' 保障每次输入展开dropdown窗口后，焦点任然在dropdownbox上，以便可以继续输入
Function DropDownOpend(e)
    e.Form.DropDownBox.Select()
End Function

#End Region 窗口

#Region TreeView1

Function NodeMouseClick(e)
    Dim node As WinForm.TreeNode = e.Node
    IF node.Nodes.Count = 0 Then
        e.Form.DropDownBox.Value = node.text      
        e.Form.DropDownBox.CloseDropdown()
    End IF   
End Function

#End Region