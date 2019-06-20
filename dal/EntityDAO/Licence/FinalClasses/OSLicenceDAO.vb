Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class OSLicenceDAO
        Inherits LicenceDAO(Of OSLicenceQT)
        Implements IEntityDAO

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New OSLicenceQT()
            Dim baseObject As New Licence()
            Dim finalObject As New OSLicence()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of OSLicence)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteLicence(id) And DeleteObject(Of OSLicence)(id) And BuildJoinTable()
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As OSLicence = CType(o, OSLicence)
            obj.id = InsertLicence(o, obj.GetType().Name)
            Return InsertObject(Of OSLicence)(CType(o, OSLicence)) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateLicence(o) And UpdateObject(Of OSLicence)(CType(o, OSLicence)) And BuildJoinTable()
        End Function

    End Class

End Namespace