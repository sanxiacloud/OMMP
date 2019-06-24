Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class SoftwareLicenceDAO
        Inherits LicenceDAO(Of SoftwareLicenceQT)
        Implements IEntityDAO(Of SoftwareLicence)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New SoftwareLicenceQT()
            Dim baseObject As New Licence()
            Dim finalObject As New SoftwareLicence()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of SoftwareLicence)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub


        Public Function Insert(o As SoftwareLicence) As Integer Implements IEntityDAO(Of SoftwareLicence).Insert
            o.id = InsertLicence(o, GetType(SoftwareLicence).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As SoftwareLicence) As Boolean Implements IEntityDAO(Of SoftwareLicence).Update
            Return UpdateLicence(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of SoftwareLicence).Delete
            Return DeleteLicence(id) And DeleteObject(Of SoftwareLicence)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace