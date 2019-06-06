Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class OrganizationDAO : Inherits BaseDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Private Function SetProperties(ByVal dr As DataRow) As Organization
            Dim item As New Organization()

            item.Identify = dr(Organization.C__IDENTIFY)
            item.parent_identify = dr(Organization.C_PARENT_IDENTIFY)
            item.name = dr(Organization.C_NAME)
            item.code = dr(Organization.C_CODE)
            item.parent_code = dr(Organization.C__CODE)
            item.status = dr(Organization.C_STATUS)
            item.code_org_type = dr(Organization.C_CODE_ORG_TYPE)
            item.short_name = dr(Organization.C_SHORT_NAME)
            item.description = dr(Organization.C_DESCRIPTION)
            item.IsDeleted = dr(Organization.C__ISDELETED)
            item._sort = dr(Organization.C__SORT)

            Return item
        End Function

        ' 添加一个组织
        'Dim dao As ommp.dao.OrganizationDAO = New ommp.dao.OrganizationDAO()
        'Dim result As Boolean = False
        'Dim orgdto As New ommp.dto.Organization()
        'orgdto.name = "test abc"
        'orgdto.code = "001"
        'orgdto.IsDeleted = True
        'result = dao.Insert(orgdto)
        'Output.Show(result)
        Public Function Insert(ByVal obj As Organization) As Boolean
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(Organization.TABLE_NAME).AddNew()

                dr(Organization.C_PARENT_IDENTIFY) = obj.parent_identify
                dr(Organization.C_NAME) = obj.name
                dr(Organization.C_CODE) = obj.code
                dr(Organization.C__CODE) = obj.parent_code
                dr(Organization.C_STATUS) = obj.status
                dr(Organization.C_CODE_ORG_TYPE) = obj.code_org_type
                dr(Organization.C_SHORT_NAME) = obj.short_name
                dr(Organization.C_DESCRIPTION) = obj.description
                If obj.IsDeleted = True Or obj.IsDeleted = False Then
                    dr(Organization.C__ISDELETED) = obj.IsDeleted
                Else
                    dr(Organization.C__ISDELETED) = False
                End If
                If obj._sort > 0 Then
                    dr(Organization.C__SORT) = obj._sort
                End If

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(Organization.TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        '修改组织
        'Dim dao As ommp.dao.OrganizationDAO = New ommp.dao.OrganizationDAO()
        'Dim result As Boolean = False
        'Dim dto As ommp.dto.Organization = dao.FindObject(593)
        'dto.code_org_type = 2
        'dto.name = "test abc 2"
        'result  = dao.Update(dto)
        'Output.Show(result)
        Public Function Update(ByVal obj As Organization) As Boolean
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(Organization.TABLE_NAME).Find(Organization.C__IDENTIFY & " = " & obj.Identify)
                If obj.parent_identify >= 0 Then
                    dr(Organization.C_PARENT_IDENTIFY) = obj.parent_identify
                End If
                If obj.name IsNot Nothing Then
                    dr(Organization.C_NAME) = obj.name
                End If
                If obj.code IsNot Nothing Then
                    dr(Organization.C_CODE) = obj.code
                End If
                If obj.parent_code IsNot Nothing Then
                    dr(Organization.C__CODE) = obj.parent_code
                End If
                If obj.status = False Or obj.status = True Then
                    dr(Organization.C_STATUS) = obj.status
                End If
                If obj.code_org_type >= 0 Then
                    dr(Organization.C_CODE_ORG_TYPE) = obj.code_org_type
                End If
                If obj.short_name IsNot Nothing Then
                    dr(Organization.C_SHORT_NAME) = obj.short_name
                End If
                If obj.description IsNot Nothing Then
                    dr(Organization.C_DESCRIPTION) = obj.description
                End If
                If obj.IsDeleted = False Or obj.IsDeleted = True Then
                    dr(Organization.C__ISDELETED) = obj.IsDeleted
                End If
                If obj._sort >= 0 Then
                    dr(Organization.C__SORT) = obj._sort
                End If
                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(Organization.TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

        '删除一个组织
        'Dim dao As ommp.dao.OrganizationDAO = New ommp.dao.OrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.Delete(593)
        'Output.Show(result)
        Public Function Delete(ByVal id As Integer) As Boolean
            Dim result As Boolean = False
            Try
                Dim dr As DataRow = DataTables(Organization.TABLE_NAME).Find(Organization.C__IDENTIFY & " = " & id)
                dr(Organization.C__ISDELETED) = True
                dr.Save()
            Catch ex As Exception
                Output.Show(Organization.TABLE_NAME & "->Delete:" & ex.Message)
            End Try

            Return result
        End Function

        '查找一个组织
        'Dim dao As ommp.dao.OrganizationDAO = New ommp.dao.OrganizationDAO()
        'Dim dto As ommp.dto.Organization = dao.FindObject(593)
        'Output.Show("code_org_type = " & dto.code_org_type)
        Public Function FindObject(ByVal id As Integer) As Organization
            Dim item As New Organization()
            Try
                Dim dr As DataRow = DataTables(Organization.TABLE_NAME).Find(Organization.C__IDENTIFY & " = " & id)
                If dr IsNot Nothing Then
                    item = SetProperties(dr)
                End If
            Catch ex As Exception
                Output.Show(Organization.TABLE_NAME & "->FindObject:" & ex.Message)
            End Try

            Return item
        End Function

        '查询组织列表
        'Dim dao As new ommp.dao.OrganizationDAO
        'Dim lists As IList(Of ommp.dto.Organization) = dao.FindList("[name] Like '%三峡云%'", "name desc")
        'output.Show("Count : " & lists.Count )
        'For Each org As ommp.dto.Organization In lists 
        '    output.Show(org.name)
        'Next
        Public Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of Organization)
            Dim lists As IList(Of Organization) = New Generic.List(Of Organization)()
            Try
                Dim drs As List(Of DataRow)
                If sort IsNot Nothing Then
                    drs = DataTables(Organization.TABLE_NAME).Select(filter, sort)
                Else
                    drs = DataTables(Organization.TABLE_NAME).Select(filter)
                End If
                For Each dr As DataRow In drs
                    lists.Add(SetProperties(dr))
                Next
            Catch ex As Exception
                Output.Show(Organization.TABLE_NAME & "->FindList:" & ex.Message)
            End Try

            Return lists
        End Function

    End Class

End Namespace
