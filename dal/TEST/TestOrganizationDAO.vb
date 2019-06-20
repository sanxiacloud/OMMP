Imports Foxtable

Namespace dal.test
    Public Class TestOrganizationDAO
        Implements IUnitTest

        Private ReadOnly dao As New ommp.dal.dao.OrganizationDAO()
        Private id As Integer = -1

        Public Sub New()

        End Sub

        ' 添加一个组织
        Sub TestInsert()
            Dim dto As New ommp.dal.dto.Organization With {
                .name = "测试组织1-20190620-1",
                .parent_identify = 515,
                .code = "01902",
                ._code = "902",
                .status = True,
                .short_name = "测1-0620-1",
                .code_org_type = 2,
                .description = "测试组织2-描述"
            }

            id = dao.Insert(dto)
            Output.Show(id)
        End Sub

        '测试修改组织
        Sub TestUpdate()
            Dim result As Boolean = False
            Dim dto As ommp.dal.dto.Organization = dao.Find(id)
            dto.code_org_type = 1
            dto.name = "测试组织 20190620 修改1"
            dto.description = DateTime.Now.ToString()
            result = dao.Update(dto)
            Output.Show(result)
        End Sub

        Sub TestDelete()
            Output.Show(dao.Delete(id))
        End Sub

        Public Function TestFind() As Boolean Implements IUnitTest.TestFind
            Throw New NotImplementedException()
        End Function

        Public Function TestList() As Boolean Implements IUnitTest.TestList
            Throw New NotImplementedException()
        End Function

        Public Function TestAll() As Boolean Implements IUnitTest.TestAll
            Throw New NotImplementedException()
        End Function

        Private Function IUnitTest_TestInsert() As Boolean Implements IUnitTest.TestInsert
            Throw New NotImplementedException()
        End Function

        Private Function IUnitTest_TestUpdate() As Boolean Implements IUnitTest.TestUpdate
            Throw New NotImplementedException()
        End Function

        Private Function IUnitTest_TestDelete() As Boolean Implements IUnitTest.TestDelete
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
