Imports ommp.dto
Imports Foxtable

Namespace dao

    ' 已全部测试完成
    '20190611 by Andy
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
            Dim item As New LnkFunctionalCIToOrganization()

            item.Identify = dr(C__IDENTIFY)
            item.functionalci_identify = dr(LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY)
            item.organization_identify = dr(LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY)
            item.description = dr(LnkFunctionalCIToOrganization.C_DESCRIPTION)

            Return item
        End Function

        ' 添加一个 功能配置项与组织 链接记录
        'todo:test ok
        'Dim dao As ommp.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.Link(1873, 595)
        'Output.Show(result)
        Public Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.Link
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

                dr(LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY) = fromId
                dr(LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY) = toId
                dr(LnkFunctionalCIToOrganization.C__ISDELETED) = False

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Link:" & ex.Message)
            End Try

            Return result
        End Function

        ' 删除一个 功能配置项与组织 链接记录
        'todo:test
        'Dim dao As ommp.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.UnLink(1873, 595)
        'Output.Show(result)
        Public Function UnLink(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.UnLink
            Dim result As Boolean = False

            Try
                Dim filter As String = LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY & " = " & fromId
                filter = filter & " AND " & LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY & " = " & toId

                Dim drs As List(Of DataRow)
                drs = DataTables(TABLE_NAME).Select(filter)

                For Each dr As DataRow In drs
                    dr(LnkFunctionalCIToOrganization.C__ISDELETED) = True
                    dr.Save()
                Next

                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->UnLink:" & ex.Message)
            End Try

            Return result
        End Function

        '查询链接列表
        'Dim dao As New ommp.dao.LnkFunctionalCIToOrganizationDAO
        'Dim lists As IList(Of Object) = dao.FindList("organization_identify IN(590)", "_identify desc")
        'output.Show("Count : " & lists.Count )
        'For Each obj As ommp.dto.LnkFunctionalCIToOrganization In lists 
        '    output.Show("functionalci_identify = " & obj.functionalci_identify)
        '    output.Show("organization_identify = " & obj.organization_identify)
        '    output.Show("description = " & obj.description)
        'Next
        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements ILinkDAO.FindList
            Return FindRows(TABLE_NAME, filter, sort)
        End Function
    End Class
End Namespace

