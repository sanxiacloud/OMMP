Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class OSLicenceDAO
        Inherits LicenceDAO(Of OSLicenceQT)
        Implements IEntityDAO(Of OSLicence)

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

        Public Function Insert(o As OSLicence) As Integer Implements IEntityDAO(Of OSLicence).Insert
            o.id = InsertLicence(o, GetType(OSLicence).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As OSLicence) As Boolean Implements IEntityDAO(Of OSLicence).Update
            Return UpdateLicence(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of OSLicence).Delete
            Return DeleteLicence(id) And DeleteObject(Of OSLicence)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace