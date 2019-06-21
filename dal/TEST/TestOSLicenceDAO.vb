Imports Foxtable

Imports log4net
Namespace dal.test
    Public Class TestOSLicenceDAO
        Implements IUnitTest

        Private Shared ReadOnly log As ILog = LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        Private ReadOnly dao As New ommp.dal.dao.OSLicenceDAO()
        Private id As Integer = -1

        Public Function TestInsert() As Boolean Implements IUnitTest.TestInsert
            'dao.
        End Function

        Public Function TestUpdate() As Boolean Implements IUnitTest.TestUpdate
            Throw New NotImplementedException()
        End Function

        Public Function TestDelete() As Boolean Implements IUnitTest.TestDelete
            Throw New NotImplementedException()
        End Function

        Public Function TestFind() As Boolean Implements IUnitTest.TestFind
            Throw New NotImplementedException()
        End Function

        Public Function TestList() As Boolean Implements IUnitTest.TestList
            Throw New NotImplementedException()
        End Function

        Public Function TestAll() As Boolean Implements IUnitTest.TestAll
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
