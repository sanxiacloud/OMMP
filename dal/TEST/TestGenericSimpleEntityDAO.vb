Imports Foxtable

Imports log4net
Namespace dal.test
    Public Class TestGenericSimpleEntityDAO
        Implements IUnitTest

        Private Shared ReadOnly log As ILog = LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        Private ReadOnly dao As New ommp.dal.dao.CodeDAO()
        Private id As Integer = -1

        Public Function TestInsert() As Boolean Implements IUnitTest.TestInsert
            Dim dto As New ommp.dal.dto.Code With {
                .t = "TestType",
                .label = "测试值1",
                .v = 0,
                .des = "TestType - 0"
            }

            'id = dao.Insert(dto)

            'Output.Show(id > 0)
        End Function

        Public Function TestUpdate() As Boolean Implements IUnitTest.TestUpdate
            'Dim dto As ommp.dal.dto.Code = dao.Find(id)
            'dto.des = DateTime.Now
            'dto.label = "test value 1"
            'Output.Show(dao.Update(dto))
        End Function

        Public Function TestDelete() As Boolean Implements IUnitTest.TestDelete
            'Output.Show(dao.Delete(id))
        End Function

        Public Function TestFind() As Boolean Implements IUnitTest.TestFind
            'Dim dto As ommp.dal.dto.Code = dao.Find(id)
            'Output.Show(String.Format("{0}[{1}] -- {2}={3}", dto.t, dto.des, dto.label, dto.v))
        End Function

        Public Function TestList() As Boolean Implements IUnitTest.TestList
            Dim lists As IList(Of ommp.dal.dto.Code)
            lists = dao.List(" t='代码类型' ", " v desc ")
            Output.Show(lists.Count)
            Output.Show(lists(0).ToString())
            For Each o As ommp.dal.dto.Code In lists
                Output.Show(String.Format("{0}[{1}] -- {2}={3}", o.t, o.des, o.label, o.v))
            Next
        End Function

        Public Function TestAll() As Boolean Implements IUnitTest.TestAll
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace