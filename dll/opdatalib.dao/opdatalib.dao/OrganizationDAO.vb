Public Class OrganizationDAO

    Private Const TABLE_NAME As String = "Organization"

    Public Sub New()
        ' 构造函数，默认为空
    End Sub

    Shared Function Insert(ByVal obj As opdatalib.dto.Organization) As Boolean
        Dim result As Boolean = False

        Try
            Dim dr As Foxtable.DataRow = Foxtable.DataTables(TABLE_NAME).AddNew()
            dr("parent_identify") = obj.parent_identify
            dr("name") = obj.name
            dr("code") = obj.code
            dr("_code") = obj.parent_code
            dr("status") = obj.status
            dr("code_org_type") = obj.code_org_type
            dr("short_name") = obj.short_name
            dr("description") = obj.description
            dr("_IsDeleted") = False
            dr("_sort") = 0
            dr.Save()
            result = True
        Catch ex As Exception
            Foxtable.Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
        End Try

        Foxtable.Output.Show("Insert is invoked successful!")

        Return result
    End Function

    Shared Function Find(ByVal id As Integer) As opdatalib.dto.Organization
        Dim obj As opdatalib.dto.Organization = New opdatalib.dto.Organization()
        Try
            Dim dr As Foxtable.DataRow = Foxtable.DataTables(TABLE_NAME).Find("_Identify = " & id)
            If dr IsNot Nothing Then
                obj.Identify = dr("_Identify")
                obj.parent_identify = dr("parent_identify")
                obj.name = dr("name")
                obj.code = dr("code")
                obj.parent_code = dr("_code")
                obj.status = dr("status")
                obj.code_org_type = dr("code_org_type")
                obj.description = dr("description")
                obj.IsDeleted = dr("_IsDeleted")
                obj._sort = dr("_sort")
            End If
        Catch ex As Exception
            Foxtable.Output.Show(TABLE_NAME & "->Find:" & ex.Message)
        End Try

        Return obj
    End Function

    Shared Function Update(ByVal obj As opdatalib.dto.Organization) As Boolean
        Dim result As Boolean = False

        Try
            Dim dr As Foxtable.DataRow = Foxtable.DataTables(TABLE_NAME).Find("_Identify = " & obj.Identify)
            If obj.parent_identify > 0 Then
                dr("parent_identify") = obj.parent_identify
            End If
            If obj.name IsNot Nothing Then
                dr("name") = obj.name
            End If
            If obj.code IsNot Nothing Then
                dr("code") = obj.code
            End If
            If obj.code IsNot Nothing Then
                dr("_code") = obj.parent_code
            End If
            If obj.status = Nothing Then
                dr("status") = obj.status
            End If
            If obj.code_org_type > 0 Then
                dr("code_org_type") = obj.code_org_type
            End If
            If obj.short_name IsNot Nothing Then
                dr("short_name") = obj.short_name
            End If
            If obj.description IsNot Nothing Then
                dr("description") = obj.description
            End If
            If obj.IsDeleted = Nothing Then
                dr("_IsDeleted") = obj.IsDeleted
            End If
            If obj._sort > 0 Then
                dr("_sort") = obj._sort
            End If
            dr.Save()
            result = True
        Catch ex As Exception
            Foxtable.Output.Show(TABLE_NAME & "->Update:" & ex.Message)
        End Try

        Foxtable.Output.Show("Update is invoked successful!")

        Return result
    End Function

End Class
