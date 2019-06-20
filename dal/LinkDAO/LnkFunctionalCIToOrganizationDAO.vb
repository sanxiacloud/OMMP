Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao

    Public Class LnkFunctionalCIToOrganizationDAO
        Inherits GenericLinkDAO(Of LnkFunctionalCIToOrganization)
        Implements ILinkDAO

        ' 添加一个 功能配置项与组织 链接记录
        'todo:test ok
        'Dim dao As ommp.dal.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dal.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.Link(1873, 595)
        'Output.Show(result)


        ' 删除一个 功能配置项与组织 链接记录
        'todo:test
        'Dim dao As ommp.dal.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dal.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.UnLink(1873, 595)
        'Output.Show(result)



        '查询链接列表
        Private Sub TestFindList()
            Dim dao As New ommp.dal.dao.LnkFunctionalCIToOrganizationDAO
            Dim lists As IList(Of ommp.dal.dto.LnkFunctionalCIToOrganization) = dao.FindList(Of ommp.dal.dto.LnkFunctionalCIToOrganization)("organization_identify IN (590)", "_identify desc")
            Output.Show("Count : " & lists.Count)
            For Each obj As ommp.dal.dto.LnkFunctionalCIToOrganization In lists
                Output.Show("functionalci_identify = " & obj.functionalci_identify)
                Output.Show("organization_identify = " & obj.organization_identify)
                Output.Show("description = " & obj.description)
            Next
        End Sub

    End Class
End Namespace

