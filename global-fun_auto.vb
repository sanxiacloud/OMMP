'内部函数


自定义函数

'''AddChildren 组织树生成子节点

Dim dr As DataRow = args(0)
Dim nd As WinForm.TreeNode = args(1)
Dim len As Integer =args(2)

Dim code As String = dr("code")
len = len + 2
Dim dp As DataRow = dr.DataTable.Find("code = " & code.SubString(0,len))

If nd.Nodes.Contains(dp("code")) = False Then '判断是否存在节点
    Dim sCode As String = dp("code")
    Dim count = dp.DataTable.Select("code like '" & sCode & "%' And Len(code) = " & sCode.Length + 3 ).Count
    nd =  nd.Nodes.Add(dp("code"),IIF(count > 0,dp("name") & "(" & count & ")",dp("name")))
End If

If len < code.Length Then
    Functions.Execute("AddOrgChild",dr,nd,len)
End If

'''OrgCode 重新生成所有组织code

'基于层级关系设定组织编码
Dim zz As Table = Tables("Organization")
Dim i As Integer
'设定一级单位
zz.Filter="parent_identify Is Null"
i=0
For Each r As Row In zz.Rows
    i=i+1
    r("_code") = Format(i,"00")
Next
'设定组织同级编码
DataTables("Organization").LoadOrder = "_Identify"
DataTables("Organization").Load
For Each dr As DataRow In DataTables("Organization").DataRows
    dr("code") = ""
    zz.Filter="parent_identify = " & dr("_Identify")
    i=0
    For Each r As Row In zz.Rows
        i=i+1
        r("_code") = Format(i,"000")
    Next
Next
zz.Filter=""
'拼接code
For Each dr As DataRow In DataTables("Organization").DataRows
    dr("code")=Functions.Execute("GetParent",dr,"")
Next

'''组织	GetParent 查找父级组织

Dim dr As DataRow = args(0) '查找的组织
Dim code As String = args(1)'拼接code
code = dr("_code") & code
If dr.IsNull("parent_identify")  Then
    Return code
Else
    Dim pId = dr("parent_identify")
    Dim pDr As DataRow
    pDr = DataTables("Organization").Find("_Identify = " & pId)
    Return Functions.Execute("GetParent",pDr,code)
End If

'''AddOrgChild 添加组织树子节点

Dim dr As DataRow = args(0)
Dim nd As WinForm.TreeNode = args(1)
Dim len As Integer =args(2)


Dim code As String = dr("code")
len = len + 3
Dim dp As DataRow = dr.DataTable.Find("code = '" & code.SubString(0,len) & "'And _IsDeleted = false")

If nd.Nodes.Contains(dp("code")) = False Then '判断是否存在节点
    nd = nd.Nodes.Add(dp("code"),dp("name"))
Else
    nd = nd.Nodes(dp("code"))
End If


If len < code.Length Then
    Functions.Execute("AddOrgChild",dr,nd,len)
End If

'''FilOrgTree 重载组织树

Dim tr As WinForm.TreeView = args(0)
Dim filter As String = args(1)
Dim nd As WinForm.TreeNode
Dim dt As DataTable = DataTables("Organization")

Dim drs As List(Of DataRow) = dt.Select("name like '%" & filter & "%' And _IsDeleted = false","code")
If drs.Count = 0 Then
    MessageBox.Show("未找到相关组织.")
Else
    tr.StopRedraw()
    tr.Nodes.Clear
    For Each dr As DataRow In drs '循环筛选组织
        Dim code  As String = dr("code")
        Dim dp As DataRow = dt.Find("code = '" & code.SubString(0,2) & "'")
        If tr.Nodes.Contains(dp("code")) = False Then '加入根节点
            nd =  tr.Nodes.Add(dp("code"),dp("name"))
        Else
            nd = tr.Nodes(dp("code"))
            
        End If
        If code.Length > 2 Then '加入子节点
            Functions.Execute("AddOrgChild",dr,nd,2)
        End If
    Next
    
    For Each node As WinForm.TreeNode In tr.AllNodes
        If node.Nodes.Count > 0
            node.Text = node.Text & "(" & node.Nodes.Count & ")"
        End If
    Next
    
    tr.ResumeRedraw()
End If

''' CheckEditList 

Dim lv_org As WinForm.ListView =  args(0)
Dim cls() As String = args(1)
Dim drs As DataRowCollection = args(2)
lv_org.StopRedraw() '暂停绘制
lv_org.Columns.Clear() '清除原来的列
lv_org.Rows.Clear() '清除原来的行
lv_org.Images.Clear() '清除原来的图片
lv_org.View = ViewMode.Details '显示模式为详细信息
lv_org.GridLines = True '显示网格线

