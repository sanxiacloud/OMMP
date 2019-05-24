'应用管理  事件

窗口表事件

窗口与控件事件

应用管理_AfterClose

Functions.Execute("cleanFormParams",e.Form.Name)

应用管理_AfterLoad

'生成并绑定组织树
Dim tr As WinForm.TreeView = e.Form.Controls("tr_org")
Dim filter As String = ""
Functions.Execute("FilOrgTree",tr,"")

tr.SelectedNode = tr.Nodes(0)
tr.SelectedNode.Expand

Dim lv_org As WinForm.ListView = e.Form.Controls("lv_org")
lv_org.MultiSelect = False
Dim lv_host As WinForm.ListView = e.Form.Controls("lv_host")
lv_host.MultiSelect = False

应用管理_btn_add_org_Click

Dim zd As New Dictionary(Of String, String)
zd.Add("org_edit_code","")
Functions.Execute("StartForm","组织编辑",zd)

应用管理_btn_edit_org_Click

Dim tr As WinForm.TreeView = e.Form.Controls("tr_org")
Dim nd As WinForm.TreeNode = tr.SelectedNode
If nd Is Nothing = False Then
    Dim zd As New Dictionary(Of String, String)
    zd.Add("org_edit_code",nd.Name)
    Functions.Execute("startForm", "组织编辑",zd)
End If

应用管理_btn_host_add_Click

Dim lv_host As WinForm.ListView = e.Form.Controls("lv_org")
Dim dr As DataRow = lv_host.Current.Tag '"FunctionalCI"
Dim dic As New Dictionary(Of String,String)
dic.Add("selected_host","")
dic.Add("selected_app",dr("_Identify"))
Functions.Execute("startForm","主机",dic)

应用管理_btn_rebuilt_org_Click

Dim tv_search As WinForm.TextBox = e.Form.Controls("tv_search_org")
Dim tr_org As WinForm.TreeView = e.Form.Controls("tr_org")
tv_search.Text = ""
Functions.Execute("FilOrgTree",tr_org,"")
tr_org.Nodes(0).Expand

应用管理_btn_search_org_Click

Functions.Execute("ClickForSearch")

应用管理_Button1_Click

Dim tr_org As WinForm.TreeView = e.Form.Controls("tr_org")
Dim dic As New Dictionary(Of String,String)
dic.Add("selected_app","")
dic.Add("selected_org",tr_org.SelectedNode.Name)
Functions.Execute("StartForm","应用系统编辑",dic)

应用管理_Button2_Click

Dim lv_org As WinForm.ListView = e.Form.Controls("lv_org")
If lv_org.Current Is Nothing
    Return
End If


