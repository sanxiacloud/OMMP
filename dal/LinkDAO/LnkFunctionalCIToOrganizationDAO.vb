Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao

    Public Class LnkFunctionalCIToOrganizationDAO
        Inherits BaseDAO
        Implements ILinkDAO

        ' 添加一个 功能配置项与组织 链接记录
        'todo:test ok
        'Dim dao As ommp.dal.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dal.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.Link(1873, 595)
        'Output.Show(result)
        Public Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.Link
            Dim obj As New LnkFunctionalCIToOrganization()
            Dim result As Boolean = False

            Try
                obj.functionalci_identify = fromId
                obj.organization_identify = toId
                InsertObject(obj)

                result = True
            Catch ex As Exception
                Output.Show(obj.GetType().Name & "(DAO) -> Link ")
                Output.Show(ex.Message)
                Output.Show(ex.StackTrace)
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
            Dim obj As New LnkFunctionalCIToOrganization()
            Dim fromObject As New FunctionalCI()
            Dim toObject As New Organization()
            Dim result As Boolean = False

            Try
                Dim filter As String = fromObject.GetType().Name & C__IDENTIFY & " = " & fromId
                filter = filter & " AND " & toObject.GetType().Name & C__IDENTIFY & " = " & toId

                Dim lists As IList(Of LnkFunctionalCIToOrganization) = FindList(Of LnkFunctionalCIToOrganization)(filter, Nothing)

                For Each dto As LnkFunctionalCIToOrganization In lists
                    'Output.Show("Identify = " & dto._Identify)
                    DeleteObject(Of LnkFunctionalCIToOrganization)(dto._Identify)
                Next

                result = True
            Catch ex As Exception
                Output.Show(obj.GetType().Name & "(DAO) -> UnLink ")
                Output.Show(ex.Message)
                Output.Show(ex.StackTrace)
            End Try

            Return result
        End Function

        Function ListByFunctionalCI(fciid As Integer) As IList(Of LnkFunctionalCIToOrganization)
            Return FindList(Of LnkFunctionalCIToOrganization)("functionalci_identify = " & fciid, C__IDENTIFY)
        End Function

        Function ListByOrganization(orgid As Integer) As IList(Of LnkFunctionalCIToOrganization)
            Return FindList(Of LnkFunctionalCIToOrganization)("organization_identify = " & orgid, C__IDENTIFY)
        End Function

        Function ListFunctionalCI(orgid As Integer) As IList(Of Integer)
            Dim resultList As New Generic.List(Of Integer)()
            For Each obj As LnkFunctionalCIToOrganization In FindList(Of LnkFunctionalCIToOrganization)("organization_identify = " & orgid, C__IDENTIFY)
                resultList.Add(obj.functionalci_identify)
            Next
            Return resultList
        End Function

        Function ListFunctionalCI(orgid As Integer, finalClass As String) As IList(Of Integer)
            Dim resultList As New Generic.List(Of Integer)()
            Dim fci As New FunctionalCI()
            For Each obj As LnkFunctionalCIToOrganization In FindList(Of LnkFunctionalCIToOrganization)("organization_identify = " & orgid, C__IDENTIFY)
                fci = FindObject(Of FunctionalCI)(obj.functionalci_identify)
                If fci.finalclass.Equals(finalClass) Then
                    resultList.Add(obj.functionalci_identify)
                End If
            Next
            Return resultList
        End Function

        Function ListOrganization(fciid As Integer) As IList(Of Integer)
            Dim resultList As New Generic.List(Of Integer)()
            For Each obj As LnkFunctionalCIToOrganization In FindList(Of LnkFunctionalCIToOrganization)("functionalci_identify = " & fciid, C__IDENTIFY)
                resultList.Add(obj.organization_identify)
            Next
            Return resultList
        End Function

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

