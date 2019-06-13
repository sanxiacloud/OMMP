Imports System.Reflection
Imports ommp.dto
Imports Foxtable

Namespace dao
    Public MustInherit Class BaseDAO

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

        Protected Function DeleteObject(ByVal table As String, ByVal id As Integer) As Boolean
            Dim result As Boolean = False
            Try
                Dim col As String = C__IDENTIFY
                If DataTables(table).DataCols.Contains(C_ID) Then
                    col = C_ID
                End If

                Dim dr As DataRow = DataTables(table).Find(col & " = " & id)

                dr(C__ISDELETED) = True
                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(table & "->Delete:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function FindRows(ByVal table As String, ByVal filter As String, ByVal sort As String) As IList(Of Object)
            Dim lists As IList(Of Object) = New Generic.List(Of Object)()

            Try
                Dim drs As List(Of DataRow)
                Dim item As Object
                If sort IsNot Nothing Then
                    drs = DataTables(table).Select(filter, sort)
                Else
                    drs = DataTables(table).Select(filter)
                End If
                For Each dr As DataRow In drs
                    item = SetProperties(dr)
                    lists.Add(item)
                Next
            Catch ex As Exception
                Output.Show(table & "->FindRows:" & ex.Message)
            End Try

            Return lists
        End Function


        Protected Function FindRow(ByVal table As String, ByVal id As Integer) As Object
            Dim item As New Object()
            Try
                Dim col As String = C__IDENTIFY
                If DataTables(table).DataCols.Contains(C_ID) Then
                    col = C_ID
                End If

                Dim dr As DataRow = DataTables(table).Find(col & " = " & id)

                If dr IsNot Nothing Then
                    item = SetProperties(dr)
                End If

            Catch ex As Exception
                Output.Show(table & "->FindRow:" & ex.Message)
            End Try

            Return item
        End Function

        Public Function FindObject2(Of T As {New})(ByVal id As Integer) As T
            Dim item As New T()

            Try
                Dim col As String = C__IDENTIFY
                If DataTables(item.GetType().Name).DataCols.Contains(C_ID) Then
                    col = C_ID
                End If

                Dim dr As DataRow = DataTables(item.GetType().Name).Find(col & " = " & id)

                If dr IsNot Nothing Then
                    For Each info As PropertyInfo In item.GetType().GetProperties()
                        info.SetValue(item, dr(info.Name), Nothing)
                    Next
                End If

            Catch ex As Exception
                Output.Show(item.GetType().Name & "(DAO) : " & ex.StackTrace)
            End Try

            Return item
        End Function

        Public Function FindList2(Of T As {New})(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of T)
            Dim lists As IList(Of T) = New Generic.List(Of T)()
            Dim item As New T()

            Try
                Dim drs As List(Of DataRow)

                If sort IsNot Nothing Then
                    drs = DataTables(item.GetType().Name).Select(filter, sort)
                Else
                    drs = DataTables(item.GetType().Name).Select(filter)
                End If

                For Each dr As DataRow In drs
                    For Each info As PropertyInfo In item.GetType().GetProperties()
                        info.SetValue(item, dr(info.Name), Nothing)
                    Next

                    lists.Add(item)
                Next
            Catch ex As Exception
                Output.Show(item.GetType().Name & "(DAO) : ")
                Output.Show(ex.Message)
                Output.Show(ex.StackTrace)
            End Try

            Return lists
        End Function

        ' 需要在各 finaclass 中实现
        Protected MustOverride Function SetProperties(ByVal dr As DataRow) As Object

        Protected MustOverride ReadOnly Property TABLE_NAME() As String

    End Class
End Namespace
