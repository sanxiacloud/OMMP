Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao
    Public Class CodeDAO
        Inherits GenericSimpleEntityDAO(Of Code)

        Public Function GetComboListString(t As String) As String
            Dim tableName As String = GetType(Code).Name

            Return DataTables(tableName).GetComboListString("label", String.Format("[t]='{0}'", t), "v")
        End Function

    End Class

End Namespace