Dim Result As DialogResult
Result = MessageBox.Show("确认删除?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
If Result = DialogResult.Yes Then
    Dim dr As DataRow = lv_org.Current.Tag
    Dim drLOF As DataRow = DataTables("LnkFunctionalCIToOrganization").Find("functionalci_identify = " & dr("_Identify"))
    drLOF("_IsDeleted") = True
    drLOF.Save
    Functions.Execute("RebuildAppList")
    
End If

应用管理_Button6_Click

Dim lv_host As WinForm.ListView = e.Form.Controls("lv_host")
Dim lv_org As WinForm.ListView = e.Form.Controls("lv_org")
If lv_host.Current Is Nothing
    Return
End If

Dim Result As DialogResult

Result = MessageBox.Show("确认删除?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

If Result = DialogResult.Yes Then
    Dim dr As DataRow = lv_host.Current.Tag 'drAS2FCI
    dr("_IsDeleted") = True
    dr.Save
    Dim dp As DataRow = lv_org.Current.Tag
    Functions.Execute("RebuildHostList",dp("_Identify"))    
End If

应用管理_lv_host_DoubleClick

Dim dr As DataRow = e.Sender.Current.Tag 'drAS2FCI 
Dim dic As New Dictionary(Of String,String)
dic.Add("selected_host",CStr(dr("functionalci_identify")))
Functions.Execute("startForm","主机",dic)

应用管理_lv_org_RowActivate

Dim dr As DataRow = e.Sender.Current.Tag
Dim dic As New Dictionary(Of String,String)
dic.Add("selected_app",CStr(dr("_Identify")))
'MessageBox.Show(dic("selected_app"))
Functions.Execute("startForm","应用系统编辑",dic)

应用管理_lv_org_RowSelectionChanged

Dim btn As WinForm.Button = e.Form.Controls("btn_host_add")
If e.Sender.Current Is Nothing
    btn.Enabled = False
    Return
End If
Dim dr As DataRow = e.Sender.Current.Tag
btn.Enabled = True
'MessageBox.Show("(RowSelectionChanged):" & dr("_Identify"))
Functions.Execute("RebuildHostList",dr("_Identify"))

应用管理_onResult_Click

Select Case Functions.Execute("GetPerformCode",e.Sender)
    
    Case Nothing
        '重新加载组织tree
        Dim tv_search As WinForm.TextBox = e.Form.Controls("tv_search_org")
        Dim tr_org As WinForm.TreeView = e.Form.Controls("tr_org")
        tv_search.Text = ""
        Functions.Execute("FilOrgTree",tr_org,"")
        tr_org.Nodes(0).Expand
End Select

应用管理_tr_org_AfterSelectNode

'应用系统列表
Dim node As WinForm.TreeNode = e.Sender.SelectedNode
Dim lv_org As WinForm.ListView =  e.Form.Controls("lv_org")
Dim tabs As WinForm.TabControl = e.Form.Controls("tab1")
Dim tab_org As WinForm.TabPage = tabs.TabPages("tab_org")
Dim cln() As String = {"name","organization","status","start_date","sla"}
Dim clt() As String = {"应用名称", "归属单位", "系统状态", "上线日期", "保障要求" }
Dim clw() As Integer = {240,150,75,95,95}
lv_org.MultiSelect = False
lv_org.StopRedraw() '暂停绘制
lv_org.Columns.Clear() '清除原来的列
lv_org.Rows.Clear() '清除原来的行
lv_org.Images.Clear() '清除原来的图片
lv_org.View = ViewMode.Details '显示模式为详细信息
lv_org.GridLines = True '显示网格线
Dim et_filter As WinForm.TextBox = e.Form.Controls("tv_search_org")
Dim filter As String = et_filter.Text.Trim

'lv_org.Images.AddSmallImage("check",)
Functions.Execute("CreateListColumn",lv_org,cln,clt,clw)
Dim count As Integer = 0
For Each  dd As DataRow In DataTables("Organization").Select("code like '" & node.Name & "%' And _IsDeleted = false And name like '%" & filter & "%'")
    
    Dim _id As Integer = dd("_Identify")
    'For Each dp As DataRow In DataTables("LnkApplicationSolutionToOrganization").Select("organization_identify = " & _id)
    For Each dp As DataRow In DataTables("LnkFunctionalCIToOrganization").Select("_IsDeleted = 0 And organization_identify = " & _id)
        
        Dim vr As  WinForm.ListViewRow =  lv_org.Rows.Add() '增加一行
        count = count + 1
        Dim dr As DataRow= DataTables("FunctionalCI").Find("_Identify = " & dp("functionalci_identify"))
        Dim dr_as As DataRow= DataTables("ApplicationSolution").Find("id= " & dp("functionalci_identify"))
        For Each cl As String In cln '逐列取值
            Select Case cl
                Case cln(0)
                    vr(cl) = dr("name")
                Case cln(1)
                    vr(cl) =  DataTables("Organization").Find("_Identify = " & dp("organization_identify"))("name")
                Case cln(2)
                    vr(cl) = Functions.Execute("TransCode","应用程序状态",dr_as("code_application_status"))
                Case cln(3)
                    vr(cl) = dr("move2production")
                Case cln(4)
                    vr(cl) = Functions.Execute("TransCode","保障要求",dr_as("code_sla"))
            End Select
            vr.Tag= dr '将DataRow赋值给ListViewRow的Tag属性,将二者联系起来
        Next
    Next
    
Next
tab_org.Text = "应用系统(" & count & ")"
lv_org.ResumeRedraw() '恢复绘制
Functions.Execute("RebuildHostList","-1")

应用管理_tv_search_org_KeyDown

If e.KeyCode = Keys.Enter Then
    Functions.Execute("ClickForSearch")
End If


