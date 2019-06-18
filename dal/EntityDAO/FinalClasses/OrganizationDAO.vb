Imports System.Reflection
Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao

    ' 已全部测试完成
    '20190611 by Andy
    Public Class OrganizationDAO
        Inherits BaseDAO

        Private Sub TestInsert()
            ' 添加一个组织
            Dim dao As ommp.dal.dao.OrganizationDAO = New ommp.dal.dao.OrganizationDAO()
            Dim result As Boolean = False
            Dim dto As New ommp.dal.dto.Organization()

            dto.name = "测试组织1-20190614"
            dto.parent_identify = 515
            dto.code = "01901"
            dto._code = "901"
            dto.status = True
            dto.short_name = "测1-0614"
            dto.code_org_type = 2
            dto.description = "测试组织1-描述"

            result = dao.InsertObject(Of Organization)(dto)
            Output.Show(result)
        End Sub

        '测试修改组织
        Private Sub TestUpdate()
            Dim dao As ommp.dal.dao.OrganizationDAO = New ommp.dal.dao.OrganizationDAO()
            Dim result As Boolean = False
            Dim dto As ommp.dal.dto.Organization = dao.FindObject(Of ommp.dal.dto.Organization)(602)
            dto.code_org_type = 1
            dto.name = "测试组织 20190614 修改3"
            dto.description = DateTime.Now.ToString()
            result = dao.UpdateObject(Of Organization)(dto)
            Output.Show(result)
        End Sub

        '删除一个组织
        Private Sub TestDelete()
            Dim dao As New ommp.dal.dao.OrganizationDAO()
            Output.Show(dao.DeleteObject(Of Organization)(100000))
        End Sub
    End Class

End Namespace