For i As Integer = 0 To  cls.Length - 1  '生成列,添加查看,修改
    Dim c As WinForm.ListViewColumn = lv_org.Columns.Add()
    c.Text = cls(i) '指定列标题
    c.Name = cls(i) '指定列名
    If i = cls.Length - 1
        Dim check As WinForm.ListViewColumn = lv_org.Columns.Add()
        Dim edit As WinForm.ListViewColumn = lv_org.Columns.Add()
        check.Text = "查看"
        check.Name = "check"
        edit.Text = "修改"
        edit.name = "edit"
    End If
Next


For Each dr As DataRow In drs
    Dim vr As  WinForm.ListViewRow =  lv_org.Rows.Add() '增加一行
    For Each cl As String In cls '逐列取值
        vr(cl) = dr(cl)
    Next
    vr.Tag= dr '将DataRow赋值给ListViewRow的Tag属性,将二者联系起来
Next


lv_org.ResumeRedraw() '恢复绘制

''' CountOrgApps 计算组织所属系统数

Dim _id As Integer = args(0)
Dim dt As DataTable = DataTables("LnkApplicationToOrganization")

Return   dt.Select("organization_identify = " & _id).Count

通用工具类	CreateListColumn

Dim lv As WinForm.ListView = args(0)
Dim names() As String = args(1)
Dim texts() As String = args(2)
Dim wds() As Integer = args(3)

For i As Integer = 0 To names.Length - 1
    Dim c As WinForm.ListViewColumn = lv.Columns.Add()
    c.Text = texts(i)
    c.Name = names(i)
    If wds Is Nothing = False 
        c.Width = wds(i)
    End If
Next

''' 通用工具类	StartForm

Dim _toName As String = args(0) '跳转窗口名称
If _toName Is Nothing Or _toName.Length = 0 Then
    MessageBox.Show("OpenForm方法参数_toName不能为空")
    Return False
End If

Dim _form As WinForm.Form = Forms(_toName)

If _form Is Nothing
    MessageBox.Show("不存在的窗口:" & _toName)
    Return False
End If

Dim _dic As Dictionary(Of String,String) = args(1) '跳转参数

If _dic Is Nothing = False
    Dim dic As Dictionary(Of String,String)
    If PARAMS.ContainsKey(_toName)
        dic = PARAMS(_toName)
    Else
        dic = New Dictionary(Of String,String)
        PARAMS.Add(_toName,dic)
    End If
    
    For Each _key As String In _dic.Keys
        Dim _cKey As String = "params_" &_key
        If dic.ContainsKey(_cKey)
            dic(_cKey) = _dic(_key)
        Else
            dic.Add(_cKey,_dic(_key))
        End If
    Next
End If
_form.Show
Return True

''' 通用工具类	StartFormForResult

Dim _fromName As WinForm.Form = args(0) '当前窗口名称
Dim _toName As String = args(1) '跳转窗口名称
Dim _dic As Dictionary(Of String,String) = args(2) '跳转参数
Dim _array() As String = args(3) '返回参数


If _toName Is Nothing Or _toName.Length = 0 Then
    MessageBox.Show("OpenForm方法参数_toName不能为空")
    Return False
End If

Dim _form As WinForm.Form = Forms(_toName)

If _form Is Nothing
    MessageBox.Show("不存在的窗口:" & _toName)
    Return False
End If

If _array Is Nothing Or _array.Length = 0 Then
    MessageBox.Show("回调参数不能为空")
    Return False
End If


If _dic Is Nothing = False
    Dim dic As Dictionary(Of String,String)
    If PARAMS.ContainsKey(_toName)
        dic = PARAMS(_toName)
    Else
        dic = New Dictionary(Of String,String)
        PARAMS.Add(_toName,dic)
    End If
    For Each _key As String In _dic.Keys
        Dim _cKey As String = "params_" &_key
        If dic.ContainsKey(_cKey)
            dic(_cKey) = _dic(_key)
        Else
            dic.Add(_cKey,_dic(_key))
        End If
    Next
End If

For Each _key As String In _array
    Dim dic As Dictionary(Of String,String)
    If PARAMS.ContainsKey(_fromName.Name)
        dic = PARAMS(_fromName.Name)
    Else
        dic = New Dictionary(Of String,String)
        PARAMS.Add(_fromName.Name,dic)
    End If
    Dim _cKey As String = "results_" & _toName & "_" &_key
    If dic.ContainsKey(_cKey)
        dic(_cKey) = Nothing
    Else
        dic.Add(_cKey,Nothing)
    End If
Next

_form.Show
Return True

''' 通用工具类	GetFormParameter

Dim _formName As String = args(0)
Dim _key As String = args(1)
Dim _cKey As String =  "params_" & _key
Dim dic As Dictionary(Of String,String)
If PARAMS.ContainsKey(_formName)
    dic = PARAMS(_formName)
Else
    dic = New Dictionary(Of String,String)
    PARAMS.Add(_formName,dic)
