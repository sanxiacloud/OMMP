﻿Imports System.Reflection
Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao

    ' 已全部测试完成
    '20190611 by Andy
    Public Class OrganizationDAO
        Inherits BaseDAO
        Implements IEntityDAO

        Public Sub New()
            ' 构造函数，默认为空            
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return Organization.TABLE_NAME
            End Get
        End Property

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Return InsertObject(Of ommp.dal.dto.Organization)(CType(o, Organization))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateObject(Of ommp.dal.dto.Organization)(CType(o, Organization))
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteObject(Of Organization)(id)
        End Function

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

            result = dao.Insert(dto)
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
            result = dao.Update(dto)
            Output.Show(result)
        End Sub

        '删除一个组织
        Private Sub TestDelete()
            Dim dao As ommp.dal.dao.OrganizationDAO = New ommp.dal.dao.OrganizationDAO()
            Output.Show(dao.Delete(600))
        End Sub
    End Class

End Namespace