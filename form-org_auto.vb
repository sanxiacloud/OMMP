窗口表事件

窗口与控件事件

组织编辑_AfterClose

Functions.Execute("cleanFormParams",e.Form.Name)

组织编辑_AfterLoad

Dim code As String = Functions.Execute("getFormParameter",e.Form.Name,"org_edit_code")
Dim _added As Boolean = code Is Nothing Or code.Length = 0

Dim et_name As WinForm.TextBox = e.Form.Controls("et_name")
Dim cb_status As WinForm.ComboBox = e.Form.Controls("cb_status")
Dim et_code As WinForm.TextBox = e.Form.Controls("et_code")
Dim et_parent As WinForm.TextBox = e.Form.Controls("et_parent")
Dim et_short As WinForm.TextBox = e.Form.Controls("et_short")
Dim et_content As WinForm.TextBox = e.Form.Controls("et_content")
Dim btn_delete As WinForm.Button = e.Form.Controls("btn_delete")
btn_delete.Visible = IIF(_added,False,True)
Dim dt As DataTable = DataTables("Organization")
Dim dr As DataRow


If _added Then '添加单位
    e.Form.Text = "添加单位"
    Functions.Execute("setFormParameter",e.Form.Name,"selected_parent_id","")
    
Else '修改单位
    e.Form.Text = "修改单位"
    dr = dt.Find("code = '" & code & "'")
    et_name.Text = dr("name")
    et_code.Text = dr("code")
    cb_status.SelectedIndex= IIF(dr("status"),0,1)
    Dim parent As String
    Functions.Execute("setFormParameter",e.Form.Name,"selected_parent_id",dr("parent_identify"))
    If dr("parent_identify") = 0 Then
        parent = ""
    Else
        parent = dt.Find("_Identify = " & dr("parent_identify"))("name")
    End If
    et_parent.Text = parent
    et_short.Text = dr("short_name")
    et_content.Text = dr("description")
End If

组织编辑_btn_cancel_Click

e.Form.Close

组织编辑_btn_delete_Click

Dim Result As DialogResult
Result = MessageBox.Show("确认删除?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
If Result = DialogResult.Yes Then
    Dim code As String = Functions.Execute("getFormParameter",e.Form.Name,"org_edit_code")
    Dim dr As DataRow = DataTables("Organization").Find("code = '" & code & "'")
    dr("_IsDeleted") = True
    dr.Save
    Functions.Execute("setFormResult",e.Form,"应用管理",Nothing)
    e.Form.Close
End If

组织编辑_btn_submit_Click

Dim et_name As WinForm.TextBox = e.Form.Controls("et_name")
Dim cb_status As WinForm.ComboBox = e.Form.Controls("cb_status")
Dim et_code As WinForm.TextBox = e.Form.Controls("et_code")
Dim et_parent As WinForm.TextBox = e.Form.Controls("et_parent")
Dim et_short As WinForm.TextBox = e.Form.Controls("et_short")
Dim et_content As WinForm.TextBox = e.Form.Controls("et_content")

Dim name As String = et_name.Text.Trim
Dim codes As String = et_code.Text.Trim
Dim status As Integer = cb_status.SelectedIndex
Dim parent As String = et_parent.Text.Trim
Dim shr As String = et_short.Text.Trim
Dim content As String = et_content.Text.Trim

If name.Length = 0 Or codes.Length = 0 Or status < 0 Or parent.Length = 0 Then
    MessageBox.Show("请完善组织信息")
Else
    Dim code As String = Functions.Execute("getFormParameter",e.Form.Name,"org_edit_code")
    Dim dr As DataRow = DataTables("Organization").Find("code = '" & code & "'")
    If dr Is Nothing
        dr = DataTables("Organization").AddNew
    End If
    dr("name") = name
    dr("code") = codes
    dr("status") = IIF(status = 0, True,False)
    dr("parent_identify") = Functions.Execute("getFormParameter",e.Form.Name,"selected_parent_id")
    dr("short_name") = shr
    dr("description") = content
    dr.Save
    Functions.Execute("setFormResult",e.Form,"应用管理",Nothing)
    e.Form.Close
End If

组织编辑_onResult_Click

'窗口setresult方法回调
Dim id As String = Functions.Execute("getFormResult",e.Form,"父级搜索","parent_id")
Functions.Execute("setFormParameter",e.Form.Name,"selected_parent_id",id)
Dim et_parent As WinForm.TextBox = e.Form.Controls("et_parent")
Dim et_code As WinForm.TextBox = e.Form.Controls("et_code")
Dim dp As DataRow = DataTables("Organization").Find("_Identify = " & id)
et_code.Value= dp("code") & Functions.Execute("CalcCode",id)
et_parent.Value = dp("name")

组织编辑_PictureBox2_Click

Dim s() As String = {"parent_id"}
Functions.Execute("StartFormForResult",e.Form, "父级搜索",Nothing,s)