End If
If dic.ContainsKey(_cKey) = False
    Return Nothing
Else
    Return dic(_cKey)
    
End If

通用工具类	TransCode

Dim dt As DataTable = DataTables("Code")
Dim _type As String = args(0) 'code类型
Dim _code As Integer = args(1) 'code码
Dim r  As String
Dim dr As DataRow = dt.Find("t = '" & _type & "' And v = " & _code )
If dr Is Nothing
    r = "参数错误"
Else
    r = dr("label")
End If
Return r

''' 通用工具类	GetFormResult

Dim _cName As WinForm.Form = args(0)
Dim _fName As String = args(1)
Dim _key As String = args(2)
Dim dic As Dictionary(Of String,String)
If PARAMS.ContainsKey(_cName.Name)
    dic = PARAMS(_cName.Name)
Else
    Return Nothing
End If
Dim _cKey As String =   "results_" & _fName & "_" &_key
If dic.ContainsKey(_cKey) = False
    Return Nothing
Else
    Return dic(_cKey)
    
End If

''' 通用工具类	SetFormResult

'设置窗口返回参数
Dim _cName As WinForm.Form = args(0) '当前窗口
Dim _rName As String = args(1) '设置返回参数窗口
Dim _dic As Dictionary(Of String,String) = args(2)

If _rName Is Nothing Or _rName.Length = 0 Then
    MessageBox.Show("setFormResult方法参数_rForm不能为空")
    Return False
End If

Dim _form As WinForm.Form = Forms(_rName)

If _form Is Nothing
    MessageBox.Show("不存在的窗口:" & _rName)
    Return False
End If

If _dic Is Nothing = False
    Dim dic As Dictionary(Of String,String)
    If PARAMS.ContainsKey(_rName)
        dic = PARAMS(_rName)
    Else
        dic = New Dictionary(Of String,String)
        PARAMS.Add(_rName,dic)
    End If
    For Each _key As String In _dic.Keys
        Dim _cKey As String = "results_" & _cName.Name & "_" &_key
        If dic.ContainsKey(_cKey)
            dic(_cKey) = _dic(_key)
        End If
    Next
    
    
End If


Dim btn As WinForm.Button = _form.Controls("onResult")
If btn Is Nothing = False
    btn.PerformClick
End If

''' 通用工具类	SetFormParameter

Dim _formName As String = args(0)
Dim _key As String = args(1)
Dim _value As String = args(2)
Dim _cKey As String =  "params_" & _key
Dim dic As Dictionary(Of String,String)
If PARAMS.ContainsKey(_formName)
    dic = PARAMS(_formName)
Else
    dic = New Dictionary(Of String,String)
    PARAMS.Add(_formName,dic)
End If
If dic.ContainsKey(_cKey)
    dic(_cKey) = _value
Else
    dic.Add(_cKey,_value)
    
End If

''' 通用工具类	CleanFormParams

Dim _form As String = args(0)
If PARAMS.ContainsKey(_form)
    PARAMS.Remove(_form)
End If

''' 组织	ClickForSearch

Dim tv_search As WinForm.TextBox = Forms("应用管理").Controls("tv_search_org")
Dim tr_org As WinForm.TreeView = Forms("应用管理").Controls("tr_org")
tv_search.Text=tv_search.Text.Trim

If tv_search.Text.Length = 0 Then
  MessageBox.Show("查询内容不能为空!")
Else
  Functions.Execute("FilOrgTree",tr_org,tv_search.Text)
  tr_org.ExpandAll
End If

''' 变更操作	ChangeOpCreate

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

''' 变更操作	ChangeOpSetAtt

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

''' 测试	Test

MessageBox.Show(Date.Now)
MessageBox.Show(Date.Today)

''' CalcCode 编辑、添加组织生成code

Dim parentId As String = args(0)
Dim count As Integer = DataTables("Organization").Select("parent_identify = " & parentId).Count
Return Format(count+1,"000")

''' PerformResultClick 回调函数button调用方法

Dim _form As String = args(0)
Dim perform_code As String = args(1)
Dim btn As WinForm.Button = Forms(_form).Controls("onResult")
Dim key As String = _form & "-onResult"
If PERFORMS .ContainsKey(key)
    PERFORMS(key) = perform_code
Else
    PERFORMS.Add(key ,perform_code)
End If
btn.PerformClick '触发回调事件

''' GetPerformCode 回调函数id（未使用）

Dim btn As WinForm.Button = args(0)
Dim key As String = btn.Form.Name & "-onResult"
If PERFORMS .ContainsKey(key)
    Return PERFORMS(key)
Else
    Return Nothing
End If

''' RebuildAppList 重载应用列表

