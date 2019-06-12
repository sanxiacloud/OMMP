Imports ommp.dto
Imports Foxtable

Namespace dao

    ' 已全部测试完成
    '20190611 by Andy
    Public Class OrganizationDAO
        Inherits BaseDAO
        Implements IEntityDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return Organization.TABLE_NAME
            End Get
        End Property

        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object
            Dim item As New Organization()

            With item
                .Identify = dr(Organization.C__IDENTIFY)
                .parent_identify = dr(Organization.C_PARENT_IDENTIFY)
                .name = dr(Organization.C_NAME)
                .code = dr(Organization.C_CODE)
                .parent_code = dr(Organization.C__CODE)
                .status = dr(Organization.C_STATUS)
                .code_org_type = dr(Organization.C_CODE_ORG_TYPE)
                .short_name = dr(Organization.C_SHORT_NAME)
                .description = dr(Organization.C_DESCRIPTION)
                .IsDeleted = dr(Organization.C__ISDELETED)
                ._sort = dr(Organization.C__SORT)
            End With

            Return item
        End Function

        ' 添加一个组织
        'Dim dao As ommp.dao.OrganizationDAO = New ommp.dao.OrganizationDAO()
        'Dim result As Boolean = False
        'Dim dto As New ommp.dto.Organization()
        'dto.name = "测试组织20190611"
        'dto.code = "10001"
        'dto.IsDeleted = True
        'result = dao.Insert(dto)
        'Output.Show(result)
        Public Function Insert(ByVal o As Object) As Boolean Implements IEntityDAO.Insert
            Dim obj As Organization = CType(o, Organization)
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

                dr(C__ISDELETED) = False
                dr(Organization.C_PARENT_IDENTIFY) = obj.parent_identify
                dr(Organization.C_NAME) = obj.name
                dr(Organization.C_CODE) = obj.code
                dr(Organization.C__CODE) = obj.parent_code
                dr(Organization.C_STATUS) = obj.status
                dr(Organization.C_CODE_ORG_TYPE) = obj.code_org_type
                dr(Organization.C_SHORT_NAME) = obj.short_name
                dr(Organization.C_DESCRIPTION) = obj.description
                If obj._sort > 0 Then
                    dr(Organization.C__SORT) = obj._sort
                End If

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        '修改组织
        'Dim dao As ommp.dao.OrganizationDAO = New ommp.dao.OrganizationDAO()
        'Dim result As Boolean = False
        'Dim dto As ommp.dto.Organization = dao.FindObject(595)
        'dto.code_org_type = 2
        'dto.name = "测试组织20190611修改"
        'result  = dao.Update(dto)
        'Output.Show(result)
        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As Organization = CType(o, Organization)
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).Find(C__IDENTIFY & " = " & obj.Identify)
                If dr IsNot Nothing Then
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
                End If
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

        '删除一个组织
        'Dim dao As ommp.dao.OrganizationDAO = New ommp.dao.OrganizationDAO()
        'Output.Show(dao.Delete(595))
        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Dim result As Boolean = False
            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).Find(Organization.C__IDENTIFY & " = " & id)
                dr(Organization.C__ISDELETED) = True
                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Delete:" & ex.Message)
            End Try

            Return result
        End Function

        '查询组织列表
        'Dim dao As New ommp.dao.OrganizationDAO
        'Dim lists As IList(Of Object) = dao.FindList("[name] Like '%三峡云%'", "name desc")
        'output.Show("Count : " & lists.Count )
        'For Each dto As ommp.dto.Organization In lists 
        '    Output.Show("code_org_type = " & dto.code_org_type)
        '    Output.Show("Identify = " & dto.Identify)
        '    Output.Show("parent_identify = " & dto.parent_identify)
        '    Output.Show("name = " & dto.name)
        '    Output.Show("code = " & dto.code)
        '    Output.Show("parent_code = " & dto.parent_code)
        '    Output.Show("status = " & dto.status)
        '    Output.Show("code_org_type = " & dto.code_org_type)
        '    Output.Show("short_name = " & dto.short_name)
        '    Output.Show("description = " & dto.description)
        '    Output.Show("IsDeleted = " & dto.IsDeleted)
        '    Output.Show("_sort = " & dto._sort)
        'Next
        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements IQueryDAO.FindList
            Return FindRows(TABLE_NAME, filter, sort)
        End Function

        '查找一个组织
        'Dim dao As ommp.dao.OrganizationDAO = New ommp.dao.OrganizationDAO()
        'Dim dto As ommp.dto.Organization = dao.FindObject(595)
        'Output.Show("code_org_type = " & dto.code_org_type)
        'Output.Show("Identify = " & dto.Identify)
        'Output.Show("parent_identify = " & dto.parent_identify)
        'Output.Show("name = " & dto.name)
        'Output.Show("code = " & dto.code)
        'Output.Show("parent_code = " & dto.parent_code)
        'Output.Show("status = " & dto.status)
        'Output.Show("code_org_type = " & dto.code_org_type)
        'Output.Show("short_name = " & dto.short_name)
        'Output.Show("description = " & dto.description)
        'Output.Show("IsDeleted = " & dto.IsDeleted)
        'Output.Show("_sort = " & dto._sort)
        Public Function FindObject(ByVal id As Integer) As Object Implements IQueryDAO.FindObject
            Return FindRow(TABLE_NAME, id)
        End Function
    End Class

End Namespace
