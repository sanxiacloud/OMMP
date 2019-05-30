Public Module DAO

    Public Class OrganizationDAO

        Private Const TABLE_NAME As String = "Organization"

        Function Insert(ByVal obj As Organization) As Boolean
            Dim result As Boolean = False
            Foxtable.Output.Show("Insert is invoke")

            Try
                Dim dr As Foxtable.DataRow = Foxtable.DataTables(TABLE_NAME).AddNew()
                dr("name") = obj.name
                dr("code") = obj.code
                dr("status") = obj.status
                dr("parent_identify") = obj.parent_identify
                dr("short_name") = obj.short_name
                dr("description") = obj.description
                dr.Save()
                result = True
            Catch ex As Exception
                WriteLine(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

    End Class

End Module
