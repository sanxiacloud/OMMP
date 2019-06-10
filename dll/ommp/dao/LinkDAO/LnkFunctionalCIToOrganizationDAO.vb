﻿Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class LnkFunctionalCIToOrganizationDAO
        Inherits BaseDAO
        Implements ILinkDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return LnkFunctionalCIToOrganization.TABLE_NAME
            End Get
        End Property



        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object

            Return Nothing
        End Function

        ' 添加一个 功能配置项与组织 链接记录
        'todo:test
        'Dim dao As ommp.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.Link(1870, 593)
        'Output.Show(result)
        Public Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.Link
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(LnkFunctionalCIToOrganization.TABLE_NAME).AddNew()

                dr(LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY) = fromId
                dr(LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY) = toId
                dr(LnkFunctionalCIToOrganization.C__ISDELETED) = False

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(LnkFunctionalCIToOrganization.TABLE_NAME & "->Link:" & ex.Message)
            End Try

            Return result
        End Function

        ' 删除一个 功能配置项与组织 链接记录
        'todo:test
        'Dim dao As ommp.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.UnLink(1870, 593)
        'Output.Show(result)
        Public Function UnLink(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.UnLink
            Dim result As Boolean = False

            Try
                Dim filter As String = LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY & " = " & fromId
                filter = filter & " AND " & LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY & " = " & toId

                Dim drs As List(Of DataRow)
                drs = DataTables(LnkFunctionalCIToOrganization.TABLE_NAME).Select(filter)

                For Each dr As DataRow In drs
                    dr(LnkFunctionalCIToOrganization.C__ISDELETED) = True
                    dr.Save()
                Next

                result = True
            Catch ex As Exception
                Output.Show(LnkFunctionalCIToOrganization.TABLE_NAME & "->UnLink:" & ex.Message)
            End Try

            Return result
        End Function

        '查询链接列表
        'Dim dao As new ommp.dao.LnkFunctionalCIToOrganizationDAO
        'Dim lists As IList(Of ommp.dto.LnkFunctionalCIToOrganization) = dao.FindList("[name] Like '%三峡云%'", "name desc")
        'output.Show("Count : " & lists.Count )
        'For Each obj As ommp.dto.LnkFunctionalCIToOrganization In lists 
        '    output.Show(obj.name)
        '    output.Show(obj.name)
        '    output.Show(obj.name)
        'Next
        Public Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of Object) Implements ILinkDAO.FindList
            Dim lists As IList(Of LnkFunctionalCIToOrganization) = New Generic.List(Of LnkFunctionalCIToOrganization)()
            Try
                Dim drs As List(Of DataRow)
                If sort IsNot Nothing Then
                    drs = DataTables(LnkFunctionalCIToOrganization.TABLE_NAME).Select(filter, sort)
                Else
                    drs = DataTables(LnkFunctionalCIToOrganization.TABLE_NAME).Select(filter)
                End If
                For Each dr As DataRow In drs
                    Dim item As New LnkFunctionalCIToOrganization()

                    item.Identify = dr(LnkFunctionalCIToOrganization.C__IDENTIFY)
                    item.functionalci_identify = dr(LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY)
                    item.organization_identify = dr(LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY)

                    lists.Add(item)
                Next
            Catch ex As Exception
                Output.Show(LnkFunctionalCIToOrganization.TABLE_NAME & "->FindList:" & ex.Message)
            End Try

            Return lists
        End Function

    End Class
End Namespace

