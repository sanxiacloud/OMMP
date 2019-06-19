Imports System.Reflection
Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao

    Public Class OrganizationDAO(Of T As New)
        Inherits BaseDAO
        Implements IEntityDAO

        Public Function Insert(o As Object) As Integer Implements IEntityDAO.Insert
            Return InsertObject(Of Organization)(o)
        End Function

        Public Function Update(o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateObject(Of Organization)(o)
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteObject(Of Organization)(id)
        End Function

        Public Function Find(ByVal id As Integer) As Organization
            Return FindObject(Of Organization)(id)
        End Function

        Public Function List(ByVal Optional filter As String = "", ByVal Optional sort As String = Nothing) As IList(Of Organization)
            Return FindList(Of Organization)(filter, sort)
        End Function

        Private Sub TestInsert()
            ' 添加一个组织
            Dim dao As New ommp.dal.dao.OrganizationDAO(Of Organization)()
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
            Dim dao As New ommp.dal.dao.OrganizationDAO(Of Organization)()
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
            Dim dao As New ommp.dal.dao.OrganizationDAO(Of Organization)()
            Output.Show(dao.DeleteObject(Of Organization)(100000))
        End Sub
    End Class

End Namespace
