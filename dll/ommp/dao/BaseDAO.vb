Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class BaseDAO

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

        Protected Function DeleteObject(ByVal table As Integer, ByVal id As Integer) As Boolean
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

    End Class
End Namespace
