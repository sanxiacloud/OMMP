Imports System.Reflection
Imports ommp.dal.dto
Imports Foxtable
Imports log4net

Namespace dal.dao
    Public Class GenericBaseDAO(Of T As New)

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

        Protected Sub AddQueryTableCols(ByRef builder As SQLJoinTableBuilder)
            Dim finalClass As New T()

            For Each info As PropertyInfo In finalClass.GetType().GetProperties()
                If info.Name.Equals(C__ISDELETED) Or info.Name.Equals(C_ID) Then
                    builder.AddCols(finalClass.GetType().Name & "." & info.Name)
                Else
                    builder.AddCols(info.Name)
                End If
            Next
        End Sub

        Protected Function DeleteObject(ByVal id As Integer) As Boolean
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

        Protected Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of T)
            Dim lists As IList(Of T) = New Generic.List(Of T)()
            Dim item As New T()
            Dim table_name As String = item.GetType().Name
            Dim theFilter As String = filter & " AND " & C__ISDELETED & " = False"

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
                    Next

                    lists.Add(item)
                Next
            Catch ex As Exception
                log.Error(table_name & "(DAO) -> FindList ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return lists
        End Function

        Protected Function UpdateObject(ByVal item As T) As Boolean
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

        Protected Function InsertObject(ByVal item As T) As Integer
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

        Protected Function FindObject(ByVal filter As String) As T
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

    End Class
End Namespace