'应用系统列表
Dim e As WinForm.Form = Forms("应用管理")
Dim node As WinForm.TreeNode = e.Controls("tr_org").SelectedNode
Dim lv_org As WinForm.ListView =  e.Controls("lv_org")
Dim tabs As WinForm.TabControl = e.Controls("tab1")
Dim tab_org As WinForm.TabPage = tabs.TabPages("tab_org")
Dim cln() As String = {"name","organization","status","start_date","sla"}
Dim clt() As String = {"应用名称", "归属单位", "系统状态", "上线日期", "保障要求" }
Dim clw() As Integer = {240,150,75,95,95}
lv_org.StopRedraw() '暂停绘制
lv_org.Columns.Clear() '清除原来的列
lv_org.Rows.Clear() '清除原来的行
lv_org.Images.Clear() '清除原来的图片
lv_org.View = ViewMode.Details '显示模式为详细信息
lv_org.GridLines = True '显示网格线


'lv_org.Images.AddSmallImage("check",)
Functions.Execute("CreateListColumn",lv_org,cln,clt,clw)
Dim count As Integer = 0
For Each  dd As DataRow In DataTables("Organization").Select("code like '" & node.Name & "%' And _IsDeleted = false")
    
    Dim _id As Integer = dd("_Identify")
    'For Each dp As DataRow In DataTables("LnkApplicationSolutionToOrganization").Select("organization_identify = " & _id)
    For Each dp As DataRow In DataTables("LnkFunctionalCIToOrganization").Select("_IsDeleted = 0 And organization_identify = " & _id)
        
        Dim vr As  WinForm.ListViewRow =  lv_org.Rows.Add() '增加一行
        count = count + 1
        Dim dr As DataRow= DataTables("FunctionalCI").Find("_Identify = " & dp("functionalci_identify"))
        Dim dr_as As DataRow= DataTables("ApplicationSolution").Find("id = " & dp("functionalci_identify"))
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
            vr.Tag = dr '将DataRow赋值给ListViewRow的Tag属性,将二者联系起来
        Next
    Next
    
Next
tab_org.Text = "应用系统(" & count & ")"
lv_org.ResumeRedraw() '恢复绘制

''' RebuildHostList 重新绘制主机列表

Dim e As WinForm.Form = Forms("应用管理")
'Dim dr As DataRow = args(0)
Dim appId As String = args(0)
'Dim appId As String = IIF(dr Is Nothing,"0",dr("_Identify"))
Dim lv_host As WinForm.ListView = e.Controls("lv_host")

'主机
Dim tabs As WinForm.TabControl = e.Controls("tab3")
Dim tab_host As WinForm.TabPage = tabs.TabPages("tab_host")
Dim cln() As String = {"name","ip","start_date","description"}
Dim clt() As String = {"主机名称","IP","上线日期","描述"}
Dim clw() As Integer = {240,120,120,120}
lv_host.StopRedraw() '暂停绘制
lv_host.Columns.Clear() '清除原来的列
lv_host.Rows.Clear() '清除原来的行
lv_host.Images.Clear() '清除原来的图片
lv_host.View = ViewMode.Details '显示模式为详细信息
lv_host.GridLines = True '显示网格线

'lv_org.Images.AddSmallImage("check",)
Functions.Execute("CreateListColumn",lv_host,cln,clt,clw)

'If appId > 0
    'MessageBox.Show("appid = " & appId )
'End If

Dim count As Integer = 0
For Each drAS2FCI As DataRow In DataTables("LnkApplicationSolutionToFunctionalCI").Select("_IsDeleted = 0 And applicationsolution_identify = " & appId)
        Dim drFCI As DataRow = DataTables("FunctionalCI").Find("_Identify = " & drAS2FCI("functionalci_identify"))
        Dim drVM As DataRow = DataTables("VirtualMachine").Find("id = " & drAS2FCI("functionalci_identify"))
        Dim drIP As DataRow = DataTables("IPAddressv4").Find("id = " & drVM ("managementip_identify"))
        Dim vr As  WinForm.ListViewRow =  lv_host.Rows.Add() '增加一行
        count = count +1
        'MessageBox.Show("count = " & count)
        'MessageBox.Show("functionalci_identify = " & drAS2FCI("functionalci_identify"))
        'MessageBox.Show("ip = " & drIP("ip"))
        For Each cl As String In cln '逐列取值            
            Select Case cl
                Case cln(0)
                    vr(cl) = drFCI("name")
                Case cln(1)                    
                    vr(cl) = drIP("ip")
                Case cln(2)
                    vr(cl) = drFCI("move2production")
                Case cln(3)
                    vr(cl) = drFCI("description")
            End Select  
            vr.Tag= drAS2FCI '将DataRow赋值给ListViewRow的Tag属性,将二者联系起来
        Next        
Next
    
tab_host.Text = "主机(" & count & ")"
lv_host.ResumeRedraw() '恢复绘制


