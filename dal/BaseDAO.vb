Imports System.Reflection
Imports ommp.dal.dto
Imports Foxtable
Imports log4net

Namespace dal.dao
    Public Class BaseDAO

        Private Shared ReadOnly log As ILog = LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        ReadOnly Property CONNECTION_NAME() As String
            Get
                Return "CMDB"
            End Get
        End Property

        ReadOnly Property C_ID() As String
            Get
                Return "id"
            End Get
        End Property

        ReadOnly Property C__ISDELETED() As String
            Get
                Return "_IsDeleted"
            End Get
        End Property

        ReadOnly Property C__IDENTIFY() As String
            Get
                Return "_Identify"
            End Get
        End Property

        ReadOnly Property C_FINALCLASS() As String
            Get
                Return "finalclass"
            End Get
        End Property

        ReadOnly Property S_LNK() As String
            Get
                Return "Lnk"
            End Get
        End Property

        ReadOnly Property S_TO() As String
            Get
                Return "To"
            End Get
        End Property

        Protected Sub AddQueryTableCols(Of T As New)(ByRef builder As SQLJoinTableBuilder)
            Dim finalClass As New T()

            For Each info As PropertyInfo In finalClass.GetType().GetProperties()
                If info.Name.Equals(C__ISDELETED) Or info.Name.Equals(C_ID) Then
                    builder.AddCols(finalClass.GetType().Name & "." & info.Name)
                Else
                    builder.AddCols(info.Name)
                End If
            Next
        End Sub

        Protected Function DeleteObject(Of T As New)(ByVal id As Integer) As Boolean
            Dim result As Boolean = False
            Dim item As New T()
            Dim table_name As String = item.GetType().Name

            Try
                Dim col As String = C__IDENTIFY
                If DataTables(table_name).DataCols.Contains(C_ID) Then
                    col = C_ID
                End If

                Dim dr As DataRow = DataTables(table_name).Find(col & " = " & id)

                dr(C__ISDELETED) = True
                dr.Load()

                result = True
            Catch ex As Exception
                log.Error(table_name & "(DAO) -> DeleteObject ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return result
        End Function

        Protected Function FindList(Of T As New)(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of T)
            Dim lists As IList(Of T) = New List(Of T)()
            Dim item As New T()
            Dim table_name As String = item.GetType().Name
            Dim theFilter As String = String.Format("{0} AND {1}=False", filter, C__ISDELETED)
            Output.Show(String.Format("theFilter = [{0}]", theFilter))
            Try
                Dim drs As List(Of DataRow)

                If sort IsNot Nothing Then
                    drs = DataTables(table_name).Select(theFilter, sort)
                Else
                    drs = DataTables(table_name).Select(theFilter)
                End If

                For Each dr As DataRow In drs
                    For Each info As PropertyInfo In item.GetType().GetProperties()
                        info.SetValue(item, dr(info.Name), Nothing)
                        Output.Show(String.Format("{0} = {1}", info.Name, dr(info.Name)))
                    Next

                    lists.Add(item)
                Next
                Output.Show(String.Format("lists.count = {0}", lists.Count))
            Catch ex As Exception
                log.Error(table_name & "(DAO) -> FindList ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return lists
        End Function

        Protected Function UpdateObject(Of T As New)(ByVal item As T) As Boolean
            Dim o As New T()
            Dim table_name As String = o.GetType().Name
            Dim result As Boolean = False
            Dim filter As String = ""
            Dim col As String = C__IDENTIFY
            Try
                If DataTables(table_name).DataCols.Contains(C_ID) Then
                    col = C_ID
                End If

                '传入的对象中只给出 _Identify 值
                For Each info As PropertyInfo In item.GetType().GetProperties()
                    If info.Name.Equals(C__IDENTIFY) Then
                        filter = col & "=" & info.GetValue(item, Nothing)
                    End If
                Next

                log.Debug("1. filter = " & filter)
                Dim dr As DataRow = DataTables(table_name).Find(filter)
                If dr IsNot Nothing Then

                    For Each info As System.Reflection.PropertyInfo In item.GetType().GetProperties()
                        If DataTables(table_name).DataCols.Contains(info.Name) Then
                            log.Debug("2. " & info.Name & ":" & info.PropertyType.Name & " = " & info.GetValue(item, Nothing))
                            ' finalclass 列 和 _IsDeleted 列不可修改
                            If Not info.Name.Equals(C_FINALCLASS) Or info.Name.Equals(C__ISDELETED) Then
                                If (info.PropertyType Is GetType(String)) And info.GetValue(item, Nothing) IsNot Nothing Then
                                    dr(info.Name) = info.GetValue(item, Nothing)
                                ElseIf (info.PropertyType Is GetType(Int32)) And Not info.GetValue(item, Nothing) = Nothing Then
                                    dr(info.Name) = info.GetValue(item, Nothing)
                                ElseIf (info.PropertyType Is GetType(DateTime)) And Not info.GetValue(item, Nothing) = Nothing Then
                                    dr(info.Name) = info.GetValue(item, Nothing)
                                End If
                            End If
                        End If
                    Next

                    dr.Load()

                End If

                result = True
            Catch ex As Exception
                log.Error(table_name & "(DAO) -> UpdateObject ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return result
        End Function

        Protected Function InsertObject(Of T As New)(ByVal item As T) As Integer
            Dim o As New T()
            Dim table_name As String = o.GetType().Name
            Dim result As Integer = -1

            Try
                Dim dr As DataRow = DataTables(table_name).AddNew()

                For Each info As PropertyInfo In item.GetType().GetProperties()
                    If DataTables(table_name).DataCols.Contains(info.Name) Then
                        log.Debug(info.Name & ":" & info.GetValue(item, Nothing))
                        dr(info.Name) = info.GetValue(item, Nothing)
                    End If
                Next
                dr(C__ISDELETED) = False ' 默认设置为 False
                dr.Load()

                Dim col As String = C__IDENTIFY
                If DataTables(table_name).DataCols.Contains(C_ID) Then
                    col = C_ID
                End If

                result = dr(col)
            Catch ex As Exception
                log.Error(table_name & "(DAO) -> InsertObject ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return result
        End Function

        Protected Function FindObject(Of T As New)(ByVal filter As String) As T
            Dim item As New T()
            Dim table_name As String = item.GetType().Name

            Try
                Dim col As String = C__IDENTIFY
                If DataTables(table_name).DataCols.Contains(C_ID) Then
                    col = C_ID
                End If
                log.Debug("table_name = " & table_name)
                log.Debug("filter = " & filter & " AND " & C__ISDELETED & " = False")
                Dim dr As DataRow = DataTables(table_name).Find(filter & " AND " & C__ISDELETED & " = False")

                If dr IsNot Nothing Then
                    For Each info As PropertyInfo In item.GetType().GetProperties()
                        log.Debug("column_name = " & info.Name)
                        If DataTables(table_name).DataCols.Contains(info.Name) Then
                            info.SetValue(item, dr(info.Name), Nothing)
                        ElseIf info.Name.Equals(C__IDENTIFY) Then
                            log.Debug("_Identify = " & dr(C__IDENTIFY))
                            info.SetValue(item, dr(C__IDENTIFY), Nothing)
                        End If
                    Next
                Else
                    item = Nothing
                End If

            Catch ex As Exception
                log.Error(table_name & "(DAO) -> FindObject(ByVal filter As String) ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return item
        End Function

        Protected Function FindObject(Of T As New)(ByVal id As Integer) As T
            Dim item As New T()
            Dim table_name As String = item.GetType().Name

            Try
                Dim col As String = C__IDENTIFY

                If DataTables(table_name).DataCols.Contains(C_ID) Then
                    col = C_ID
                End If

                Dim filter As String = col & " = " & id

                item = FindObject(Of T)(filter)

            Catch ex As Exception
                log.Error(table_name & "(DAO) -> FindObject(ByVal id As Integer) ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return item
        End Function

        '测试查找一个对象
        Private Sub TestFindObject()
            Dim dao As New ommp.dal.dao.BaseDAO()
            Dim dto As ommp.dal.dto.Organization = dao.FindObject(Of ommp.dal.dto.Organization)(558)
            log.Info("code_org_type = " & dto.code_org_type)
            log.Info("Identify = " & dto._Identify)
            log.Info("parent_identify = " & dto.parent_identify)
            log.Info("name = " & dto.name)
            log.Info("code = " & dto.code)
            log.Info("parent_code = " & dto._code)
            log.Info("status = " & dto.status)
            log.Info("code_org_type = " & dto.code_org_type)
            log.Info("short_name = " & dto.short_name)
            log.Info("description = " & dto.description)
            log.Info("IsDeleted = " & dto._IsDeleted)
            log.Info("_sort = " & dto._sort)
        End Sub

        '测试添加一个对象(一级对象，未继承)
        Private Sub TestInsertObject()
            Dim dao As New ommp.dal.dao.BaseDAO()
            Dim dto As New ommp.dal.dto.Organization()
            Dim result As Integer

            dto.name = "测试组织1-20190613"
            dto.code = "00000001"
            dto._code = "00001"
            dto.status = True
            dto.short_name = "测1-0613"
            dto.code_org_type = 2
            dto.description = "测试组织1-描述"
            result = dao.InsertObject(Of ommp.dal.dto.Organization)(dto)
            log.Info(result)
        End Sub

        '修改组织
        Private Sub TestUpdateObject()
            Dim dao As ommp.dal.dao.BaseDAO = New ommp.dal.dao.BaseDAO()
            Dim result As Boolean = False
            Dim dto As ommp.dal.dto.Organization = dao.FindObject(Of ommp.dal.dto.Organization)(602)
            dto.code_org_type = 1
            dto.name = "测试组织-20190614 修改 2"
            result = dao.UpdateObject(Of ommp.dal.dto.Organization)(dto)
            log.Info(result)
        End Sub

        '删除一个对象 - 测试        
        Private Sub TestDeleteObject()
            Dim dao As New ommp.dal.dao.BaseDAO()
            log.Info(dao.DeleteObject(Of Organization)(599))
        End Sub

        '查询组织列表
        Private Sub TestFindList()
            Dim dao As New ommp.dal.dao.BaseDAO
            Dim lists As IList(Of ommp.dal.dto.Organization) = dao.FindList(Of ommp.dal.dto.Organization)("[name] Like '%三峡云%'", "name desc")
            log.Info("Count : " & lists.Count)
            For Each dto As ommp.dal.dto.Organization In lists
                log.Info("code_org_type = " & dto.code_org_type)
                log.Info("Identify = " & dto._Identify)
                log.Info("parent_identify = " & dto.parent_identify)
                log.Info("name = " & dto.name)
                log.Info("code = " & dto.code)
                log.Info("parent_code = " & dto._code)
                log.Info("status = " & dto.status)
                log.Info("code_org_type = " & dto.code_org_type)
                log.Info("short_name = " & dto.short_name)
                log.Info("description = " & dto.description)
                log.Info("IsDeleted = " & dto._IsDeleted)
                log.Info("_sort = " & dto._sort)
            Next
        End Sub

        '测试修改 属性
        Private Sub TestProperty()
            Dim item As New ommp.dal.dto.ApplicationSolution()
            item.name = "abc"
            item.id = 3
            item.move2production = DateTime.Now

            For Each info As System.Reflection.PropertyInfo In item.GetType().GetProperties()

                If (info.PropertyType Is GetType(String)) Then
                    log.Info(info.Name & ":" & info.PropertyType.Name)
                    If info.GetValue(item, Nothing) IsNot Nothing Then log.Info("--------------" & info.Name & "'s value is not nothing")

                ElseIf (info.PropertyType Is GetType(Int32)) Then
                    log.Info(info.Name & ":" & info.PropertyType.Name)
                    If info.GetValue(item, Nothing) > 0 Then log.Info("--------------" & info.Name & "'s value bigger than zero")

                ElseIf (info.PropertyType Is GetType(DateTime)) Then
                    log.Info(info.Name & ":" & info.PropertyType.Name)
                    If info.GetValue(item, Nothing) <> Nothing Then log.Info("--------------" & info.Name & "'s value not equal nothing")
                End If

            Next
        End Sub

    End Class
End Namespace
