Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class OrganizationDAO : Inherits BaseDAO

        Private Const TABLE_NAME As String = "Organization"

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Private Function SetProperties(ByVal dr As DataRow) As Organization
            Dim item As New Organization()

            item.Identify = dr("_Identify")
            item.parent_identify = dr("parent_identify")
            item.name = dr("name")
            item.code = dr("code")
            item.parent_code = dr("_code")
            item.status = dr("status")
            item.code_org_type = dr("code_org_type")
            item.short_name = dr("short_name")
            item.description = dr("description")
            item.IsDeleted = dr("_IsDeleted")
            item._sort = dr("_sort")

            Return item
        End Function

        Public Function Insert(ByVal obj As Organization) As Boolean
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

                dr("parent_identify") = obj.parent_identify
                dr("name") = obj.name
                dr("code") = obj.code
                dr("_code") = obj.parent_code
                dr("status") = obj.status
                dr("code_org_type") = obj.code_org_type
                dr("short_name") = obj.short_name
                dr("description") = obj.description
                If obj.IsDeleted = True Or obj.IsDeleted = False Then
                    dr("_IsDeleted") = obj.IsDeleted
                Else
                    dr("_IsDeleted") = False
                End If
                If obj._sort > 0 Then
                    dr("_sort") = obj._sort
                End If

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Output.Show("Insert is invoked successful!")

            Return result
        End Function

        Public Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of Organization)
            Dim lists As IList(Of Organization) = New Generic.List(Of Organization)()
            Try
                Dim drs As List(Of DataRow)
                If sort IsNot Nothing Then
                    drs = DataTables(TABLE_NAME).Select(filter, sort)
                Else
                    drs = DataTables(TABLE_NAME).Select(filter)
                End If
                For Each dr As DataRow In drs
                    lists.Add(SetProperties(dr))
                Next
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->FindList:" & ex.Message)
            End Try

            Return lists
        End Function

        Public Function FindObject(ByVal id As Integer) As Organization
            Dim item As New Organization()
            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).Find("_Identify = " & id)
                If dr IsNot Nothing Then
                    item = SetProperties(dr)
                End If
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->FindObject:" & ex.Message)
            End Try

            Return item
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean
            Dim result As Boolean = False
            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).Find("_Identify = " & id)
                dr("_IsDeleted") = True
                dr.Save()
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Delete:" & ex.Message)
            End Try

            Output.Show("Delete is invoked successful!")

            Return result
        End Function

        Public Function Update(ByVal obj As Organization) As Boolean
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).Find("_Identify = " & obj.Identify)
                If obj.parent_identify > 0 Then
                    dr("parent_identify") = obj.parent_identify
                End If
                If obj.name IsNot Nothing Then
                    dr("name") = obj.name
                End If
                If obj.code IsNot Nothing Then
                    dr("code") = obj.code
                End If
                If obj.parent_code IsNot Nothing Then
                    dr("_code") = obj.parent_code
                End If
                If obj.status = False Or obj.status = True Then
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
                If obj.IsDeleted = False Or obj.IsDeleted = True Then
                    dr("_IsDeleted") = obj.IsDeleted
                End If
                If obj._sort > 0 Then
                    dr("_sort") = obj._sort
                End If
                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Output.Show("Update is invoked successful!")

            Return result
        End Function

    End Class

End Namespace
