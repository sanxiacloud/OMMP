#Region 窗口
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
        Dim parentForm As String = GetFormParams("主管部门下拉树", "parentForm")
        Dim valueControl As String = GetFormParams("主管部门下拉树", "valueControl")
        Forms(parentForm).Controls(valueControl).Value = node.Tag
        e.Form.DropDownBox.CloseDropdown()
    End IF   
End Function

#End Region