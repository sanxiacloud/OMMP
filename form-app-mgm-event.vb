'''主窗口事件

#Region main

Function AfterLoad(e)
    ' 初始化绘制左边
    Functions.Execute("ReDrawAppTvOrg")

    ' 初始化各个listview
    ' 主listview
    Dim lvApp As WinForm.ListView =  Forms("主窗口").Controls("lv_app_app")
    Dim colAppn() As String = {"name","organization","status","start_date","sla"} ' name
    Dim colAppt() As String = {"应用名称", "归属单位", "系统状态", "上线日期", "保障要求" } ' text
    Dim colAppw() As Integer = {240,150,75,95,95} ' 宽度
    Functions.Execute("InitListView", lvApp, colAppn, colAppt, colAppw)
    ' host listview
    Dim lvHost As WinForm.ListView = Forms("主窗口").Controls("lv_app_dev_host")
    Dim colHostn() As String = {"type", "name","ip","start_date","description"}
    Dim colHostt() As String = {"主机类型", "主机名称","IP","上线日期","描述"}
    Dim colHostw() As Integer = {100, 200,120,120,120}
    Functions.Execute("InitListView", lvHost, colHostn, colHostt, colHostw)
    ' #todo others

End Function

#End Region

#Region 应用系统tab

#Region 组织树状列表

#Region tv_app_org

Function AfterSelectNode(e)
    ' 重新绘制主lsitview
    Functions.Execute("ReDrawAppLvApp")
    Forms("主窗口").Controls("bt_app_org_mod").Enabled = True

End Function

#End Region

#Region bt_app_org_sch

Function Click(e)
    Functions.Execute("ReDrawAppTvOrg")
End Function 

#End Region

#Region bt_app_org_rfh

Function Click(e)
    Dim tv As WinForm.TreeView = Forms("主窗口").Controls("tv_app_org")
    Dim tbSch As WinForm.TextBox = Forms("主窗口").Controls("tb_app_org_sch")
    tbSch.Value = ""
    Functions.Execute("ReDrawAppTvOrg")
End Function 


#End Region

#End Region 组织树状列表

#Region 中间listview

#Region lv_app_app
' 行上双击或者回车
Function RowActivate(e)
    Dim dr As DataRow = e.Sender.Current.Tag
    Dim identify As String = dr("_Identify")
    Dim drAS As DataRow = Datatables("ApplicationSolution").
    SetFormParam("应用系统编辑", "type", "modify")
    SetFormParam("应用系统编辑", "orgId", "modify")
    SetFormParam("应用系统编辑", "_Identify", identify)
    SetFormParam("应用系统编辑", "type", "modify")



Dim dic As New Dictionary(Of String,String)
dic.Add("selected_app",CStr(dr("_Identify")))
'MessageBox.Show(dic("selected_app"))
Functions.Execute("startForm","应用系统编辑",dic)
End Function

' 行选择状态变化
Function RowSelectionChanged(e)
    Dim row As WinForm.ListViewRow = e.Sender.Current
    IF row IsNot Nothing Then
        Forms("主窗口").Controls("bt_app_app_del").Enabled = True
        Dim dr As DataRow = row.Tag
        Functions.Execute("ReDrawAppLvHost",dr("_Identify"))
    End IF
End Function

#End Region lv_app_app

#Region  bt_app_app_add

Function Click(e)
    SetFormParam("应用系统编辑", "orgId", e.Form.Controls("tv_app_org").SelectedNode.Tag)
    Forms("应用系统编辑").Open()
End Function

#End Region bt_app_app_add

#End Region 中间listview

#Region 右上tab控件

#Region host ListView

#Region lv_app_dev_host
Function RowSelectionChanged(e)
    Dim row As WinForm.ListViewRow = e.Sender.Current
    IF row IsNot Nothing Then
        Forms("主窗口").Controls("bt_app_host_del").Enabled = True        
    End IF
End Function

#End Region lv_app_dev_host

#Region checkbox
'两个checkbox事件相同
' 勾选状态改变，重新刷新数据
Function CheckedChanges(e)
    Dim row As WinForm.ListViewRow = Forms("主窗口").Controls("lv_app_app").Current
    Functions.Execute("ReDrawAppLvHost", row.Tag("_Identify"))
End Function

#End Region checkbox

#End Region host ListView

#End Region 右上tab控件

#End Region