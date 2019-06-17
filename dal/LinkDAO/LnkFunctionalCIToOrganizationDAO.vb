Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao

    ' 已全部测试完成
    '20190611 by Andy
    Public Class LnkFunctionalCIToOrganizationDAO
        Inherits BaseDAO
        Implements ILinkDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return LnkFunctionalCIToOrganization.TABLE_NAME
            End Get
        End Property


        ' 添加一个 功能配置项与组织 链接记录
        'todo:test ok
        'Dim dao As ommp.dal.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dal.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.Link(1873, 595)
        'Output.Show(result)
        Public Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.Link
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

                dr(LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY) = fromId
                dr(LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY) = toId
                dr(LnkFunctionalCIToOrganization.C__ISDELETED) = False

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Link:" & ex.Message)
            End Try

            Return result
        End Function

        ' 删除一个 功能配置项与组织 链接记录
        'todo:test
        'Dim dao As ommp.dal.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dal.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.UnLink(1873, 595)
        'Output.Show(result)
        Public Function UnLink(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.UnLink
            Dim result As Boolean = False

            Try
                Dim filter As String = LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY & " = " & fromId
                filter = filter & " AND " & LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY & " = " & toId

                Dim drs As List(Of DataRow)
                drs = DataTables(_TABLE_NAME).Select(filter)

                For Each dr As DataRow In drs
                    dr(LnkFunctionalCIToOrganization.C__ISDELETED) = True
                    dr.Save()
                Next

                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->UnLink:" & ex.Message)
            End Try

            Return result
        End Function

        '查询链接列表
        'Dim dao As New ommp.dal.dao.LnkFunctionalCIToOrganizationDAO
        'Dim lists As IList(Of Object) = dao.FindList("organization_identify IN(590)", "_identify desc")
        'output.Show("Count : " & lists.Count )
        'For Each obj As ommp.dal.dto.LnkFunctionalCIToOrganization In lists 
        '    output.Show("functionalci_identify = " & obj.functionalci_identify)
        '    output.Show("organization_identify = " & obj.organization_identify)
        '    output.Show("description = " & obj.description)
        'Next

    End Class
End Namespace

