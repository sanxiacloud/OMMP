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
                Dim dr As DataRow = DataTables(table).Find(C_ID & " = " & id)
                dr(C__ISDELETED) = True
                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(table & "->Delete:" & ex.Message)
            End Try

            Return result
        End Function


        Protected Function FindRow(ByVal table As String, ByVal id As Integer) As Object
            Dim item As New Object()
            Try
                Dim dr As DataRow = DataTables(table).Find(C_ID & " = " & id)

                If dr IsNot Nothing Then
                    item = SetProperties(dr)
                End If

            Catch ex As Exception
                Output.Show(table & "->FindRow:" & ex.Message)
            End Try

            Return item
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

        ' 需要在各 finaclass 中实现
        Protected MustOverride Function SetProperties(ByVal dr As DataRow) As Object

        Protected MustOverride ReadOnly Property TABLE_NAME() As String

    End Class
End Namespace
