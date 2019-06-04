Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class LnkFunctionalCIToOrganizationDAO : Inherits BaseDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        ' 添加一个 功能配置项与组织 链接记录
        'todo:test
        'Dim dao As ommp.dao.LnkFunctionalCIToOrganizationDAO = New ommp.dao.LnkFunctionalCIToOrganizationDAO()
        'Dim result As Boolean = False
        'result = dao.Link(1870, 593)
        'Output.Show(result)
        Public Function Link(ByVal functionalci_identify As Integer, ByVal organization_identify As Integer) As Boolean
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(LnkFunctionalCIToOrganization.TABLE_NAME).AddNew()

                dr(LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY) = functionalci_identify
                dr(LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY) = organization_identify
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
        Public Function UnLink(ByVal functionalci_identify As Integer, ByVal organization_identify As Integer) As Boolean
            Dim result As Boolean = False

            Try
                Dim filter As String = LnkFunctionalCIToOrganization.C_FUNCTIONALCI_IDENTIFY & " = " & functionalci_identify
                filter = filter & " AND " & LnkFunctionalCIToOrganization.C_ORGANIZATION_IDENTIFY & " = " & organization_identify

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

    End Class
End Namespace

